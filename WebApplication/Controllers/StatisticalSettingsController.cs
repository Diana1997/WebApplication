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
    public class StatisticalSettingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StatisticalSettings
        public ActionResult Index()
        {
            return View(db.StatisticalSettings.ToList());
        }

        // GET: StatisticalSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatisticalSettings statisticalSettings = db.StatisticalSettings.Find(id);
            if (statisticalSettings == null)
            {
                return HttpNotFound();
            }
            return View(statisticalSettings);
        }

        // GET: StatisticalSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatisticalSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatisticalSettingsID,AnagenAll,TelogenAll,AnagenTerm,TelogenTerm,AnagenVallus,TelogenVallus")] StatisticalSettings statisticalSettings)
        {
            if (ModelState.IsValid)
            {
                db.StatisticalSettings.Add(statisticalSettings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statisticalSettings);
        }

        // GET: StatisticalSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatisticalSettings statisticalSettings = db.StatisticalSettings.Find(id);
            if (statisticalSettings == null)
            {
                return HttpNotFound();
            }
            return View(statisticalSettings);
        }

        // POST: StatisticalSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatisticalSettingsID,AnagenAll,TelogenAll,AnagenTerm,TelogenTerm,AnagenVallus,TelogenVallus")] StatisticalSettings statisticalSettings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statisticalSettings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statisticalSettings);
        }

        // GET: StatisticalSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatisticalSettings statisticalSettings = db.StatisticalSettings.Find(id);
            if (statisticalSettings == null)
            {
                return HttpNotFound();
            }
            return View(statisticalSettings);
        }

        // POST: StatisticalSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatisticalSettings statisticalSettings = db.StatisticalSettings.Find(id);
            db.StatisticalSettings.Remove(statisticalSettings);
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
