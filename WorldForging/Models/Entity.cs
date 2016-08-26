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

        public int? WorldId { get; set; }
        public World World { get; set; }

        public  ICollection<EntityBelief> EntityBeliefs { get; set; }

        public ICollection<EntityDesire> EntityDesires { get; set; }

        public  ICollection<EntityConvention> EntityConventions { get; set; }

        public ICollection<EntityEntity> EntityEntities { get; set; }
        

    }
}