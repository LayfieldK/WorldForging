using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class Faction
    {
        public int FactionId { get; set; }

        public string Name { get; set; }

        public string DescriptionShort { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}