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
    public class CommentOnTheVisitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CommentOnTheVisits
        public ActionResult Index()
        {
            return View(db.CommentOnTheVisits.ToList());
        }

        // GET: CommentOnTheVisits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentOnTheVisit commentOnTheVisit = db.CommentOnTheVisits.Find(id);
            if (commentOnTheVisit == null)
            {
                return HttpNotFound();
            }
            return View(commentOnTheVisit);
        }

        // GET: CommentOnTheVisits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentOnTheVisits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentOnTheVisitID,TypeOfComment,Comment")] CommentOnTheVisit commentOnTheVisit)
        {
            if (ModelState.IsValid)
            {
                db.CommentOnTheVisits.Add(commentOnTheVisit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commentOnTheVisit);
        }

        // GET: CommentOnTheVisits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentOnTheVisit commentOnTheVisit = db.CommentOnTheVisits.Find(id);
            if (commentOnTheVisit == null)
            {
                return HttpNotFound();
            }
            return View(commentOnTheVisit);
        }

        // POST: CommentOnTheVisits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentOnTheVisitID,TypeOfComment,Comment")] CommentOnTheVisit commentOnTheVisit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentOnTheVisit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commentOnTheVisit);
        }

        // GET: CommentOnTheVisits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentOnTheVisit commentOnTheVisit = db.CommentOnTheVisits.Find(id);
            if (commentOnTheVisit == null)
            {
                return HttpNotFound();
            }
            return View(commentOnTheVisit);
        }

        // POST: CommentOnTheVisits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentOnTheVisit commentOnTheVisit = db.CommentOnTheVisits.Find(id);
            db.CommentOnTheVisits.Remove(commentOnTheVisit);
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
