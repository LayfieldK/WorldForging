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
using WorldForging.Models.Entities;

namespace WorldForging.Controllers
{
    public class EntitiesAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EntitiesAPI
        public IQueryable<Entity> GetEntities()
        {
            return db.Entities;
        }

        // GET: api/EntitiesAPI/5
        [ResponseType(typeof(EntityRelationshipViewModel))]
        public async Task<IHttpActionResult> GetEntity(int? entityId)
        {
            Entity entity = await db.Entities.SingleOrDefaultAsync(e => e.EntityId == entityId);
            if (entity == null)
            {
                return NotFound();
            }
            EntityRelationshipViewModel erVM = new Models.Entities.EntityRelationshipViewModel();
            erVM.Entity = entity;
            //entity.EntityEntities = 
            erVM.EntityRelationships = db.EntityEntities.Where(ee => ee.Entity1Id == entity.EntityId || ee.Entity2Id == entity.EntityId).ToList();
            erVM.Entities = db.Entities.Where(c => c.WorldId == entity.WorldId).ToList();
            erVM.Relationships = db.EntityRelationships.Where(er => er.WorldId == entity.WorldId).ToList();
            return Ok(erVM);
        }

        // PUT: api/EntitiesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEntity(int id, Entity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.EntityId)
            {
                return BadRequest();
            }

            db.Entry(entity).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
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

        // POST: api/EntitiesAPI
        [ResponseType(typeof(Entity))]
        public async Task<IHttpActionResult> PostEntity(Entity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entities.Add(entity);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = entity.EntityId }, entity);
        }

        // DELETE: api/EntitiesAPI/5
        [ResponseType(typeof(Entity))]
        public async Task<IHttpActionResult> DeleteEntity(int id)
        {
            Entity entity = await db.Entities.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            db.Entities.Remove(entity);
            await db.SaveChangesAsync();

            return Ok(entity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntityExists(int id)
        {
            return db.Entities.Count(e => e.EntityId == id) > 0;
        }
    }
}