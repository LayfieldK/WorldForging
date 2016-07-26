using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class EntityEntityRelationship
    {
        public int EntityEntityRelationshipId { get; set; }

        public virtual ICollection<EntityEntity> EntityEntities { get; set; }
        public virtual ICollection<EntityEntityRelationshipReason> EntityEntityRelationshipReasons { get; set; }
    }
}