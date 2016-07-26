using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class Belief
    {
        public int BeliefId { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}