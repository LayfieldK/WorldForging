using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class SubjectLocation
    {
        public int SubjectLocationId { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}