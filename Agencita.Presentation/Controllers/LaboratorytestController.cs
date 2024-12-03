using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.User;
using AgendaMedica.Core.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Core.Application.ViewModels.Laboratorytest;
using Agencita.Presentation.Middlewares;

namespace Agencita.Presentation.Controllers
{
    [ServiceFilter(typeof(ValidateUserSession))]
    public class LaboratorytestController : Controller
    {
        private readonly ILaboratoryTestService _laboratoryTestService;
        private UserViewModel _userVm;
        public LaboratorytestController(ILaboratoryTestService laboratoryTestService)
        {
            _laboratoryTestService = laboratoryTestService;
        }
        public async Task<IActionResult> Index()
        {
            _userVm = HttpContext.Session.Get<UserViewModel>("user");
            ViewBag.Tests = await _laboratoryTestService.GetTestsByConsultingRoomId(_userVm.ConsultingRoomId);
            return View();
        }
        public  IActionResult Create()
        {

            return View("Forms/SaveLaboratoryTest", new SaveLaboratorySaveViewModel());
        }
        public async Task<IActionResult> Update(int id)
        {
            var test = await _laboratoryTestService.GetByIdSaveViewModel(id);
            return View("Forms/SaveLaboratoryTest", test);
        }

        public IActionResult Delete(int id)
        {
            ViewBag.id = id;
            return View("Forms/Delete");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(SaveLaboratorySaveViewModel testVm)
        {
            if (!ModelState.IsValid)
            {
                return View("Forms/SaveLaboratoryTest", testVm);
            }

            _userVm = HttpContext.Session.Get<UserViewModel>("user");
            testVm.ConsultingRoomId = _userVm.ConsultingRoomId;
            await _laboratoryTestService.Add(testVm);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTest(SaveLaboratorySaveViewModel testVm)
        {
            if (!ModelState.IsValid)
            {
                return View("Forms/SaveLaboratoryTest", testVm);
            }
            _userVm = HttpContext.Session.Get<UserViewModel>("user");
            testVm.ConsultingRoomId = _userVm.ConsultingRoomId;
            await _laboratoryTestService.Update(testVm);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTest(int id)
        {
            await _laboratoryTestService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
