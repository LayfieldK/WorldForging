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
    public class CulturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cultures
        public async Task<ActionResult> Index()
        {
            var cultures = db.Cultures.Include(c => c.Entity);
            return View(await cultures.ToListAsync());
        }

        // GET: Cultures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Culture culture = await db.Cultures.FindAsync(id);
            if (culture == null)
            {
                return HttpNotFound();
            }
            return View(culture);
        }

        // GET: Cultures/Create
        public ActionResult Create()
        {
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId");
            return View();
        }

        // POST: Cultures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CultureId,EntityId")] Culture culture)
        {
            if (ModelState.IsValid)
            {
                db.Cultures.Add(culture);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId", culture.EntityId);
            return View(culture);
        }

        // GET: Cultures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Culture culture = await db.Cultures.FindAsync(id);
            if (culture == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId", culture.EntityId);
            return View(culture);
        }

        // POST: Cultures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CultureId,EntityId")] Culture culture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(culture).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId", culture.EntityId);
            return View(culture);
        }

        // GET: Cultures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Culture culture = await db.Cultures.FindAsync(id);
            if (culture == null)
            {
                return HttpNotFound();
            }
            return View(culture);
        }

        // POST: Cultures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Culture culture = await db.Cultures.FindAsync(id);
            db.Cultures.Remove(culture);
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
