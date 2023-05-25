using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IS_11_Coursova.Models;

namespace IS_11_Coursova.Controllers
{
    public class LoadsController : Controller
    {
        private CoursovaEntities db = new CoursovaEntities();

        // GET: Loads
        public ActionResult Index()
        {
            var load = db.Load.Include(l => l.Discipline).Include(l => l.Teacher).Include(l => l.TypeLoad);
            return View(load.ToList());
        }

        // GET: Loads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Load load = db.Load.Find(id);
            if (load == null)
            {
                return HttpNotFound();
            }
            return View(load);
        }

        // GET: Loads/Create
        public ActionResult Create()
        {
            ViewBag.DisciplineID = new SelectList(db.Discipline, "DisciplineID", "Name");
            ViewBag.TeacherID = new SelectList(db.Teacher, "TeacherID", "Full_Name");
            ViewBag.TypeLoadID = new SelectList(db.TypeLoad, "TypeLoadID", "Name");
            return View();
        }

        // POST: Loads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoadID,TeacherID,DisciplineID,TypeLoadID,Hours")] Load load)
        {
            if (ModelState.IsValid)
            {
                db.Load.Add(load);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisciplineID = new SelectList(db.Discipline, "DisciplineID", "Name", load.DisciplineID);
            ViewBag.TeacherID = new SelectList(db.Teacher, "TeacherID", "Full_Name", load.TeacherID);
            ViewBag.TypeLoadID = new SelectList(db.TypeLoad, "TypeLoadID", "Name", load.TypeLoadID);
            return View(load);
        }

        // GET: Loads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Load load = db.Load.Find(id);
            if (load == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisciplineID = new SelectList(db.Discipline, "DisciplineID", "Name", load.DisciplineID);
            ViewBag.TeacherID = new SelectList(db.Teacher, "TeacherID", "Full_Name", load.TeacherID);
            ViewBag.TypeLoadID = new SelectList(db.TypeLoad, "TypeLoadID", "Name", load.TypeLoadID);
            return View(load);
        }

        // POST: Loads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoadID,TeacherID,DisciplineID,TypeLoadID,Hours")] Load load)
        {
            if (ModelState.IsValid)
            {
                db.Entry(load).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisciplineID = new SelectList(db.Discipline, "DisciplineID", "Name", load.DisciplineID);
            ViewBag.TeacherID = new SelectList(db.Teacher, "TeacherID", "Full_Name", load.TeacherID);
            ViewBag.TypeLoadID = new SelectList(db.TypeLoad, "TypeLoadID", "Name", load.TypeLoadID);
            return View(load);
        }

        // GET: Loads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Load load = db.Load.Find(id);
            if (load == null)
            {
                return HttpNotFound();
            }
            return View(load);
        }

        // POST: Loads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Load load = db.Load.Find(id);
            db.Load.Remove(load);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
