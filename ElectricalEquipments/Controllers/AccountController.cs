using ElectricalEquipments.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricalEquipments.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _db;

        public AccountController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                if(_db.Users.Any(x => x.Username != user.Username || x.Mail != user.Mail)) 
                {
                    _db.Add(user);
                    _db.SaveChanges();
                    ViewBag.registerSuccessMessage = "Kayıt işlemi başarılı. Bilgilerinizi kullanarak giriş yapabilirsiniz.";
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();
        }
    }
}
