using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class SubjectLocationRelationship
    {
        public int SubjectLocationRelationshipId { get; set; }

        public virtual ICollection<SubjectLocation> SubjectLocations { get; set; }
        public virtual ICollection<SubjectLocationRelationshipReason> SubjectLocationRelationshipReasons { get; set; }
    }
}