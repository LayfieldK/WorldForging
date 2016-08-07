using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class Item
    {
        public int ItemId { get; set; }


        public int EntityId { get; set; }
        public virtual Entity Entity { get; set; }
    }
}