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
    public class HairSizeSettingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HairSizeSettings
        public ActionResult Index()
        {
            return View(db.HairSizeSettings.ToList());
        }

        // GET: HairSizeSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairSizeSettings hairSizeSettings = db.HairSizeSettings.Find(id);
            if (hairSizeSettings == null)
            {
                return HttpNotFound();
            }
            return View(hairSizeSettings);
        }

        // GET: HairSizeSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HairSizeSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HairSizeSettingsID,LengthOfTelogenHair,DiameterOfVelusTerminal,DiameterOfTerminalsThinMedium,DiameterOfTerminalsMediumThick,RadiusOfFollicularUnits")] HairSizeSettings hairSizeSettings)
        {
            if (ModelState.IsValid)
            {
                db.HairSizeSettings.Add(hairSizeSettings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hairSizeSettings);
        }

        // GET: HairSizeSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairSizeSettings hairSizeSettings = db.HairSizeSettings.Find(id);
            if (hairSizeSettings == null)
            {
                return HttpNotFound();
            }
            return View(hairSizeSettings);
        }

        // POST: HairSizeSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HairSizeSettingsID,LengthOfTelogenHair,DiameterOfVelusTerminal,DiameterOfTerminalsThinMedium,DiameterOfTerminalsMediumThick,RadiusOfFollicularUnits")] HairSizeSettings hairSizeSettings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hairSizeSettings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hairSizeSettings);
        }

        // GET: HairSizeSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairSizeSettings hairSizeSettings = db.HairSizeSettings.Find(id);
            if (hairSizeSettings == null)
            {
                return HttpNotFound();
            }
            return View(hairSizeSettings);
        }

        // POST: HairSizeSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HairSizeSettings hairSizeSettings = db.HairSizeSettings.Find(id);
            db.HairSizeSettings.Remove(hairSizeSettings);
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
