﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class Desire
    {
        public int DesireId { get; set; }


        public string Description { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public virtual ICollection<EntityDesire> EntityDesires { get; set; }

        public virtual ICollection<DesireEntity> DesireEntities { get; set; }
    }
}