using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class EntityEvent
    {
        public int EntityEventId { get; set; }

        public int EntityId { get; set; }
        public Entity Entity { get; set; }

        public int EventId { get; set; }
        public WorldEvent Event { get; set; }
    }
}