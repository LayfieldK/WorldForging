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
    public class DesiresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Desires
        public async Task<ActionResult> Index()
        {
            var desires = db.Desires.Include(d => d.Subject);
            return View(await desires.ToListAsync());
        }

        // GET: Desires/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desire desire = await db.Desires.FindAsync(id);
            if (desire == null)
            {
                return HttpNotFound();
            }
            return View(desire);
        }

        // GET: Desires/Create
        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId");
            return View();
        }

        // POST: Desires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DesireId,SubjectId")] Desire desire)
        {
            if (ModelState.IsValid)
            {
                db.Desires.Add(desire);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId", desire.SubjectId);
            return View(desire);
        }

        // GET: Desires/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desire desire = await db.Desires.FindAsync(id);
            if (desire == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId", desire.SubjectId);
            return View(desire);
        }

        // POST: Desires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DesireId,SubjectId")] Desire desire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desire).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId", desire.SubjectId);
            return View(desire);
        }

        // GET: Desires/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desire desire = await db.Desires.FindAsync(id);
            if (desire == null)
            {
                return HttpNotFound();
            }
            return View(desire);
        }

        // POST: Desires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Desire desire = await db.Desires.FindAsync(id);
            db.Desires.Remove(desire);
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
