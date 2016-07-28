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
    public class ReligionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Religions
        public async Task<ActionResult> Index()
        {
            var religions = db.Religions.Include(r => r.Entity);
            return View(await religions.ToListAsync());
        }

        // GET: Religions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Religion religion = await db.Religions.FindAsync(id);
            if (religion == null)
            {
                return HttpNotFound();
            }
            return View(religion);
        }

        // GET: Religions/Create
        public ActionResult Create()
        {
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId");
            return View();
        }

        // POST: Religions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReligionId,EntityId")] Religion religion)
        {
            if (ModelState.IsValid)
            {
                db.Religions.Add(religion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId", religion.EntityId);
            return View(religion);
        }

        // GET: Religions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Religion religion = await db.Religions.FindAsync(id);
            if (religion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId", religion.EntityId);
            return View(religion);
        }

        // POST: Religions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReligionId,EntityId")] Religion religion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(religion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityId", religion.EntityId);
            return View(religion);
        }

        // GET: Religions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Religion religion = await db.Religions.FindAsync(id);
            if (religion == null)
            {
                return HttpNotFound();
            }
            return View(religion);
        }

        // POST: Religions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Religion religion = await db.Religions.FindAsync(id);
            db.Religions.Remove(religion);
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
