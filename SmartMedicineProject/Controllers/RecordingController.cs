using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicineProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMedicineProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SmartMedicineProject.Controllers
{
    public class RecordingController : Controller
    {
        private SMAppContext db;
        public RecordingController(SMAppContext context)
        {
            db = context;

        }
        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public IActionResult JoinRecord(string _PhoneNumber, DateTime date)
        {           
            IQueryable<RecordModel> _recordModels = db.recordModels.Where(c => c.DoctorUser == null);
            if (_PhoneNumber != null )
            {
                _recordModels = _recordModels.Where(p => p.PhoneNumber == _PhoneNumber);
            }
            if (date != DateTime.MinValue)
            {
                _recordModels = _recordModels.Where(p => p.RecordDate == date.ToShortDateString());
            }
            RecrordingListViewModel recrordingListViewModel = new RecrordingListViewModel
            {
               recordModels = _recordModels,
              // PhoneNumber = _PhoneNumber,
              // RecordDate = date.ToShortDateString()
            };         
            return View(recrordingListViewModel);
        }
        public RedirectToActionResult JoinPacient(int? id)
        {
            if (id != null && id != 0)
            {
                string Iden = User.Identity.Name;
                var Doctor = db.doctorUsers.Where(u => u.Email == Iden).FirstOrDefault();
                var pacient = db.recordModels.Where(u => u.ID == id).FirstOrDefault();
                pacient.DoctorUserId = Doctor.Id;
                db.SaveChangesAsync();               
            }
            DateTime dateTime = DateTime.MinValue;
            return RedirectToAction("JoinRecord", "Recording");
        }
        public IActionResult PacientsInfo()
        {
            string Iden = User.Identity.Name;
            var Doctor = db.doctorUsers.Where(u => u.Email == Iden).FirstOrDefault();
            IQueryable<RecordModel> _recordModels = db.recordModels.Where(c => c.DoctorUser == Doctor);
            
            PacientsInfoViewModel pacientsInfoViewModel = new PacientsInfoViewModel
            {
                recordModels = _recordModels,               
            };
            return View(pacientsInfoViewModel);
        }

        public IActionResult PartialViewPacientList(string _PhoneNumber, DateTime date)
        {
            string Iden = User.Identity.Name;
            var Doctor = db.doctorUsers.Where(u => u.Email == Iden).FirstOrDefault();           

            IQueryable<RecordModel> _recordModels = db.recordModels.Where(c => c.DoctorUser == Doctor);
            if (_PhoneNumber != null)
            {
                _recordModels = _recordModels.Where(p => p.PhoneNumber == _PhoneNumber);
            }
            if (date != DateTime.MinValue)
            {
                _recordModels = _recordModels.Where(p => p.RecordDate == date.ToShortDateString());
            }
            if(_PhoneNumber == null && date == DateTime.MinValue)
            {
                return new EmptyResult();
            }

            PacientsInfoViewModel pacientsInfoViewModel = new PacientsInfoViewModel
            {
                recordModels = _recordModels,
                PhoneNumber = _PhoneNumber,
                RecordDate = date.ToShortDateString()
            };
            return PartialView(pacientsInfoViewModel);
        }
        [HttpGet]
        public async Task<JsonResult> GetInfo(int ID)
        {
            var PacientInfo = await db.pacientMedCarts.Where(u => u.RecordModelId == ID).FirstOrDefaultAsync();
            
            return Json(PacientInfo);
        }
        public async Task<EmptyResult> UpdateInfo(int id, int age, string dateBorn, string status, string info)
        {
            var Pacient = await db.pacientMedCarts.Where(u => u.RecordModelId == id).FirstOrDefaultAsync();
            Pacient.Age = age;
            Pacient.DateBorn = dateBorn;
            Pacient.Status = status;
            Pacient.Info = info;
            await db.SaveChangesAsync();

            return new EmptyResult();
        }
       /* public async Task<EmptyResult> AgeUpdate(int id, int age)
        {
            var Pacient = await db.pacientMedCarts.Where(u => u.RecordModelId == id).FirstOrDefaultAsync();
            Pacient.Age = age;

            return new EmptyResult();
        }*/
    }
}
