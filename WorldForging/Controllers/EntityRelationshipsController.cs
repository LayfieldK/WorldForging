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
    public class EntityRelationshipsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EntityRelationships
        public async Task<ActionResult> Index()
        {
            return View(await db.EntityRelationships.ToListAsync());
        }

        // GET: EntityRelationships/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityRelationship entityRelationship = await db.EntityRelationships.FindAsync(id);
            if (entityRelationship == null)
            {
                return HttpNotFound();
            }
            return View(entityRelationship);
        }

        // GET: EntityRelationships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntityRelationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EntityRelationshipId,Description")] EntityRelationship entityRelationship)
        {
            if (ModelState.IsValid)
            {
                db.EntityRelationships.Add(entityRelationship);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(entityRelationship);
        }

        // GET: EntityRelationships/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityRelationship entityRelationship = await db.EntityRelationships.FindAsync(id);
            if (entityRelationship == null)
            {
                return HttpNotFound();
            }
            return View(entityRelationship);
        }

        // POST: EntityRelationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EntityRelationshipId,Description")] EntityRelationship entityRelationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entityRelationship).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entityRelationship);
        }

        // GET: EntityRelationships/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityRelationship entityRelationship = await db.EntityRelationships.FindAsync(id);
            if (entityRelationship == null)
            {
                return HttpNotFound();
            }
            return View(entityRelationship);
        }

        // POST: EntityRelationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EntityRelationship entityRelationship = await db.EntityRelationships.FindAsync(id);
            db.EntityRelationships.Remove(entityRelationship);
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
