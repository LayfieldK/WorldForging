using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class Entity
    {
        public int EntityId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public virtual ICollection<EntityBelief> EntityBeliefs { get; set; }

        public virtual ICollection<EntityDesire> EntityDesires { get; set; }

        public virtual ICollection<EntityConvention> EntityConventions { get; set; }

        public virtual ICollection<EntityEntity> EntityEntities { get; set; }

        public virtual ICollection<EntityWorldEvent> EntityWorldEvents { get; set; }

    }
}