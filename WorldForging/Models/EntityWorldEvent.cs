using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class EntityWorldEvent
    {
        public int EntityWorldEventId { get; set; }

        public int EntityId { get; set; }
        public Entity Entity { get; set; }

        public int WorldEventId { get; set; }
        public WorldEvent WorldEvent { get; set; }

        public int EntityWorldEventRelationshipId { get; set; }
        public EntityWorldEventRelationship EntityWorldEventRelationship { get; set; }
    }
}