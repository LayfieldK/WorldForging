﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class EntityDesireReason
    {
        public int EntityDesireReasonId { get; set; }

        public int EntityDesireId { get; set; }
        public EntityDesire EntityDesire { get; set; }
    }
}