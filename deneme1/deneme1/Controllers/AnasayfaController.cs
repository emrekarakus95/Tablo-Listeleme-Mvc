using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using deneme1.Models;
using deneme1.Models.Entity;


namespace deneme1.Controllers
{
    public class AnasayfaController : Controller
    {
        yazokuluEntities1 db = new yazokuluEntities1();
        

        
        public ActionResult index()
        {
            var deger = db.ogrtbl.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult kayıtekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kayıtekle(ogrtbl ogrtbl)
        {
            if (!ModelState.IsValid)
            {
                return View("kayıtekle",new ogrtbl());
            }
            if (ogrtbl.id == 0)
            {
                db.ogrtbl.Add(ogrtbl);
            }
            else
            {
                var güncellenecek = db.ogrtbl.Find(ogrtbl.id);
                if (güncellenecek == null)
                    return HttpNotFound();
                güncellenecek.ad = ogrtbl.ad;
                güncellenecek.soyad = ogrtbl.soyad;
                güncellenecek.ogrno = ogrtbl.ogrno;
            }
            db.SaveChanges();
           return RedirectToAction("index");
        }
        public ActionResult Hakkında()
        {
            return View();
        }
        public ActionResult güncelle(int id)
        {
            var model = db.ogrtbl.Find(id);
            if (id == 0)
                return HttpNotFound();
            return View("kayıtekle",model);
        }
        public ActionResult sil(int id)
        {
            var silinecek = db.ogrtbl.Find(id);
            if (silinecek == null)
                return HttpNotFound();
            db.ogrtbl.Remove(silinecek);
            db.SaveChanges();


            return RedirectToAction("index");
        }
    }
}