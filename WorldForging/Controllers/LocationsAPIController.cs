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
using System.Web.Http.Description;
using WorldForging.Models;
using WorldForging.Models.Locations;

namespace WorldForging.Controllers
{
    public class LocationsAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/LocationsAPI
        public IQueryable<Location> GetLocations()
        {
            return db.Locations;
        }

        // GET: api/LocationsAPI/5
        [ResponseType(typeof(Location))]
        public async Task<IHttpActionResult> GetLocation(int id)
        {
            Location location = await db.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // PUT: api/LocationsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLocation(int id, Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location.LocationId)
            {
                return BadRequest();
            }

            db.Entry(location).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/LocationsAPI
        [ResponseType(typeof(CreateLocationModel))]
        public async Task<IHttpActionResult> PostLocation(CreateLocationModel createLocationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            createLocationModel.VMEntity.WorldId = createLocationModel.WorldId;
            db.Entities.Add(createLocationModel.VMEntity);
            createLocationModel.VMLocation.Entity = createLocationModel.VMEntity;
            db.Locations.Add(createLocationModel.VMLocation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = createLocationModel.VMLocation.LocationId }, createLocationModel.VMLocation);

        }

        // DELETE: api/LocationsAPI/5
        [ResponseType(typeof(Location))]
        public async Task<IHttpActionResult> DeleteLocation(int id)
        {
            Location location = await db.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            db.Locations.Remove(location);
            await db.SaveChangesAsync();

            return Ok(location);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationExists(int id)
        {
            return db.Locations.Count(e => e.LocationId == id) > 0;
        }
    }
}