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
    public class BeliefsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Beliefs
        public async Task<ActionResult> Index()
        {
            var beliefs = db.Beliefs.Include(b => b.Subject);
            return View(await beliefs.ToListAsync());
        }

        // GET: Beliefs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belief belief = await db.Beliefs.FindAsync(id);
            if (belief == null)
            {
                return HttpNotFound();
            }
            return View(belief);
        }

        // GET: Beliefs/Create
        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId");
            return View();
        }

        // POST: Beliefs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BeliefId,SubjectId")] Belief belief)
        {
            if (ModelState.IsValid)
            {
                db.Beliefs.Add(belief);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId", belief.SubjectId);
            return View(belief);
        }

        // GET: Beliefs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belief belief = await db.Beliefs.FindAsync(id);
            if (belief == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId", belief.SubjectId);
            return View(belief);
        }

        // POST: Beliefs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BeliefId,SubjectId")] Belief belief)
        {
            if (ModelState.IsValid)
            {
                db.Entry(belief).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectId", belief.SubjectId);
            return View(belief);
        }

        // GET: Beliefs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belief belief = await db.Beliefs.FindAsync(id);
            if (belief == null)
            {
                return HttpNotFound();
            }
            return View(belief);
        }

        // POST: Beliefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Belief belief = await db.Beliefs.FindAsync(id);
            db.Beliefs.Remove(belief);
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
