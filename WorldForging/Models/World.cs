using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class World
    {
        public int WorldId { get; set; }

        public string Name { get; set; }

        public string DescriptionShort { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}