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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WorldForging.Controllers
{
    public class WorldsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public WorldsController()
        {
            this.db = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.db));
        }

        // GET: Worlds
        public async Task<ActionResult> Index()
        {
            var worlds = db.Worlds.Include(w => w.User);
            return View(await worlds.ToListAsync());
        }

        // GET: Worlds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            World world = await db.Worlds.FindAsync(id);
            if (world == null)
            {
                return HttpNotFound();
            }

            var worldDetailsVM = new WorldsDetailsViewModel();
            worldDetailsVM.World = world;
            worldDetailsVM.Entities = db.Entities.Where(c => c.Subject.WorldId == id).ToList();
            worldDetailsVM.Characters= db.Characters.Where(c => c.Entity.Subject.WorldId == id).ToList();
            worldDetailsVM.Races = db.Races.Where(c => c.Group.Entity.Subject.WorldId == id).ToList();
            worldDetailsVM.Locations = db.Locations.Where(c => c.Entity.Subject.WorldId == id).ToList();
            worldDetailsVM.Items = db.Items.Where(c => c.Entity.Subject.WorldId == id).ToList();
            worldDetailsVM.Groups = db.Groups.Where(c => c.Entity.Subject.WorldId == id).ToList();
            worldDetailsVM.Events = db.Events.Where(c => c.Entity.Subject.WorldId == id).ToList();
            worldDetailsVM.Subjects = db.Subjects.Where(c => c.WorldId == id).ToList();
            return View(worldDetailsVM);
        }

        // GET: Worlds/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Worlds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "WorldId,Name,Description,UserId")] World world)
        {
            if (ModelState.IsValid)
            {
                world.User = await this.UserManager.FindByIdAsync(User.Identity.GetUserId());
                db.Worlds.Add(world);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(world);
        }

        // GET: Worlds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            World world = await db.Worlds.FindAsync(id);
            if (world == null)
            {
                return HttpNotFound();
            }

            return View(world);
        }

        // POST: Worlds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "WorldId,Name,Description,UserId")] World world)
        {
            if (ModelState.IsValid)
            {
                db.Entry(world).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(world);
        }

        // GET: Worlds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            World world = await db.Worlds.FindAsync(id);
            if (world == null)
            {
                return HttpNotFound();
            }
            return View(world);
        }

        // POST: Worlds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            World world = await db.Worlds.FindAsync(id);
            db.Worlds.Remove(world);
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

        /// <summary>
        /// Application DB context
        /// </summary>
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        protected UserManager<ApplicationUser> UserManager { get; set; }
    }
}
