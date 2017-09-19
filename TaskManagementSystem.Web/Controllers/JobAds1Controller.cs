using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models.EntityModels;

namespace TaskManagementSystem.Web.Controllers
{
    public class JobAds1Controller : Controller
    {
        private TaskManagementSystemContext db = new TaskManagementSystemContext();

        // GET: JobAds1
        public ActionResult Index()
        {
            return View(db.JobAds.ToList());
        }

        // GET: JobAds1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAd jobAd = db.JobAds.Find(id);
            if (jobAd == null)
            {
                return HttpNotFound();
            }
            return View(jobAd);
        }

        // GET: JobAds1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobAds1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Position,ImageUrl,StudentProfile,Location,CreateOn,ValidUntil,Description,IsDeleted")] JobAd jobAd)
        {
            if (ModelState.IsValid)
            {
                db.JobAds.Add(jobAd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobAd);
        }

        // GET: JobAds1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAd jobAd = db.JobAds.Find(id);
            if (jobAd == null)
            {
                return HttpNotFound();
            }
            return View(jobAd);
        }

        // POST: JobAds1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Position,ImageUrl,StudentProfile,Location,CreateOn,ValidUntil,Description,IsDeleted")] JobAd jobAd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobAd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobAd);
        }

        // GET: JobAds1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAd jobAd = db.JobAds.Find(id);
            if (jobAd == null)
            {
                return HttpNotFound();
            }
            return View(jobAd);
        }

        // POST: JobAds1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobAd jobAd = db.JobAds.Find(id);
            db.JobAds.Remove(jobAd);
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
