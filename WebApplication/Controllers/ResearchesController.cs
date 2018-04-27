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
    public class ResearchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Researches
        public ActionResult Index()
        {
            var researches = db.Researchs.Include(r => r.Diagnostic).Include(r => r.Hair).Include(r => r.Image).Include(r => r.Lens);
            return View(researches.ToList());
        }

        // GET: Researches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Research research = db.Researchs.Find(id);
            if (research == null)
            {
                return HttpNotFound();
            }
            return View(research);
        }

        // GET: Researches/Create
        public ActionResult Create()
        {
            ViewBag.DiagnosticID = new SelectList(db.Diagnostics, "DiagnosticID", "DiagnosticText");
            ViewBag.HairID = new SelectList(db.Hairs, "HairID", "HairID");
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "Title");
            ViewBag.LensID = new SelectList(db.Lenses, "LensID", "Name");
            return View();
        }

        // POST: Researches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResearchID,ResearchType,StateOfTheResearch,Thumbnail,ImageID,HairID,ResearchArea,Comment,ResearchTime,DiagnosticID,Treatment,SettingID,LensID")] Research research)
        {
            if (ModelState.IsValid)
            {
                db.Researchs.Add(research);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiagnosticID = new SelectList(db.Diagnostics, "DiagnosticID", "DiagnosticText", research.DiagnosticID);
            ViewBag.HairID = new SelectList(db.Hairs, "HairID", "HairID", research.HairID);
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "Title", research.ImageID);
            ViewBag.LensID = new SelectList(db.Lenses, "LensID", "Name", research.LensID);
            return View(research);
        }

        // GET: Researches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Research research = db.Researchs.Find(id);
            if (research == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiagnosticID = new SelectList(db.Diagnostics, "DiagnosticID", "DiagnosticText", research.DiagnosticID);
            ViewBag.HairID = new SelectList(db.Hairs, "HairID", "HairID", research.HairID);
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "Title", research.ImageID);
            ViewBag.LensID = new SelectList(db.Lenses, "LensID", "Name", research.LensID);
            return View(research);
        }

        // POST: Researches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResearchID,ResearchType,StateOfTheResearch,Thumbnail,ImageID,HairID,ResearchArea,Comment,ResearchTime,DiagnosticID,Treatment,SettingID,LensID")] Research research)
        {
            if (ModelState.IsValid)
            {
                db.Entry(research).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiagnosticID = new SelectList(db.Diagnostics, "DiagnosticID", "DiagnosticText", research.DiagnosticID);
            ViewBag.HairID = new SelectList(db.Hairs, "HairID", "HairID", research.HairID);
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "Title", research.ImageID);
            ViewBag.LensID = new SelectList(db.Lenses, "LensID", "Name", research.LensID);
            return View(research);
        }

        // GET: Researches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Research research = db.Researchs.Find(id);
            if (research == null)
            {
                return HttpNotFound();
            }
            return View(research);
        }

        // POST: Researches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Research research = db.Researchs.Find(id);
            db.Researchs.Remove(research);
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
