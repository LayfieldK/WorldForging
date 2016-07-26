using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class EntityEventRelationship
    {
        public int EntityEventRelationshipId { get; set; }

        public int EntityId { get; set; }
        public Entity Entity {get;set;}

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}