using AgendaMedica.Core.Application.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Core.Application.Helpers;
using AgendaMedica.Core.Application.ViewModels.User;
using AgendaMedica.Core.Application.ViewModels.Appoiment;
using AgendaMedica.Core.Application;
using AgendaMedica.Core.Application.ViewModels.LaboratoryResult;
using AgendaMedica.Core.Application.ViewModels.LaboratoryResult.TestResult;
using Agencita.Presentation.Middlewares;

namespace Agencita.Presentation.Controllers
{
    [ServiceFilter(typeof(ValidateUserSession))]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly ILaboratoryTestService _laboratoryTestService;
        private readonly ILaboratoryResultService _laboratoryResultService;
        private UserViewModel _userViewModel = new();
        public AppointmentsController(IAppointmentService appointmentService,
            IPatientService patientService,
            IDoctorService doctorService,
            ILaboratoryTestService laboratoryTestService,
            ILaboratoryResultService laboratoryResultService)
        {

            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
            _laboratoryTestService = laboratoryTestService;
            _laboratoryResultService = laboratoryResultService;

        }

        public async Task<IActionResult> Index()
        {
            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
            ViewBag.Appointments = await _appointmentService.GetAppointmensByConsultingId(_userViewModel.ConsultingRoomId);
            return View();
        }

        public async Task<IActionResult> Create()
        {
            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
            ViewBag.Patients = await _patientService.GetPatientsByConsultingId(_userViewModel.ConsultingRoomId);
            ViewBag.Doctors = await _doctorService.GetDoctorsByConsultingRoomId(_userViewModel.ConsultingRoomId);
            return View("Forms/SaveAppointments", new SaveAppointmentViewModel());
        }

        public async Task<IActionResult> Update(int id)
        {
            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
            var appointmentVm = await _appointmentService.GetByIdSaveViewModel(id);
            ViewBag.Patients = await _patientService.GetPatientsByConsultingId(_userViewModel.ConsultingRoomId);
            ViewBag.Doctors = await _doctorService.GetDoctorsByConsultingRoomId(_userViewModel.ConsultingRoomId);
            return View("Forms/SaveAppointments", appointmentVm);
        }
        public IActionResult Delete(int id)
        {
            ViewBag.id = id;
            return View("Forms/Delete");
        }

        public async Task<IActionResult> AddTest(int id)
        {
            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
            ViewBag.Tests = await _laboratoryTestService.GetTestsByConsultingRoomId(_userViewModel.ConsultingRoomId);
            ViewBag.id = id;
            return View("Forms/AddTest");
        }
        public async Task<IActionResult> Results(int id, bool btn = false)
        {
            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
            var result = await _laboratoryResultService.GetTestByConsultingRoomId(_userViewModel.ConsultingRoomId);
            ViewBag.Results = result.Where(x => x.AppointmentId == id).ToList();
            ViewBag.id = id;
            ViewBag.btn = btn;
            return View("Forms/Results");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(SaveAppointmentViewModel appointmentVm)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
                ViewBag.Patients = await _patientService.GetPatientsByConsultingId(_userViewModel.ConsultingRoomId);
                ViewBag.Doctors = await _doctorService.GetDoctorsByConsultingRoomId(_userViewModel.ConsultingRoomId);
                return View("Forms/SaveAppointments", appointmentVm);
            }
            _userViewModel = HttpContext.Session.Get<UserViewModel>("user");
            appointmentVm.ConsultingRoomId = _userViewModel.ConsultingRoomId;
            appointmentVm.StatusId = (int)StatusEnum.pending;
            await _appointmentService.Add(appointmentVm);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAppointment(SaveAppointmentViewModel appointmentVm)
        {
            if (!ModelState.IsValid)
            {
                return View("Forms/SaveAppointments", appointmentVm);
            }
            await _appointmentService.Update(appointmentVm);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAppointments(int id)
        {
            await _laboratoryResultService.DeleteResultsByAppointmentId(id);
            await _appointmentService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddLaboratories(TestResultVm model)
        {
            if (model.TestId == null || model.TestId.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "Debe seleccionar al menos un test.");
                return View("Forms/AddTest", model);
            }
            var appointmet = await _appointmentService.GetByIdSaveViewModel(model.Id);

            foreach (var testId in model!.TestId)
            {

                var result = new SaveLaboratoryResultViewModel
                {
                    LaboratoryTestId = testId,
                    PatientId = appointmet.PatientId,
                    Result = "",
                    AppoimentId = appointmet.Id,
                    ConsultingRoomId = appointmet.ConsultingRoomId,
                };
                await _laboratoryResultService.Add(result);
            }

            await _appointmentService.Update(new SaveAppointmentViewModel
            {
                ConsultingRoomId = appointmet.ConsultingRoomId,
                Description = appointmet.Description,
                DoctorId = appointmet.DoctorId,
                Id = appointmet.Id,

                DateAppointment = appointmet.DateAppointment,
                PatientId = appointmet.PatientId,
                StatusId = (int)StatusEnum.PendingResult,
            });

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAppointments(int id)
        {
            var appointment = await _appointmentService.GetByIdSaveViewModel(id);
            appointment.StatusId = (int)StatusEnum.Complete;
            await _appointmentService.Update(appointment);
            return RedirectToAction("Index");
        }

     

    }
}

