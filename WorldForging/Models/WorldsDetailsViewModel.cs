﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldForging.Models
{
    public class WorldsDetailsViewModel
    {
        public World World;
        public List<Subject> Subjects;
        public List<Entity> Entities;
        public List<Character> Characters;
        public List<Group> Groups;
        public List<Race> Races;
        public List<WorldEvent> Events;
        public List<Location> Locations;
        public List<Item> Items;
    }
}