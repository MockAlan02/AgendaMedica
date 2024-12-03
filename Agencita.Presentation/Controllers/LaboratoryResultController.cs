using AgendaMedica.Core.Application.ViewModels.User;
using AgendaMedica.Core.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Core.Application.ViewModels.LaboratoryResult;
using AgendaMedica.Core.Application.Interface.Service;
using Agencita.Presentation.Middlewares;

namespace Agencita.Presentation.Controllers
{
    [ServiceFilter(typeof(ValidateUserSession))]
    public class LaboratoryResultController : Controller
    {
        private readonly ILaboratoryResultService _laboratoryResultService;
        private UserViewModel _userViewModel;
        public LaboratoryResultController(ILaboratoryResultService laboratoryResultService)
        {
            _laboratoryResultService = laboratoryResultService;
        }
        public async Task<IActionResult> Index()
        {
            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
            var resultados = await _laboratoryResultService.GetTestByConsultingRoomId(_userViewModel.ConsultingRoomId);
            ViewBag.Results = resultados.Where(x => x.Status == false).ToList();
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _laboratoryResultService.GetByIdSaveViewModel(id);
            return View("Forms/SaveResult", result);
        }
        public async Task<IActionResult> SearchByCedula(string cedula = "")
        {
            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
            var results = await _laboratoryResultService.GetResultsByCedulaAsync(_userViewModel.ConsultingRoomId, cedula);
            ViewBag.Results = results;
            return View("Index");
           
        
        }

        [HttpPost]
        public async Task<IActionResult> SaveResult(SaveLaboratoryResultViewModel resultvm)
        {
            ModelState.Remove("LaboratoryTest");
            if (!ModelState.IsValid)
            {
                return View("Forms/SaveResult", resultvm);
            }
            resultvm.Status = true;
            await _laboratoryResultService.Update(resultvm);
            return RedirectToAction("Index");
        }
       
    }
}
