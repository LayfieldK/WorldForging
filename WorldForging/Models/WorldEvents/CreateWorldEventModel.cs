﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models.WorldEvents
{
    public class CreateWorldEventModel
    {
        public int WorldId { get; set; }
        public Entity VMEntity { get; set; }
        public WorldEvent VMWorldEvent { get; set; }
    }
}