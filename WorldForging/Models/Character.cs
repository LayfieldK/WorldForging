using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class Character
    {
        public int CharacterId { get; set; }

        public string Name { get; set; }

        public string DescriptionShort { get; set; }

        public int WorldId { get; set; }

        public virtual World World { get; set; }
    }
}