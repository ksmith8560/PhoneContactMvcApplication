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
    public class AddressController : Controller
    {
        private PhoneContactMvcApplicationContext db = new PhoneContactMvcApplicationContext();

        //
        // GET: /Address/

        public ActionResult Index()
        {
            var addresses = db.Addresses.Include(a => a.People).Include(a => a.AddressTypes);
            return View(addresses.ToList());
        }

        //
        // GET: /Address/Details/5

        public ActionResult Details(int id = 0)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // GET: /Address/Create

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
            ViewBag.AddressTypeID = new SelectList(db.AddressTypes, "AddressTypeID", "Type");
            return View();
        }

        //
        // POST: /Address/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Details", "Person", new { id = address.PersonID });
            }

            ViewBag.PersonID = new SelectList(db.People, "PersonID", "First", address.PersonID);
            ViewBag.AddressTypeID = new SelectList(db.AddressTypes, "AddressTypeID", "Type", address.AddressTypeID);
            return View(address);
        }

        //
        // GET: /Address/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "First", address.PersonID);
            ViewBag.AddressTypeID = new SelectList(db.AddressTypes, "AddressTypeID", "Type", address.AddressTypeID);
            return View(address);
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Person", new { id = address.PersonID });
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "First", address.PersonID);
            ViewBag.AddressTypeID = new SelectList(db.AddressTypes, "AddressTypeID", "Type", address.AddressTypeID);
            return View(address);
        }

        //
        // GET: /Address/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // POST: /Address/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
            db.SaveChanges();
            return RedirectToAction("Details", "Person", new { id = address.PersonID });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}