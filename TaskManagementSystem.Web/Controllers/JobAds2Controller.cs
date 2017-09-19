using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models.EntityModels;

namespace TaskManagementSystem.Web.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using TaskManagementSystem.Models.EntityModels;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<JobAd>("JobAds2");
    builder.EntitySet<Apply>("Applies"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class JobAds2Controller : ODataController
    {
        private TaskManagementSystemContext db = new TaskManagementSystemContext();

        // GET: odata/JobAds2
        [EnableQuery]
        public IQueryable<JobAd> GetJobAds2()
        {
            return db.JobAds;
        }

        // GET: odata/JobAds2(5)
        [EnableQuery]
        public SingleResult<JobAd> GetJobAd([FromODataUri] int key)
        {
            return SingleResult.Create(db.JobAds.Where(jobAd => jobAd.Id == key));
        }

        // PUT: odata/JobAds2(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<JobAd> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JobAd jobAd = await db.JobAds.FindAsync(key);
            if (jobAd == null)
            {
                return NotFound();
            }

            patch.Put(jobAd);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobAdExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(jobAd);
        }

        // POST: odata/JobAds2
        public async Task<IHttpActionResult> Post(JobAd jobAd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JobAds.Add(jobAd);
            await db.SaveChangesAsync();

            return Created(jobAd);
        }

        // PATCH: odata/JobAds2(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<JobAd> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JobAd jobAd = await db.JobAds.FindAsync(key);
            if (jobAd == null)
            {
                return NotFound();
            }

            patch.Patch(jobAd);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobAdExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(jobAd);
        }

        // DELETE: odata/JobAds2(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            JobAd jobAd = await db.JobAds.FindAsync(key);
            if (jobAd == null)
            {
                return NotFound();
            }

            db.JobAds.Remove(jobAd);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/JobAds2(5)/Applies
        [EnableQuery]
        public IQueryable<Apply> GetApplies([FromODataUri] int key)
        {
            return db.JobAds.Where(m => m.Id == key).SelectMany(m => m.Applies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobAdExists(int key)
        {
            return db.JobAds.Count(e => e.Id == key) > 0;
        }
    }
}
