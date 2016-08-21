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
using WorldForging.Models.Groups;

namespace WorldForging.Controllers
{
    public class GroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Groups
        public async Task<ActionResult> Index()
        {
            var groups = db.Groups.Include(g => g.Entity);
            return View(await groups.ToListAsync());
        }

        // GET: Groups/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create(int? worldId, string groupType)
        {
            if (worldId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            World world = db.Worlds.Find(worldId);

            if (world == null)
            {
                return HttpNotFound();
            }
            CreateGroupModel cgm = new Models.Groups.CreateGroupModel();
            cgm.WorldId = world.WorldId;
            cgm.GroupTypes = new List<SelectListItem> { new SelectListItem() { Text = "Faction", Value = "faction" }, new SelectListItem() { Text = "Race", Value = "race" } , new SelectListItem() { Text = "Culture", Value = "culture" } , new SelectListItem() { Text = "Religion", Value = "religion" } };
            if (groupType != null && groupType != "")
            {
                var selected = cgm.GroupTypes.Where(x => x.Value == groupType).First();
                selected.Selected = true;
            }
            return View(cgm);
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateGroupModel createGroupModel)
        {
            if (ModelState.IsValid)
            {
                if (createGroupModel.VMGroup == null)
                {
                    createGroupModel.VMGroup = new Models.Group();
                }
                createGroupModel.VMEntity.WorldId = createGroupModel.WorldId;
                db.Entities.Add(createGroupModel.VMEntity);
                createGroupModel.VMGroup.Entity = createGroupModel.VMEntity;
                db.Groups.Add(createGroupModel.VMGroup);

                switch (createGroupModel.SelectedGroupType)
                {
                    case "race":
                        db.Races.Add(new Race() { Group = createGroupModel.VMGroup });
                        break;
                    case "faction":
                        db.Factions.Add(new Faction() { Group = createGroupModel.VMGroup });
                        break;
                    case "culture":
                        db.Cultures.Add(new Culture() { Group = createGroupModel.VMGroup });
                        break;
                    case "religion":
                        db.Religions.Add(new Religion() { Group = createGroupModel.VMGroup });
                        break;
                }

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(createGroupModel.VMGroup);
        }

        // GET: Groups/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "Name", group.EntityId);
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GroupId,EntityId")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "Name", group.EntityId);
            return View(group);
        }

        // GET: Groups/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Group group = await db.Groups.FindAsync(id);
            db.Groups.Remove(group);
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
