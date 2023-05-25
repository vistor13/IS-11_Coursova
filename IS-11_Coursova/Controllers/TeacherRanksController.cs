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
    public class TeacherRanksController : Controller
    {
        private CoursovaEntities db = new CoursovaEntities();

        // GET: TeacherRanks
        public ActionResult Index()
        {
            return View(db.TeacherRank.ToList());
        }

        // GET: TeacherRanks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherRank teacherRank = db.TeacherRank.Find(id);
            if (teacherRank == null)
            {
                return HttpNotFound();
            }
            return View(teacherRank);
        }

        // GET: TeacherRanks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherRanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherRankId,Name")] TeacherRank teacherRank)
        {
            if (ModelState.IsValid)
            {
                db.TeacherRank.Add(teacherRank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherRank);
        }

        // GET: TeacherRanks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherRank teacherRank = db.TeacherRank.Find(id);
            if (teacherRank == null)
            {
                return HttpNotFound();
            }
            return View(teacherRank);
        }

        // POST: TeacherRanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherRankId,Name")] TeacherRank teacherRank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherRank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherRank);
        }

        // GET: TeacherRanks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherRank teacherRank = db.TeacherRank.Find(id);
            if (teacherRank == null)
            {
                return HttpNotFound();
            }
            return View(teacherRank);
        }

        // POST: TeacherRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherRank teacherRank = db.TeacherRank.Find(id);
            db.TeacherRank.Remove(teacherRank);
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
