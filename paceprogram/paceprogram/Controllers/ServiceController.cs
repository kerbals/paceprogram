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
    public class ServiceController : ControllerBase
    {
        private ServerDocDB db = new ServerDocDB();

        //
        // GET: /Service/

        public ActionResult Index()
        {
            var services = db.Services.Include(s => s.Department).Include(s => s.Server);
            return View(services.ToList());
        }

        //
        // GET: /Service/Details/5

        public ActionResult Details(int id = 0)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        //
        // GET: /Service/Create
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.ServerID = new SelectList(db.Servers, "ServerID", "ServerName");
            return View();
        }

        //
        // POST: /Service/Create
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", service.DepartmentID);
            ViewBag.ServerID = new SelectList(db.Servers, "ServerID", "ServerName", service.ServerID);
            return View(service);
        }

        //
        // GET: /Service/Edit/5
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Edit(int id = 0)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", service.DepartmentID);
            ViewBag.ServerID = new SelectList(db.Servers, "ServerID", "ServerName", service.ServerID);
            return View(service);
        }

        //
        // POST: /Service/Edit/5
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", service.DepartmentID);
            ViewBag.ServerID = new SelectList(db.Servers, "ServerID", "ServerName", service.ServerID);
            return View(service);
        }

        //
        // GET: /Service/Delete/5
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Delete(int id = 0)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        //
        // POST: /Service/Delete/5
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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