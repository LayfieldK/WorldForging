using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public int WorldId { get; set; }
        public World World { get; set; }

        public virtual ICollection<SubjectLocation> SubjectLocations { get; set; }
        
    }
}