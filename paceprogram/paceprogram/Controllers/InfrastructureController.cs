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
    public class InfrastructureController : Controller
    {
        private ServerDocDB db = new ServerDocDB();

        //
        // GET: /Infrastructure/

        public ActionResult Index()
        {
            var infrastructures = db.Infrastructures.Include(i => i.Room).Include(i => i.Equipment).Include(i => i.Department).Include(i => i.Make);
            return View(infrastructures.ToList());
        }

        //
        // GET: /Infrastructure/Details/5

        public ActionResult Details(int id = 0)
        {
            Infrastructure infrastructure = db.Infrastructures.Find(id);
            if (infrastructure == null)
            {
                return HttpNotFound();
            }
            return View(infrastructure);
        }

        //
        // GET: /Infrastructure/Create

        public ActionResult Create()
        {
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomName");
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentCategory");
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "MakeName");
            return View();
        }

        //
        // POST: /Infrastructure/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Infrastructure infrastructure)
        {
            if (ModelState.IsValid)
            {
                db.Infrastructures.Add(infrastructure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomName", infrastructure.RoomID);
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentCategory", infrastructure.EquipmentID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", infrastructure.DepartmentID);
            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "MakeName", infrastructure.MakeID);
            return View(infrastructure);
        }

        //
        // GET: /Infrastructure/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Infrastructure infrastructure = db.Infrastructures.Find(id);
            if (infrastructure == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomName", infrastructure.RoomID);
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentCategory", infrastructure.EquipmentID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", infrastructure.DepartmentID);
            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "MakeName", infrastructure.MakeID);
            return View(infrastructure);
        }

        //
        // POST: /Infrastructure/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Infrastructure infrastructure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infrastructure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomName", infrastructure.RoomID);
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentCategory", infrastructure.EquipmentID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", infrastructure.DepartmentID);
            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "MakeName", infrastructure.MakeID);
            return View(infrastructure);
        }

        //
        // GET: /Infrastructure/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Infrastructure infrastructure = db.Infrastructures.Find(id);
            if (infrastructure == null)
            {
                return HttpNotFound();
            }
            return View(infrastructure);
        }

        //
        // POST: /Infrastructure/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Infrastructure infrastructure = db.Infrastructures.Find(id);
            db.Infrastructures.Remove(infrastructure);
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