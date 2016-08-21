using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorldForging.Models.Groups
{
    public class CreateGroupModel
    {
        public int WorldId { get; set; }
        public Entity VMEntity { get; set; }
        public Group VMGroup { get; set; }
        public string SelectedGroupType { get; set; }
        public ICollection<SelectListItem> GroupTypes { get; set; }
    }
}