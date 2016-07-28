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

namespace WorldForging.Controllers
{
    public class RacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Races
        public async Task<ActionResult> Index()
        {
            var races = db.Races.Include(r => r.Entity);
            return View(await races.ToListAsync());
        }

        // GET: Races/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = await db.Races.FindAsync(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // GET: Races/Create
        public ActionResult Create()
        {
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId");
            return View();
        }

        // POST: Races/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RaceId,EntityId")] Race race)
        {
            if (ModelState.IsValid)
            {
                db.Races.Add(race);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId", race.EntityId);
            return View(race);
        }

        // GET: Races/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = await db.Races.FindAsync(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId", race.EntityId);
            return View(race);
        }

        // POST: Races/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RaceId,EntityId")] Race race)
        {
            if (ModelState.IsValid)
            {
                db.Entry(race).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId", race.EntityId);
            return View(race);
        }

        // GET: Races/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = await db.Races.FindAsync(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Race race = await db.Races.FindAsync(id);
            db.Races.Remove(race);
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
