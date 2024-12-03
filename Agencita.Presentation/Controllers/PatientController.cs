using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.User;
using AgendaMedica.Core.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Core.Application.ViewModels.Patient;
using Agencita.Presentation.Middlewares;


namespace Agencita.Presentation.Controllers
{
    [ServiceFilter(typeof(ValidateUserSession))]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private UserViewModel _userVm;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public async Task<IActionResult> Index()
        {
            _userVm = HttpContext.Session.Get<UserViewModel>("user");
            ViewBag.Patients = await _patientService.GetPatientsByConsultingId(_userVm.ConsultingRoomId);
            return View();
        }

        public IActionResult Create()
        {
            return View("Forms/SavePatient", new SavePatienViewModel());
        }
        public async Task<IActionResult> Update(int id)
        {
            var patient = await _patientService.GetByIdSaveViewModel(id);
            return View("Forms/SavePatient", patient);
        }

        public IActionResult Delete(int id)
        {
            ViewBag.id = id;
            return View("Forms/DeletePatient");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(SavePatienViewModel patientVm)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {

                return View("Forms/SavePatient", patientVm);
            }
            _userVm = HttpContext.Session.Get<UserViewModel>("user");
            patientVm.ConsultingRoomId = _userVm.ConsultingRoomId;
            var patient = await _patientService.AddAsync(patientVm);
            if (patient.Id != 0)
            {
                patient.Picture = PictureHelper.UploadFile(patientVm.FormFile, patient.Id, "Patients");
                await _patientService.Update(patient);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePatient(SavePatienViewModel patientVm)
        {
            if (patientVm.Id != 0)
            {
                ModelState.Remove("FormFile");
            }

            if (!ModelState.IsValid)
            {
                return View("Forms/SavePatient", patientVm);
            }
            _userVm = HttpContext.Session.Get<UserViewModel>("user");
            patientVm.ConsultingRoomId = _userVm.ConsultingRoomId;

            if (patientVm.FormFile != null)
            {
                patientVm.Picture = PictureHelper.UploadFile(patientVm.FormFile, patientVm.Id, "Patients");
            }

            await _patientService.Update(patientVm);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
