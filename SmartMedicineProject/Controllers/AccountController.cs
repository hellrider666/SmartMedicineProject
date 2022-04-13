using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartMedicineProject.Models;
using SmartMedicineProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartMedicineProject.Controllers
{
    public class AccountController : Controller
    {
        private SMAppContext db;
        public AccountController(SMAppContext context)
        {
            db = context;
        }
        
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                DoctorUser user = await db.doctorUsers.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    
                    // добавляем пользователя в бд
                    user = new DoctorUser { Email = model.Email, Password = model.Password, Name = model.Name, Surname = model.Surname, Patronymic = model.Patronymic };
                    RoleModel roleModel = await db.roleModels.FirstOrDefaultAsync(u => u.Name == "Doctor");
                    if (roleModel != null) 
                    {
                        user.RoleModel = roleModel;
                    }
                    db.doctorUsers.Add(user);
                    await db.SaveChangesAsync();

                    
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("MainView", "DoctorViews");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> LogintoAccount(string login, string password)
        {
            bool error = false;
                DoctorUser user = await db.doctorUsers.Include(p => p.RoleModel).FirstOrDefaultAsync(u => u.Email == login && u.Password == password);
                if (user != null)
                {
                    error = true;
                    await Authenticate(user); // аутентификация
                    RedirectToAction("MainView", "DoctorViews");               
                }

            return Json(error);
        }
       
        private async Task Authenticate(DoctorUser user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
               new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleModel?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
