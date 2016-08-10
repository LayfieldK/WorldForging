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
    public class CharactersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        // GET: Characters?WorldId=5
        public async Task<ActionResult> Index(int? worldId, int? characterId)
        {
            IQueryable<Character> characters;
            if (worldId != null)
            {
                characters = db.Characters
               .Where(c => c.Entity.WorldId == worldId);
                return View(await characters.ToListAsync());
            }
            if (characterId != null)
            {
                characters = db.Characters
               .Where(c => c.CharacterId == characterId);
                return View(await characters.ToListAsync());
            }

            //World world = await db.Worlds.FindAsync(idworldId;
            //if (world == null)
            //{
            //    return HttpNotFound();
            //}
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        // GET: Characters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "Name");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CharacterId,EntityId")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Characters.Add(character);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "Name", character.EntityId);
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "Name", character.EntityId);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CharacterId,EntityId")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "Name", character.EntityId);
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Character character = await db.Characters.FindAsync(id);
            db.Characters.Remove(character);
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
