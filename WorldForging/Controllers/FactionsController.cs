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
    public class FactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Factions
        public async Task<ActionResult> Index(int? worldID)
        {
            return View(await db.Factions.Where(c => c.WorldId == worldID).ToListAsync());
        }

        // GET: Factions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faction faction = await db.Factions.FindAsync(id);
            if (faction == null)
            {
                return HttpNotFound();
            }
            return View(faction);
        }

        // GET: Factions/Create
        public ActionResult Create(int? worldID)
        {
            TempData["WorldId"] = worldID;
            return View();
        }

        // POST: Factions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FactionId,Name,DescriptionShort")] Faction faction)
        {
            if (ModelState.IsValid)
            {
                var refWorldId = (int)TempData["WorldId"];
                faction.WorldId = refWorldId;
                db.Factions.Add(faction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(faction);
        }

        // GET: Factions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faction faction = await db.Factions.FindAsync(id);
            if (faction == null)
            {
                return HttpNotFound();
            }
            return View(faction);
        }

        // POST: Factions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FactionId,Name,DescriptionShort")] Faction faction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(faction);
        }

        // GET: Factions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faction faction = await db.Factions.FindAsync(id);
            if (faction == null)
            {
                return HttpNotFound();
            }
            return View(faction);
        }

        // POST: Factions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Faction faction = await db.Factions.FindAsync(id);
            db.Factions.Remove(faction);
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
