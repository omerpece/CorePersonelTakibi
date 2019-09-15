using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _CorePersonelTakibi.Models;
using Microsoft.AspNetCore.Mvc;

namespace _CorePersonelTakibi.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            var kisi = PersonelRepository.Kisis;
            return View(kisi);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Kisi kisi)
        {
            PersonelRepository.Add(kisi);
            return View("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return View("Error");
            }
            var kisi = PersonelRepository.GetByKisiId(id.Value);
            if (kisi == null)
            {
                return NotFound();
            }
            return View(kisi);
        }
        [HttpPost]
        public IActionResult Edit(Kisi kisi)
        {
            if (kisi.KisiId == 0)
            {
                return View("Error");
            }
            var update = PersonelRepository.GetByKisiId(kisi.KisiId);
            update.FirstName = kisi.FirstName;
            update.LastName = kisi.LastName;
            update.Mail = kisi.Mail;
            update.PhoneNumber = kisi.PhoneNumber;
            update.Gender = kisi.Gender;
            update.Department = kisi.Department;

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return View("Error");
            }
            var kisi = PersonelRepository.GetByKisiId(id.Value);
            PersonelRepository.Delete(kisi);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Kisi kisi)
        {
            return View();
        }


    }
}