﻿using System;
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

namespace WorldForging.Controllers
{
    public class WorldsAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WorldsAPI
        public IQueryable<World> GetWorlds()
        {
            try
            {
                return db.Worlds.Include(p => p.Entities).AsQueryable<World>();
            }catch(Exception ex)
            {
                string problem = ex.Message;
                return null;
            }
        }

        // GET: api/WorldsAPI/5
        [ResponseType(typeof(World))]
        public async Task<IHttpActionResult> GetWorld(int id)
        {
            World world = await db.Worlds.FindAsync(id);
            if (world == null)
            {
                return NotFound();
            }

            return Ok(world);
        }

        // PUT: api/WorldsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorld(int id, World world)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != world.WorldId)
            {
                return BadRequest();
            }

            db.Entry(world).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorldExists(id))
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

        // POST: api/WorldsAPI
        [ResponseType(typeof(World))]
        public async Task<IHttpActionResult> PostWorld(World world)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Worlds.Add(world);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = world.WorldId }, world);
        }

        // DELETE: api/WorldsAPI/5
        [ResponseType(typeof(World))]
        public async Task<IHttpActionResult> DeleteWorld(int id)
        {
            World world = await db.Worlds.FindAsync(id);
            if (world == null)
            {
                return NotFound();
            }

            db.Worlds.Remove(world);
            await db.SaveChangesAsync();

            return Ok(world);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorldExists(int id)
        {
            return db.Worlds.Count(e => e.WorldId == id) > 0;
        }
    }
}