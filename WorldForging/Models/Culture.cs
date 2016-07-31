using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class Culture
    {
        public int CultureId { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}