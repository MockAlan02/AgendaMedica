using Agencita.Presentation.Middlewares;
using AgendaMedica.Core.Application;
using AgendaMedica.Core.Application.Helpers;
using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.ConsultingRoom;
using AgendaMedica.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace Agencita.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConsultingRoomService _consultingRoomService;
        public UserController(IUserService userService, IConsultingRoomService consultingRoomService)
        {
            _userService = userService;
            _consultingRoomService = consultingRoomService;

        }

        public IActionResult Index()
        {
            return View();
        }
        [ServiceFilter(typeof(ValidateUserSession))]
        public IActionResult Login()
        {
            return View();
        }
        [ServiceFilter(typeof(ValidateUserSession))]

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Logout("user");
            return RedirectToAction("Login");
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel loginVm)
        {
            if (!ModelState.IsValid)
            {

                return View(loginVm);
            }

            UserViewModel userViewModel = await _userService.Login(loginVm);

            if (userViewModel != null)
            {
                HttpContext.Session.Set<UserViewModel>("user", userViewModel);
                return RedirectToAction("index", "Admin");
            }

            ModelState.AddModelError(string.Empty, "Datos de accesos incorrecto");
            return View(loginVm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel saveUserVm)
        {
            if (!ModelState.IsValid)
            {
                return View(saveUserVm);
            }
            var usernameExist = await _userService.ConfirmUsernameExist(saveUserVm.Username);
            if (usernameExist)
            {
                ModelState.AddModelError(nameof(saveUserVm.Username), "El nombre del Usuario ya existe");
                return View(saveUserVm);
            }


            var consultingRoom = await _consultingRoomService.AddAsync(new SaveConsultingRoomViewModel
            {
                Name = saveUserVm.ConsultingName
            });

            saveUserVm.RoleId = (int)RoleEnum.Administrador;
            saveUserVm.ConsultingRoomId = consultingRoom.Id;

            await _userService.Add(saveUserVm);
            return RedirectToRoute(new { controller = "Doctor", action = "Index" });
        }
    }
}
