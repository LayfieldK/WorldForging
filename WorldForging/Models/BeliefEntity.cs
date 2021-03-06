﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class BeliefEntity
    {
        public int BeliefEntityId { get; set; }

        public int BeliefId { get; set; }
        public Belief Belief { get; set; }

        public int? EntityId { get; set; }
        public Entity Entity { get; set; }
    }
}