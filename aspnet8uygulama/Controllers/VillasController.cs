﻿using DataAccessLayer.Data;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace aspnet8uygulama.Controllers
{
    public class VillasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var villas=_context.Villas.ToList();
            return View(villas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa villa)
        { 
            if(ModelState.IsValid) {
                _context.Villas.Add(villa);
                _context.SaveChanges();
                TempData["success"] = "Kayıt Başarılı Yeni Kayıt Yapıldı";
                return RedirectToAction("Index");
            }
            return View();
            
        }
        [HttpGet]
        public IActionResult Edit(int villaId)
        {
            Villa? obj=_context.Villas.FirstOrDefault(x => x.Id == villaId);    
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(Villa gelen)
        {
            Villa? tablo=_context.Villas.FirstOrDefault(x=>x.Id== gelen.Id);
            if(tablo==null)
            {
                return NotFound();  
            }
            else
            {
                if(ModelState.IsValid && gelen.Id>0 )
                {
                    tablo.Name= gelen.Name;
                    tablo.Occupancy= gelen.Occupancy;
                    tablo.Price = gelen.Price;
                    tablo.Description = gelen.Description;
                    _context.Villas.Update(tablo);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt Başarılı Düzeltildi";
                    return RedirectToAction("Index");
                }
               
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int villaId)
        {
            Villa? obj = _context.Villas.FirstOrDefault(x => x.Id == villaId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Index");
            }
            return View(obj);

        }

        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            Villa? obj = _context.Villas.FirstOrDefault(x => x.Id == villa.Id);
            if (obj == null)
            {
                return NotFound();
            }
           
               
                    _context.Villas.Remove(obj);
                    _context.SaveChanges();
                   TempData["success"] = "Kayıt Başarılı Şekilde Silindi";
                    return RedirectToAction("Index");
               

          
            
        }
    }
}
