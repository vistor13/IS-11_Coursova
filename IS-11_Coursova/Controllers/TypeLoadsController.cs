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
    public class TypeLoadsController : Controller
    {
        private CoursovaEntities db = new CoursovaEntities();

        // GET: TypeLoads
        public ActionResult Index()
        {
            return View(db.TypeLoad.ToList());
        }

        // GET: TypeLoads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeLoad typeLoad = db.TypeLoad.Find(id);
            if (typeLoad == null)
            {
                return HttpNotFound();
            }
            return View(typeLoad);
        }

        // GET: TypeLoads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeLoads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeLoadID,Name")] TypeLoad typeLoad)
        {
            if (ModelState.IsValid)
            {
                db.TypeLoad.Add(typeLoad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeLoad);
        }

        // GET: TypeLoads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeLoad typeLoad = db.TypeLoad.Find(id);
            if (typeLoad == null)
            {
                return HttpNotFound();
            }
            return View(typeLoad);
        }

        // POST: TypeLoads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeLoadID,Name")] TypeLoad typeLoad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeLoad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeLoad);
        }

        // GET: TypeLoads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeLoad typeLoad = db.TypeLoad.Find(id);
            if (typeLoad == null)
            {
                return HttpNotFound();
            }
            return View(typeLoad);
        }

        // POST: TypeLoads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeLoad typeLoad = db.TypeLoad.Find(id);
            db.TypeLoad.Remove(typeLoad);
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
