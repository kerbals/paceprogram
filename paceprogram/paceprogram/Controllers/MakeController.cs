using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using paceproject.Models;

namespace paceprogram.Controllers
{
    public class MakeController : ControllerBase
    {
        private ServerDocDB db = new ServerDocDB();

        //
        // GET: /Make/

        public ActionResult Index()
        {
            return View(db.Makes.ToList());
        }

        //
        // GET: /Make/Details/5

        public ActionResult Details(int id = 0)
        {
            Make make = db.Makes.Find(id);
            if (make == null)
            {
                return HttpNotFound();
            }
            return View(make);
        }

        //
        // GET: /Make/Create
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Make/Create
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Make make)
        {
            if (ModelState.IsValid)
            {
                db.Makes.Add(make);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(make);
        }

        //
        // GET: /Make/Edit/5
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Edit(int id = 0)
        {
            Make make = db.Makes.Find(id);
            if (make == null)
            {
                return HttpNotFound();
            }
            return View(make);
        }

        //
        // POST: /Make/Edit/5
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                db.Entry(make).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(make);
        }

        //
        // GET: /Make/Delete/5
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Delete(int id = 0)
        {
            Make make = db.Makes.Find(id);
            if (make == null)
            {
                return HttpNotFound();
            }
            return View(make);
        }

        //
        // POST: /Make/Delete/5
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Make make = db.Makes.Find(id);
            db.Makes.Remove(make);
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