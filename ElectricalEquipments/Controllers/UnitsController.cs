using ElectricalEquipments.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricalEquipments.Controllers
{
    public class UnitsController : Controller
    {
        private readonly AppDbContext _db;

        public UnitsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Units.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Unit unit)
        {

            if (ModelState.IsValid)
            {
                _db.Add(unit);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_db.Units.Find(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Unit unit = _db.Units.Find(id);
            _db.Remove(unit);
            _db.SaveChanges();
            return RedirectToAction("Index", "Units");
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            return View(_db.Units.Find(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Unit unit)
        {
            if(ModelState.IsValid)
            {
                _db.Update(unit);
                _db.SaveChanges();
                return RedirectToAction("Index", "Units");
            }

            return View();
        }
    }
}
