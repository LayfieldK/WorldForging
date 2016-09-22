namespace WorldForging.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WorldForging.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WorldForging.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WorldForging.Models.ApplicationDbContext";
        }

    protected override void Seed(WorldForging.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            #region worlds
            var worlds = new List<World> {
                new World() { WorldId = 1, Name = "Middle-Earth" },
                new World() { WorldId = 2, Name = "Tamriel" }
            };
            worlds.ForEach(c => context.Worlds.AddOrUpdate(c));
            #endregion

            #region subjects
            var subjects = new List<Subject> {
                
                new Subject()
                {
                    World = worlds[0]
                }
                };
            subjects.ForEach(c => context.Subjects.AddOrUpdate(c));
            #endregion


            #region entities
            var entities = new List<Entity> {
                //0
                new Entity()
                {
                    Name = "Frodo Baggins",
                    World = worlds[0]
                },
                //1
                new Entity()
                {
                    Name = "Pippin Took",
                    World = worlds[0]
                },
                //2
                new Entity()
                {
                    Name = "Gandalf",
                    World = worlds[0]
                },
                //3
                new Entity()
                {
                    Name = "Merry Brandybuck",
                    World = worlds[0]
                },
                //4
                new Entity()
                {
                    Name = "Samwise Gamgee",
                    World = worlds[0]
                },
                //5
                new Entity()
                {
                    Name = "Aragorn",
                    World = worlds[0]
                },
                //6
                new Entity()
                {
                    Name = "Legolas",
                    World = worlds[0]
                },
                //7
                new Entity()
                {
                    Name = "Gimli",
                    World = worlds[0]
                },
                //8
                new Entity()
                {
                    Name = "Boromir",
                    World = worlds[0]
                },
                //9
                new Entity()
                {
                    Name = "Alduin",
                    World = worlds[1]
                },
                //10
                new Entity()
                {
                    Name = "The Fellowship of the Ring",
                    World = worlds[0]
                },
                //11
                new Entity()
                {
                    Name = "Hobbits",
                    World = worlds[0]
                },
                //12
                new Entity()
                {
                    Name = "Men",
                    World = worlds[0]
                },
                //13
                new Entity()
                {
                    Name = "Elves",
                    World = worlds[0]
                },
                //14
                new Entity()
                {
                    Name = "Dwarves",
                    World = worlds[0]
                },
                //15
                new Entity()
                {
                    Name = "The Shire",
                    World = worlds[0]
                },
                //16
                new Entity()
                {
                    Name = "Mordor",
                    World = worlds[0]
                },
                //17
                new Entity()
                {
                    Name = "Rivendell",
                    World = worlds[0]
                },
                //18
                new Entity()
                {
                    Name = "The One Ring",
                    World = worlds[0]
                },
                //19
                new Entity()
                {
                    Name = "Forming of the Fellowship of the Ring",
                    World = worlds[0]
                },
                //20
                new Entity()
                {
                    Name = "Gandalf Falls",
                    World = worlds[0]
                },
                //21
                new Entity()
                {
                    Name = "Destruction of The One Ring",
                    World = worlds[0]
                }
                };

            entities.ForEach(c => context.Entities.AddOrUpdate(c));
            #endregion

            #region characters
            var characters = new List<Character> {
                new Character()
                {
                    Entity = entities[0]
                },
                new Character()
                {
                    Entity = entities[1]
                },
                new Character()
                {
                    Entity = entities[2]
                },
                new Character()
                {
                    Entity = entities[3]
                },
                new Character()
                {
                    Entity = entities[4]
                },
                new Character()
                {
                    Entity = entities[5]
                },
                new Character()
                {
                    Entity = entities[6]
                },
                new Character()
                {
                    Entity = entities[7]
                },
                new Character()
                {
                    Entity = entities[8]
                },
                new Character()
                {
                    Entity = entities[9]
                }

                };

            characters.ForEach(c => context.Characters.AddOrUpdate(c));
            #endregion

            #region items
            var items = new List<Item>
            {
                //the one ring
                new Item()
                {
                    Entity = entities[18]
                }
            };

            items.ForEach(c => context.Items.AddOrUpdate(c));
            #endregion

            #region groups
            var groups = new List<Group> {
                new Group()
                {
                    Entity = entities[10]
                },
                new Group()
                {
                    Entity = entities[11]
                },
                new Group()
                {
                    Entity = entities[12]
                },
                new Group()
                {
                    Entity = entities[13]
                },
                new Group()
                {
                    Entity = entities[14]
                }
                };

            groups.ForEach(c => context.Groups.AddOrUpdate(c));
            #endregion

            #region races
            var races = new List<Race>
            {
                new Race()
                {
                    Group = groups[1]
                },
                new Race()
                {
                    Group = groups[2]
                },
                new Race()
                {
                    Group = groups[3]
                },
                new Race()
                {
                    Group = groups[4]
                }
            };

            races.ForEach(c => context.Races.AddOrUpdate(c));
            #endregion

            #region locations
            var locations = new List<Location>
            {
                new Location()
                {
                    Entity = entities[15]
                },
                new Location()
                {
                    Entity = entities[16]
                },
                new Location()
                {
                    Entity = entities[17]
                }
            };

            locations.ForEach(c => context.Locations.AddOrUpdate(c));
            #endregion

            #region desires
            var desires = new List<Desire>
            {
                new Desire()
                {
                    Subject = subjects[0],
                    Description = "destroy <<<18>>> at <<<16>>>"
                }
            };

            desires.ForEach(c => context.Desires.AddOrUpdate(c));
            #endregion

            #region EntityDesires

            var entityDesires = new List<EntityDesire>()
            {
                new Models.EntityDesire()
                {
                    Desire = desires[0]
                }
            };
            entities[0].EntityDesires = new List<EntityDesire>() { entityDesires[0] };
            #endregion

            #region DesireEntities
            var desireEntities = new List<DesireEntity>() {
                new DesireEntity()
                {
                    Entity = entities[18]
                },
                new DesireEntity()
                {
                    Entity = entities[16]
                }
            };
            desires[0].DesireEntities = new List<DesireEntity> { desireEntities[0], desireEntities[1] };

            #endregion

            #region world events
            var events = new List<WorldEvent>
            {
                new WorldEvent()
                {
                    Entity = entities[19]
                },
                new WorldEvent()
                {
                    Entity = entities[20]
                },
                new WorldEvent()
                {
                    Entity = entities[21]
                }
            };

            events.ForEach(c => context.Events.AddOrUpdate(c));
            #endregion


            #region EntityRelationship
            var entityRMemberOfGroup = new EntityRelationship()
            {
                Description = "is a member of",
                World = worlds[0]
            };
            context.EntityRelationships.Add(entityRMemberOfGroup);

            var entityRIsOfRace = new EntityRelationship()
            {
                Description = "is of the race",
                World = worlds[0]
            };
            context.EntityRelationships.Add(entityRIsOfRace);

            var entityRPresentForEvent = new EntityRelationship()
            {
                Description = "was present for",
                World = worlds[0]
            };
            context.EntityRelationships.Add(entityRPresentForEvent);

            var entityROccurredAtLocation = new EntityRelationship()
            {
                Description = "occurred at",
                World = worlds[0]
            };
            context.EntityRelationships.Add(entityROccurredAtLocation);
            #endregion

            #region EntityEntities
            var entityEntities = new List<EntityEntity>() {
                new EntityEntity()
                {
                    Entity1 = entities[0],
                    Entity2 = entities[10],
                    EntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[1],
                    Entity2 = entities[10],
                    EntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[2],
                    Entity2 = entities[10],
                    EntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[3],
                    Entity2 = entities[10],
                    EntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[4],
                    Entity2 = entities[10],
                    EntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[5],
                    Entity2 = entities[10],
                    EntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[6],
                    Entity2 = entities[10],
                    EntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[7],
                    Entity2 = entities[10],
                    EntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[8],
                    Entity2 = entities[10],
                    EntityRelationship = entityRMemberOfGroup
                },
                //hobbits
                new EntityEntity()
                {
                    Entity1 = entities[0],
                    Entity2 = entities[11],
                    EntityRelationship = entityRIsOfRace
                },
                new EntityEntity()
                {
                    Entity1 = entities[1],
                    Entity2 = entities[11],
                    EntityRelationship = entityRIsOfRace
                },
                new EntityEntity()
                {
                    Entity1 = entities[3],
                    Entity2 = entities[11],
                    EntityRelationship = entityRIsOfRace
                },
                new EntityEntity()
                {
                    Entity1 = entities[4],
                    Entity2 = entities[11],
                    EntityRelationship = entityRIsOfRace
                },
                //men
                new EntityEntity()
                {
                    Entity1 = entities[5],
                    Entity2 = entities[12],
                    EntityRelationship = entityRIsOfRace
                },
                new EntityEntity()
                {
                    Entity1 = entities[8],
                    Entity2 = entities[12],
                    EntityRelationship = entityRIsOfRace
                },
                //elves
                new EntityEntity()
                {
                    Entity1 = entities[6],
                    Entity2 = entities[13],
                    EntityRelationship = entityRIsOfRace
                },
                //dwarves
                new EntityEntity()
                {
                    Entity1 = entities[7],
                    Entity2 = entities[14],
                    EntityRelationship = entityRIsOfRace
                },
                //Events occur in locations
                new EntityEntity()
                {
                    Entity1 = entities[19],
                    Entity2 = entities[17],
                    EntityRelationship = entityROccurredAtLocation
                },
                new EntityEntity()
                {
                    Entity1 = entities[21],
                    Entity2 = entities[16],
                    EntityRelationship = entityROccurredAtLocation
                },
                //Entities involved in Events
                new EntityEntity()
                {
                    Entity1 = entities[10],
                    Entity2 = entities[19],
                    EntityRelationship = entityRPresentForEvent
                },
                new EntityEntity()
                {
                    Entity1 = entities[0],
                    Entity2 = entities[19],
                    EntityRelationship = entityRPresentForEvent
                },
                new EntityEntity()
                {
                    Entity1 = entities[4],
                    Entity2 = entities[19],
                    EntityRelationship = entityRPresentForEvent
                },
                new EntityEntity()
                {
                    Entity1 = entities[18],
                    Entity2 = entities[19],
                    EntityRelationship = entityRPresentForEvent
                }
            };

            //entities[0].EntityEntities = new List<EntityEntity> { entityEntities[0], entityEntities[9] };
            //entities[1].EntityEntities = new List<EntityEntity> { entityEntities[1], entityEntities[10] };
            //entities[2].EntityEntities = new List<EntityEntity> { entityEntities[2] };
            //entities[3].EntityEntities = new List<EntityEntity> { entityEntities[3], entityEntities[11] };
            //entities[4].EntityEntities = new List<EntityEntity> { entityEntities[4], entityEntities[12] };
            //entities[5].EntityEntities = new List<EntityEntity> { entityEntities[5], entityEntities[13] };
            //entities[6].EntityEntities = new List<EntityEntity> { entityEntities[6], entityEntities[15] };
            //entities[7].EntityEntities = new List<EntityEntity> { entityEntities[7], entityEntities[16] };
            //entities[8].EntityEntities = new List<EntityEntity> { entityEntities[8], entityEntities[14] };

            entityEntities.ForEach(c => context.EntityEntities.AddOrUpdate(c));
            #endregion

        }

    }
}
