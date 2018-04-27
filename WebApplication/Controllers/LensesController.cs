using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LensesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lenses
        public ActionResult Index()
        {
            return View(db.Lenses.ToList());
        }

        // GET: Lenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lens lens = db.Lenses.Find(id);
            if (lens == null)
            {
                return HttpNotFound();
            }
            return View(lens);
        }

        // GET: Lenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LensID,Name,Scale")] Lens lens)
        {
            if (ModelState.IsValid)
            {
                db.Lenses.Add(lens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lens);
        }

        // GET: Lenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lens lens = db.Lenses.Find(id);
            if (lens == null)
            {
                return HttpNotFound();
            }
            return View(lens);
        }

        // POST: Lenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LensID,Name,Scale")] Lens lens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lens);
        }

        // GET: Lenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lens lens = db.Lenses.Find(id);
            if (lens == null)
            {
                return HttpNotFound();
            }
            return View(lens);
        }

        // POST: Lenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lens lens = db.Lenses.Find(id);
            db.Lenses.Remove(lens);
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
