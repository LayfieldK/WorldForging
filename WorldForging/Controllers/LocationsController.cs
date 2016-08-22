using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldForging.Models;
using WorldForging.Models.Locations;

namespace WorldForging.Controllers
{
    public class LocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Locations
        public async Task<ActionResult> Index()
        {
            var locations = db.Locations.Include(l => l.Entity);
            return View(await locations.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = await db.Locations.FindAsync(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create(int? worldId)
        {
            if (worldId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            World world = db.Worlds.Find(worldId);

            if (world == null)
            {
                return HttpNotFound();
            }
            CreateLocationModel clm = new Models.Locations.CreateLocationModel();
            clm.WorldId = world.WorldId;
            return View(clm);
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLocationModel createLocationModel)
        {
            if (ModelState.IsValid)
            {
                if (createLocationModel.VMLocation == null)
                {
                    createLocationModel.VMLocation = new Models.Location();
                }
                createLocationModel.VMEntity.WorldId = createLocationModel.WorldId;
                db.Entities.Add(createLocationModel.VMEntity);
                createLocationModel.VMLocation.Entity = createLocationModel.VMEntity;
                db.Locations.Add(createLocationModel.VMLocation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(createLocationModel.VMLocation);
        }

        // GET: Locations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = await db.Locations.FindAsync(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "Name", location.EntityId);
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LocationId,Name,DescriptionShort,EntityId")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "Name", location.EntityId);
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = await db.Locations.FindAsync(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Location location = await db.Locations.FindAsync(id);
            db.Locations.Remove(location);
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
