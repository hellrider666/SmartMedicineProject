using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartMedicineProject.Models;
using SmartMedicineProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartMedicineProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private SMAppContext db;
        public HomeController(ILogger<HomeController> logger, SMAppContext context)
        {
            _logger = logger;
            db = context;
        }
        
        public IActionResult Index()
        {

            return View();
        }
       
        public async Task<EmptyResult> Recording (string fullname, string email, string phonenumber, string address)
        {
            RecordModel recordModel = new RecordModel {FullName = fullname, Email = email, PhoneNumber = phonenumber, Address = address };
            await db.recordModels.AddAsync(recordModel);
            PacientMedCart pacientMedCart = new PacientMedCart {RecordModel = recordModel };
            await db.pacientMedCarts.AddAsync(pacientMedCart);
            await db.SaveChangesAsync();
            return new EmptyResult();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
       
    }
}
