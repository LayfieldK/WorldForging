using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace WorldForging.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<World> Worlds { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        public System.Data.Entity.DbSet<WorldForging.Models.World> Worlds { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Faction> Factions { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Character> Characters { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Belief> Beliefs { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Subject> Subjects { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Culture> Cultures { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Entity> Entities { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Desire> Desires { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.WorldEvent> Events { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Race> Races { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Reason> Reasons { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Religion> Religions { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Convention> Conventions { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.EntityRelationship> EntityRelationships { get; set; }

        public System.Data.Entity.DbSet<WorldForging.Models.EntityEntity> EntityEntities { get; set; }
    }
}