using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class SubjectLocationRelationshipReason
    {
        public int SubjectLocationRelationshipReasonId { get; set; }

        public int SubjectLocationRelationshipId { get; set; }
        public SubjectLocationRelationship SubjectLocationRelationship { get; set; }
    }
}