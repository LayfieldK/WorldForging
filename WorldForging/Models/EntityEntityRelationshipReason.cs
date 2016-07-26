using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class EntityEntityRelationshipReason
    {
        public int EntityEntityRelationshipReasonId { get; set; }

        public int EntityEntityRelationshipId { get; set; }
        public EntityEntityRelationship EntityEntityRelationship { get; set; }
    }
}