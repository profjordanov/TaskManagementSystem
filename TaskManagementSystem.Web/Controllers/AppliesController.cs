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
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Web.Controllers
{
    public class AppliesController : Controller
    {
        private AppliesService service;

        public AppliesController()
        {
            this.service = new AppliesService();
        }
        private TaskManagementSystemContext db = new TaskManagementSystemContext();

        // GET: Applies
        public async Task<ActionResult> Index()
        {
            var applies = await this.service.GetAllAppliesAsync();

            return View(applies);
        }

        // GET: Applies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Apply apply = await this.service.GetApplyAsync(id);

            if (apply == null)
            {
                return HttpNotFound();
            }
            return View(apply);
        }

        // GET: Applies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ApplyStatus")] Apply apply)
        {
            if (ModelState.IsValid)
            {
                db.Applies.Add(apply);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(apply);
        }

        // GET: Applies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apply apply = await db.Applies.FindAsync(id);
            if (apply == null)
            {
                return HttpNotFound();
            }
            return View(apply);
        }

        // POST: Applies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ApplyStatus")] Apply apply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apply).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(apply);
        }

        // GET: Applies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apply apply = await db.Applies.FindAsync(id);
            if (apply == null)
            {
                return HttpNotFound();
            }
            return View(apply);
        }

        // POST: Applies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Apply apply = await db.Applies.FindAsync(id);
            db.Applies.Remove(apply);
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
