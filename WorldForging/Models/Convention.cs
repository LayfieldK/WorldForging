﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class Convention
    {
        public int ConventionId { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}