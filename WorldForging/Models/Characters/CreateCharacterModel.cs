using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models.Characters
{
    public class CreateCharacterModel
    {
        public int WorldId { get; set; }
        public Entity VMEntity { get; set; }
        public Character VMCharacter { get; set; }
    }
}