using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.User;
using AgendaMedica.Core.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Core.Application.ViewModels.Doctor;
using Agencita.Presentation.Middlewares;


namespace Agencita.Presentation.Controllers
{
    [ServiceFilter(typeof(ValidateUserSession))]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private UserViewModel _userViewModel = new();
        public DoctorController(IDoctorService doctorService)
        {

            _doctorService = doctorService;
        }
        public async Task<IActionResult> Index()
        {
            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
            ViewBag.Doctors = await _doctorService.GetDoctorsByConsultingRoomId(_userViewModel.ConsultingRoomId);
            return View();
        }

        public IActionResult CreateDoctor()
        {
            return View("Forms/SaveDoctorForm", new SaveDoctorViewModel());
        }

        public async Task<IActionResult> UpdateDoctor(int id)
        {
            var doctor = await _doctorService.GetByIdSaveViewModel(id);
            return View("Forms/SaveDoctorForm", doctor);
        }

        public IActionResult Delete(int id)
        {
            ViewBag.id = id;
            return View("Forms/DeleteDoctor");
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(SaveDoctorViewModel doctorVm)
        {
            if (!ModelState.IsValid)
            {
                return View("Forms/SaveDoctorForm", doctorVm);
            }
            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
            doctorVm.ConsultingRoomId = _userViewModel.ConsultingRoomId;
            var doctor = await _doctorService.AddAsync(doctorVm);
          
            if (doctor.Id != 0)
            {
                doctor.Picture = PictureHelper.UploadFile(doctorVm.FormFile, doctor.Id, "Doctors");
                await _doctorService.Update(doctor);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(SaveDoctorViewModel doctorVm)
        {
            if (doctorVm.Id != 0)
            {
                ModelState.Remove("FormFile");
            }

            if (!ModelState.IsValid)
            {
                return View("Forms/SaveDoctorForm", doctorVm);
            }

            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");

            doctorVm.ConsultingRoomId = _userViewModel.ConsultingRoomId;
            if (doctorVm.FormFile != null)
            {
                doctorVm.Picture = PictureHelper.UploadFile(doctorVm.FormFile, doctorVm.Id, "Doctors");
            }
            await _doctorService.Update(doctorVm);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
