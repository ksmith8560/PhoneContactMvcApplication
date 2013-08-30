using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneContactMvcApplication.Models;

namespace PhoneContactMvcApplication.Controllers
{
    public class PhoneTypeController : Controller
    {
        private PhoneContactMvcApplicationContext db = new PhoneContactMvcApplicationContext();

        //
        // GET: /PhoneType/

        public ActionResult Index()
        {
            return View(db.PhoneTypes.ToList());
        }

        //
        // GET: /PhoneType/Details/5

        public ActionResult Details(int id = 0)
        {
            PhoneType phonetype = db.PhoneTypes.Find(id);
            if (phonetype == null)
            {
                return HttpNotFound();
            }
            return View(phonetype);
        }

        //
        // GET: /PhoneType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PhoneType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhoneType phonetype)
        {
            if (ModelState.IsValid)
            {
                db.PhoneTypes.Add(phonetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phonetype);
        }

        //
        // GET: /PhoneType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PhoneType phonetype = db.PhoneTypes.Find(id);
            if (phonetype == null)
            {
                return HttpNotFound();
            }
            return View(phonetype);
        }

        //
        // POST: /PhoneType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhoneType phonetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phonetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phonetype);
        }

        //
        // GET: /PhoneType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PhoneType phonetype = db.PhoneTypes.Find(id);
            if (phonetype == null)
            {
                return HttpNotFound();
            }
            return View(phonetype);
        }

        //
        // POST: /PhoneType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneType phonetype = db.PhoneTypes.Find(id);
            db.PhoneTypes.Remove(phonetype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}