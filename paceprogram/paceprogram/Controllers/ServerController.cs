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
    public class ServerController : ControllerBase
    {
        private ServerDocDB db = new ServerDocDB();

        //
        // GET: /Server/

        public ActionResult Index()
        {
            var servers = db.Servers.Include(s => s.Infrastructure).Include(s => s.Department);
            return View(servers.ToList());
        }

        //
        // GET: /Server/Details/5

        public ActionResult Details(int id = 0)
        {
            Server server = db.Servers.Find(id);
            if (server == null)
            {
                return HttpNotFound();
            }
            return View(server);
        }

        //
        // GET: /Server/Create
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Create()
        {
            ViewBag.InfrastructureID = new SelectList(db.Infrastructures, "InfrastructureID", "InfrastructureName");
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            return View();
        }

        //
        // POST: /Server/Create
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Server server)
        {
            if (ModelState.IsValid)
            {
                db.Servers.Add(server);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InfrastructureID = new SelectList(db.Infrastructures, "InfrastructureID", "InfrastructureName", server.InfrastructureID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", server.DepartmentID);
            return View(server);
        }

        //
        // GET: /Server/Edit/5
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Edit(int id = 0)
        {
            Server server = db.Servers.Find(id);
            if (server == null)
            {
                return HttpNotFound();
            }
            ViewBag.InfrastructureID = new SelectList(db.Infrastructures, "InfrastructureID", "InfrastructureName", server.InfrastructureID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", server.DepartmentID);
            return View(server);
        }

        //
        // POST: /Server/Edit/5
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Server server)
        {
            if (ModelState.IsValid)
            {
                db.Entry(server).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InfrastructureID = new SelectList(db.Infrastructures, "InfrastructureID", "InfrastructureName", server.InfrastructureID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", server.DepartmentID);
            return View(server);
        }

        //
        // GET: /Server/Delete/5
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Delete(int id = 0)
        {
            Server server = db.Servers.Find(id);
            if (server == null)
            {
                return HttpNotFound();
            }
            return View(server);
        }

        //
        // POST: /Server/Delete/5
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Server server = db.Servers.Find(id);
            db.Servers.Remove(server);
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