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
    public class FieldOptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FieldOptions
        public ActionResult Index()
        {
            return View(db.FieldOptions.ToList());
        }

        // GET: FieldOptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOption fieldOption = db.FieldOptions.Find(id);
            if (fieldOption == null)
            {
                return HttpNotFound();
            }
            return View(fieldOption);
        }

        // GET: FieldOptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FieldOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FieldOptionID,Title,Selected,Text")] FieldOption fieldOption)
        {
            if (ModelState.IsValid)
            {
                db.FieldOptions.Add(fieldOption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fieldOption);
        }

        // GET: FieldOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOption fieldOption = db.FieldOptions.Find(id);
            if (fieldOption == null)
            {
                return HttpNotFound();
            }
            return View(fieldOption);
        }

        // POST: FieldOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FieldOptionID,Title,Selected,Text")] FieldOption fieldOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fieldOption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fieldOption);
        }

        // GET: FieldOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOption fieldOption = db.FieldOptions.Find(id);
            if (fieldOption == null)
            {
                return HttpNotFound();
            }
            return View(fieldOption);
        }

        // POST: FieldOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FieldOption fieldOption = db.FieldOptions.Find(id);
            db.FieldOptions.Remove(fieldOption);
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
