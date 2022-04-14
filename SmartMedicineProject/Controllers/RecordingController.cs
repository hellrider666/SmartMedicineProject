using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicineProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMedicineProject.ViewModels;

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
               PhoneNumber = _PhoneNumber,
               RecordDate = date.ToShortDateString()
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
    }
}
