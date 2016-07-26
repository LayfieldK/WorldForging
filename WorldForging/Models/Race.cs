﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class Race
    {
        public int RaceId { get; set; }

        public int EntityId { get; set; }
        public Entity Entity { get; set; }
    }
}