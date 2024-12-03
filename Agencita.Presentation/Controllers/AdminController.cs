using AgendaMedica.Core.Application.Helpers;
using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.User;
using AgendaMedica.Core.Application.ViewModels.User.Admin;
using Microsoft.AspNetCore.Mvc;
namespace Agencita.Presentation.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private UserViewModel _userViewModel;
        private readonly IRoleService _roleService;

        public AdminController(IUserService userService, IRoleService roleService)
        {

            _userService = userService;
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
            List<UserViewModel> users = (List<UserViewModel>)await _userService.GetAllUserByIdConsulting(_userViewModel.ConsultingRoomId);
            ViewBag.Users = users;
            return View();
        }

        public async Task<IActionResult> CrearUsuario()
        {

            ViewBag.Role = await _roleService.GetAllViewModel();
            return View("Formularios/CrearUsuario", new CreateUserViewModel());
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Role = await _roleService.GetAllViewModel();
            var userData = await _userService.GetByIdSaveViewModel(id);
            return View("Formularios/CrearUsuario", new CreateUserViewModel
            {
                Id = userData.Id,
                Email = userData.Email,
                LastName = userData.LastName,
                Name = userData.Name,
                RoleId = userData.RoleId,
                Username = userData.Username
            });
        }
        public IActionResult Delete(int id)
        {
            ViewBag.id = id;
            return View("Formularios/DeleteUser");
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario(CreateUserViewModel userVm)
        {
            ViewBag.Role = await _roleService.GetAllViewModel();
            if (!ModelState.IsValid)
            {
                return View("Formularios/CrearUsuario", userVm);
            }

            var usernameExist = await _userService.ConfirmUsernameExist(userVm.Username);
            if (usernameExist)
            {
                ModelState.AddModelError(nameof(userVm.Username), "El nombre del Usuario ya existe");
                return View("Formularios/CrearUsuario", userVm);
            }

            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");


            await _userService.Add(new SaveUserViewModel
            {
                ConsultingRoomId = _userViewModel.ConsultingRoomId,
                Username = userVm.Username,
                Email = userVm.Email,
                LastName = userVm.LastName,
                Password = userVm.Password,
                Name = userVm.Name,
                RoleId = userVm.RoleId,
            });

            return RedirectToAction("Index");
        }
       
        [HttpPost]
        public async Task<IActionResult> UpdateUser(CreateUserViewModel userVm)
        {
            
            if(userVm.Password == null)
            {
                ModelState.Remove("Password");
                ModelState.Remove("ConfirmPassword");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Role = await _roleService.GetAllViewModel();
                return View("Formularios/CrearUsuario", userVm);
            }
            var currentUsername = await _userService.GetByIdSaveViewModel(userVm.Id); 
            var usernameExist = await _userService.ConfirmUsernameExist(userVm.Username);
            if (usernameExist && currentUsername.Username != userVm.Username)
            {
                ModelState.AddModelError(nameof(userVm.Username), "El nombre del Usuario ya existe");
                return View("Formularios/CrearUsuario", userVm);
            }
            await _userService.Update(new SaveUserViewModel
            {
                Id = userVm.Id,
                ConsultingRoomId = userVm.ConsultingRoomId,
                Username = userVm.Username,
                Email = userVm.Email,
                LastName = userVm.LastName,
                Password = userVm.Password,
                Name = userVm.Name,
                RoleId = userVm.RoleId,
            });

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
