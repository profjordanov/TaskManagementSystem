using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models.EntityModels;

namespace TaskManagementSystem.Web.Controllers
{
    public class JobAds3Controller : ApiController
    {
        private TaskManagementSystemContext db = new TaskManagementSystemContext();

        // GET: api/JobAds3
        public IQueryable<JobAd> GetJobAds()
        {
            return db.JobAds;
        }

        // GET: api/JobAds3/5
        [ResponseType(typeof(JobAd))]
        public IHttpActionResult GetJobAd(int id)
        {
            JobAd jobAd = db.JobAds.Find(id);
            if (jobAd == null)
            {
                return NotFound();
            }

            return Ok(jobAd);
        }

        // PUT: api/JobAds3/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobAd(int id, JobAd jobAd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobAd.Id)
            {
                return BadRequest();
            }

            db.Entry(jobAd).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobAdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/JobAds3
        [ResponseType(typeof(JobAd))]
        public IHttpActionResult PostJobAd(JobAd jobAd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JobAds.Add(jobAd);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jobAd.Id }, jobAd);
        }

        // DELETE: api/JobAds3/5
        [ResponseType(typeof(JobAd))]
        public IHttpActionResult DeleteJobAd(int id)
        {
            JobAd jobAd = db.JobAds.Find(id);
            if (jobAd == null)
            {
                return NotFound();
            }

            db.JobAds.Remove(jobAd);
            db.SaveChanges();

            return Ok(jobAd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobAdExists(int id)
        {
            return db.JobAds.Count(e => e.Id == id) > 0;
        }
    }
}