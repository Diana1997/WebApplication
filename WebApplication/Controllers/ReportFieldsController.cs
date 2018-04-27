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
    public class ReportFieldsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReportFields
        public ActionResult Index()
        {
            var reportFields = db.ReportFields.Include(r => r.FieldOption);
            return View(reportFields.ToList());
        }

        // GET: ReportFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportField reportField = db.ReportFields.Find(id);
            if (reportField == null)
            {
                return HttpNotFound();
            }
            return View(reportField);
        }

        // GET: ReportFields/Create
        public ActionResult Create()
        {
            ViewBag.FieldOptionID = new SelectList(db.FieldOptions, "FieldOptionID", "Title");
            return View();
        }

        // POST: ReportFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportFieldID,Name,FieldType,FieldOptionID")] ReportField reportField)
        {
            if (ModelState.IsValid)
            {
                db.ReportFields.Add(reportField);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FieldOptionID = new SelectList(db.FieldOptions, "FieldOptionID", "Title", reportField.FieldOptionID);
            return View(reportField);
        }

        // GET: ReportFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportField reportField = db.ReportFields.Find(id);
            if (reportField == null)
            {
                return HttpNotFound();
            }
            ViewBag.FieldOptionID = new SelectList(db.FieldOptions, "FieldOptionID", "Title", reportField.FieldOptionID);
            return View(reportField);
        }

        // POST: ReportFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportFieldID,Name,FieldType,FieldOptionID")] ReportField reportField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FieldOptionID = new SelectList(db.FieldOptions, "FieldOptionID", "Title", reportField.FieldOptionID);
            return View(reportField);
        }

        // GET: ReportFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportField reportField = db.ReportFields.Find(id);
            if (reportField == null)
            {
                return HttpNotFound();
            }
            return View(reportField);
        }

        // POST: ReportFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportField reportField = db.ReportFields.Find(id);
            db.ReportFields.Remove(reportField);
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
