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
    public class HairController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hair
        public ActionResult Index()
        {
            return View(db.Hairs.ToList());
        }

        // GET: Hair/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hair hair = db.Hairs.Find(id);
            if (hair == null)
            {
                return HttpNotFound();
            }
            return View(hair);
        }

        // GET: Hair/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hair/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HairID,Width,X1,X2,Y1,Y2")] Hair hair)
        {
            if (ModelState.IsValid)
            {
                db.Hairs.Add(hair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hair);
        }

        // GET: Hair/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hair hair = db.Hairs.Find(id);
            if (hair == null)
            {
                return HttpNotFound();
            }
            return View(hair);
        }

        // POST: Hair/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HairID,Width,X1,X2,Y1,Y2")] Hair hair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hair);
        }

        // GET: Hair/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hair hair = db.Hairs.Find(id);
            if (hair == null)
            {
                return HttpNotFound();
            }
            return View(hair);
        }

        // POST: Hair/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hair hair = db.Hairs.Find(id);
            db.Hairs.Remove(hair);
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
