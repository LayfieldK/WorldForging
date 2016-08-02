using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class EntityEntity
    {
        public int EntityEntityId { get; set; }

        public int Entity1Id { get; set; }
        [ForeignKey("Entity1Id")]
        public Entity Entity1 { get; set; }

        public int? Entity2Id { get; set; }
        [ForeignKey("Entity2Id")]
        public Entity Entity2 { get; set; }

        public int EntityEntityRelationshipId { get; set; }
        public EntityEntityRelationship EntityEntityRelationship { get; set; }
    }
}