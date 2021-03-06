﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class EntityRelationship
    {
        public int EntityRelationshipId { get; set; }
        public string Description { get; set; }

        public int? WorldId { get; set; }
        public World World { get; set; }

        public virtual ICollection<EntityEntity> EntityEntities { get; set; }
        public virtual ICollection<EntityRelationshipReason> EntityRelationshipReasons { get; set; }
    }
}