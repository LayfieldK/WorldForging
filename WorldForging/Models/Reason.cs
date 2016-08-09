using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class Reason
    {
        public int ReasonId { get; set; }

        public string Description { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public virtual ICollection<ReasonSubject> ReasonSubjects { get; set; }
    }
}