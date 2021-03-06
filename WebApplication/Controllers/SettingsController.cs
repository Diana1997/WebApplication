﻿using System;
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
    public class SettingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Settings
        public ActionResult Index()
        {
            var settings = db.Settings.Include(s => s.HairSizeSettings).Include(s => s.StatisticalSettings);
            return View(settings.ToList());
        }

        // GET: Settings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // GET: Settings/Create
        public ActionResult Create()
        {
            ViewBag.HairSizeSettingsID = new SelectList(db.HairSizeSettings, "HairSizeSettingsID", "HairSizeSettingsID");
            ViewBag.StatisticalSettingsID = new SelectList(db.StatisticalSettings, "StatisticalSettingsID", "StatisticalSettingsID");
            return View();
        }

        // POST: Settings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SettingsID,HairSizeSettingsID,StatisticalSettingsID")] Setting setting)
        {
            if (ModelState.IsValid)
            {
                db.Settings.Add(setting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HairSizeSettingsID = new SelectList(db.HairSizeSettings, "HairSizeSettingsID", "HairSizeSettingsID", setting.HairSizeSettingsID);
            ViewBag.StatisticalSettingsID = new SelectList(db.StatisticalSettings, "StatisticalSettingsID", "StatisticalSettingsID", setting.StatisticalSettingsID);
            return View(setting);
        }

        // GET: Settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            ViewBag.HairSizeSettingsID = new SelectList(db.HairSizeSettings, "HairSizeSettingsID", "HairSizeSettingsID", setting.HairSizeSettingsID);
            ViewBag.StatisticalSettingsID = new SelectList(db.StatisticalSettings, "StatisticalSettingsID", "StatisticalSettingsID", setting.StatisticalSettingsID);
            return View(setting);
        }

        // POST: Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SettingsID,HairSizeSettingsID,StatisticalSettingsID")] Setting setting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HairSizeSettingsID = new SelectList(db.HairSizeSettings, "HairSizeSettingsID", "HairSizeSettingsID", setting.HairSizeSettingsID);
            ViewBag.StatisticalSettingsID = new SelectList(db.StatisticalSettings, "StatisticalSettingsID", "StatisticalSettingsID", setting.StatisticalSettingsID);
            return View(setting);
        }

        // GET: Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Setting setting = db.Settings.Find(id);
            db.Settings.Remove(setting);
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
