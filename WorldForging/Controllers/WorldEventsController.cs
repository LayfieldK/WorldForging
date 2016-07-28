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
    public class WorldEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorldEvents
        public async Task<ActionResult> Index()
        {
            var events = db.Events.Include(w => w.Subject);
            return View(await events.ToListAsync());
        }

        // GET: WorldEvents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorldEvent worldEvent = await db.Events.FindAsync(id);
            if (worldEvent == null)
            {
                return HttpNotFound();
            }
            return View(worldEvent);
        }

        // GET: WorldEvents/Create
        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId");
            return View();
        }

        // POST: WorldEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "WorldEventId,Name,DescriptionShort,SubjectId")] WorldEvent worldEvent)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(worldEvent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId", worldEvent.SubjectId);
            return View(worldEvent);
        }

        // GET: WorldEvents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorldEvent worldEvent = await db.Events.FindAsync(id);
            if (worldEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId", worldEvent.SubjectId);
            return View(worldEvent);
        }

        // POST: WorldEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "WorldEventId,Name,DescriptionShort,SubjectId")] WorldEvent worldEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worldEvent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId", worldEvent.SubjectId);
            return View(worldEvent);
        }

        // GET: WorldEvents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorldEvent worldEvent = await db.Events.FindAsync(id);
            if (worldEvent == null)
            {
                return HttpNotFound();
            }
            return View(worldEvent);
        }

        // POST: WorldEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WorldEvent worldEvent = await db.Events.FindAsync(id);
            db.Events.Remove(worldEvent);
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
