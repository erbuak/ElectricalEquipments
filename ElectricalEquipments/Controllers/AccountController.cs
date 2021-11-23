using ElectricalEquipments.Models;
using ElectricalEquipments.ViewModels.Account;
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

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(UserLoginViewModel userLoginViewModel)
        {
            User user = _db.Users.FirstOrDefault(x => x.Mail == userLoginViewModel.Mail && x.Password == userLoginViewModel.Password);
            if (user != null)
            {
                return RedirectToAction("Index", "Units");
            }
            else
            {
                ViewBag.loginFailMessage = "Kullanıcı adı ve/veya şifre yanlış!";
                return View();
            }       
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterViewModel userRegisterViewModel)
        {
            if(ModelState.IsValid)
            {
                if(_db.Users.Any(x => x.Username != userRegisterViewModel.Username || x.Mail != userRegisterViewModel.Mail)) 
                {
                    User user = new User()
                    {
                        Id = userRegisterViewModel.Id,
                        Name = userRegisterViewModel.Name,
                        Surname = userRegisterViewModel.Surname,
                        Username = userRegisterViewModel.Username,
                        Mail = userRegisterViewModel.Mail,
                        Password = userRegisterViewModel.Password
                    };

                    _db.Add(user);
                    _db.SaveChanges();
                    ViewBag.registerSuccessMessage = "Kayıt işlemi başarılı. Bilgilerinizi kullanarak giriş yapabilirsiniz.";
                    return RedirectToAction("Login", "Account");
                } 
                else
                {
                    ViewBag.registerFailMessage = "Kullanıcı adı ve/veya mail bir başkası tarafından kullanılıyor.";
                    return View();
                }
            }
            return View();
        }
    }
}
