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
    public class PhoneController : Controller
    {
        private PhoneContactMvcApplicationContext db = new PhoneContactMvcApplicationContext();

        //
        // GET: /Phone/

        public ActionResult Index()
        {
            var phones = db.Phones.Include(p => p.People).Include(p => p.PhoneTypes);
            return View(phones.ToList());
        }

        //
        // GET: /Phone/Details/5

        public ActionResult Details(int id = 0)
        {
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        //
        // GET: /Phone/Create

        public ActionResult Create(int? personId)
        {
            if (personId != null)
            {
                ViewBag.PersonID = new SelectList(db.People, "PersonID", "First", personId);
            }
            else
            {
                ViewBag.PersonID = new SelectList(db.People, "PersonID", "First");
            }
            
            ViewBag.PhoneTypeID = new SelectList(db.PhoneTypes, "PhoneTypeID", "Type");
            return View();
        }

        //
        // POST: /Phone/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Phones.Add(phone);
                db.SaveChanges();
                return RedirectToAction("Details","Person",new{id = phone.PersonID});
            }

            ViewBag.PersonID = new SelectList(db.People, "PersonID", "First", phone.PersonID);
            ViewBag.PhoneTypeID = new SelectList(db.PhoneTypes, "PhoneTypeID", "Type", phone.PhoneTypeID);
            return View(phone);
        }

        //
        // GET: /Phone/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "First", phone.PersonID);
            ViewBag.PhoneTypeID = new SelectList(db.PhoneTypes, "PhoneTypeID", "Type", phone.PhoneTypeID);
            return View(phone);
        }

        //
        // POST: /Phone/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Person", new { id = phone.PersonID });
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "First", phone.PersonID);
            ViewBag.PhoneTypeID = new SelectList(db.PhoneTypes, "PhoneTypeID", "Type", phone.PhoneTypeID);
            return View(phone);
        }

        //
        // GET: /Phone/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        //
        // POST: /Phone/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phone phone = db.Phones.Find(id);
            db.Phones.Remove(phone);
            db.SaveChanges();
            return RedirectToAction("Details", "Person", new { id = phone.PersonID });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}