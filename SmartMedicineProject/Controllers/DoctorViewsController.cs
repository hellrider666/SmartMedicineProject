using Microsoft.AspNetCore.Mvc;
using SmartMedicineProject.Models;
using SmartMedicineProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace SmartMedicineProject.Controllers
{
    public class DoctorViewsController : Controller
    {
        
        private SMAppContext db;
        public DoctorViewsController(SMAppContext context)
        {
            db = context;
          
        }
       
        public IActionResult MainView()
        {
            string Iden = User.Identity.Name;
            var Doctor = db.doctorUsers.Where(u => u.Email == Iden).Include(p=>p.RoleModel).FirstOrDefault();
            MainViewModel mainViewModel = new MainViewModel
            {
                FullName = Doctor.Surname + " " + Doctor.Name + " " + Doctor.Patronymic,
                Role = Doctor.RoleModel.Name
            };

            return View(mainViewModel);
        }
    }
}
