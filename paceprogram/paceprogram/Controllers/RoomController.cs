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
    public class RoomController : ControllerBase
    {
        private ServerDocDB db = new ServerDocDB();

        //
        // GET: /Room/

        public ActionResult Index()
        {
            return View(db.Rooms.ToList());
        }

        //
        // GET: /Room/Details/5

        public ActionResult Details(int id = 0)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // GET: /Room/Create
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Room/Create
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room);
        }

        //
        // GET: /Room/Edit/5
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Edit(int id = 0)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // POST: /Room/Edit/5
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }

        //
        // GET: /Room/Delete/5
        [Authorize(Roles = "admin", Users = "test")]
        public ActionResult Delete(int id = 0)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // POST: /Room/Delete/5
        [Authorize(Roles = "admin", Users = "test")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
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