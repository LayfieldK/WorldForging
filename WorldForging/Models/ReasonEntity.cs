﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class ReasonEntity
    {
        public int ReasonEntityId { get; set; }

        public int ReasonId { get; set; }
        public Reason Reason { get; set; }
    }
}