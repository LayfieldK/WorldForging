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
using WorldForging.Models.WorldEvents;

namespace WorldForging.Controllers
{
    public class WorldEventsAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WorldEventsAPI
        public IQueryable<WorldEvent> GetEvents()
        {
            return db.Events;
        }

        // GET: api/WorldEventsAPI/5
        [ResponseType(typeof(WorldEvent))]
        public async Task<IHttpActionResult> GetWorldEvent(int id)
        {
            WorldEvent worldEvent = await db.Events.FindAsync(id);
            if (worldEvent == null)
            {
                return NotFound();
            }

            return Ok(worldEvent);
        }

        // PUT: api/WorldEventsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorldEvent(int id, WorldEvent worldEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worldEvent.WorldEventId)
            {
                return BadRequest();
            }

            db.Entry(worldEvent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorldEventExists(id))
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

        // POST: api/WorldEventsAPI
        [ResponseType(typeof(CreateWorldEventModel))]
        public async Task<IHttpActionResult> PostWorldEvent(CreateWorldEventModel createWorldEventModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            createWorldEventModel.VMEntity.WorldId = createWorldEventModel.WorldId;
            db.Entities.Add(createWorldEventModel.VMEntity);
            createWorldEventModel.VMWorldEvent.Entity = createWorldEventModel.VMEntity;
            db.Events.Add(createWorldEventModel.VMWorldEvent);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = createWorldEventModel.VMWorldEvent.WorldEventId }, createWorldEventModel.VMWorldEvent);

        }

        // DELETE: api/WorldEventsAPI/5
        [ResponseType(typeof(WorldEvent))]
        public async Task<IHttpActionResult> DeleteWorldEvent(int id)
        {
            WorldEvent worldEvent = await db.Events.FindAsync(id);
            if (worldEvent == null)
            {
                return NotFound();
            }

            db.Events.Remove(worldEvent);
            await db.SaveChangesAsync();

            return Ok(worldEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorldEventExists(int id)
        {
            return db.Events.Count(e => e.WorldEventId == id) > 0;
        }
    }
}