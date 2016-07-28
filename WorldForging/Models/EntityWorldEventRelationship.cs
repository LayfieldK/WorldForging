using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class EntityWorldEventRelationship
    {
        public int EntityWorldEventRelationshipId { get; set; }

        public int EntityId { get; set; }
        public Entity Entity {get;set;}

        public int WorldEventId { get; set; }
        public WorldEvent WorldEvent { get; set; }
    }
}