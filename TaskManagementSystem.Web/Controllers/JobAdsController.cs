using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models.EntityModels;

namespace TaskManagementSystem.Web.Controllers
{
    public class JobAdsController : Controller
    {
        private TaskManagementSystemContext db = new TaskManagementSystemContext();

        // GET: JobAds
        public async Task<ActionResult> Index()
        {
            return View(await db.JobAds.ToListAsync());
        }

        // GET: JobAds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAd jobAd = await db.JobAds.FindAsync(id);
            if (jobAd == null)
            {
                return HttpNotFound();
            }
            return View(jobAd);
        }

        // GET: JobAds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobAds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Position,ImageUrl,StudentProfile,Location,CreateOn,ValidUntil,Description,IsDeleted")] JobAd jobAd)
        {
            if (ModelState.IsValid)
            {
                db.JobAds.Add(jobAd);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jobAd);
        }

        // GET: JobAds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAd jobAd = await db.JobAds.FindAsync(id);
            if (jobAd == null)
            {
                return HttpNotFound();
            }
            return View(jobAd);
        }

        // POST: JobAds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Position,ImageUrl,StudentProfile,Location,CreateOn,ValidUntil,Description,IsDeleted")] JobAd jobAd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobAd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobAd);
        }

        // GET: JobAds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAd jobAd = await db.JobAds.FindAsync(id);
            if (jobAd == null)
            {
                return HttpNotFound();
            }
            return View(jobAd);
        }

        // POST: JobAds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            JobAd jobAd = await db.JobAds.FindAsync(id);
            db.JobAds.Remove(jobAd);
            await db.SaveChangesAsync();
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
