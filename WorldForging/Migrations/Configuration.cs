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
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[1]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
                new Subject()
                {
                    World = worlds[0]
                },
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
                    Subject = subjects[0],
                    Name = "Frodo Baggins"
                },
                //1
                new Entity()
                {
                    Subject = subjects[1],
                    Name = "Pippin Took"
                },
                //2
                new Entity()
                {
                    Subject = subjects[2],
                    Name = "Gandalf"
                },
                //3
                new Entity()
                {
                    Subject = subjects[3],
                    Name = "Merry Brandybuck"
                },
                //4
                new Entity()
                {
                    Subject = subjects[4],
                    Name = "Samwise Gamgee"
                },
                //5
                new Entity()
                {
                    Subject = subjects[5],
                    Name = "Aragorn"
                },
                //6
                new Entity()
                {
                    Subject = subjects[6],
                    Name = "Legolas"
                },
                //7
                new Entity()
                {
                    Subject = subjects[7],
                    Name = "Gimli"
                },
                //8
                new Entity()
                {
                    Subject = subjects[8],
                    Name = "Boromir"
                },
                //9
                new Entity()
                {
                    Subject = subjects[9],
                    Name = "Alduin"
                },
                //10
                new Entity()
                {
                    Subject = subjects[10],
                    Name = "The Fellowship of the Ring"
                },
                //11
                new Entity()
                {
                    Subject = subjects[11],
                    Name = "Hobbits"
                },
                //12
                new Entity()
                {
                    Subject = subjects[12],
                    Name = "Men"
                },
                //13
                new Entity()
                {
                    Subject = subjects[13],
                    Name = "Elves"
                },
                //14
                new Entity()
                {
                    Subject = subjects[14],
                    Name = "Dwarves"
                },
                //15
                new Entity()
                {
                    Subject = subjects[15],
                    Name = "The Shire"
                },
                //16
                new Entity()
                {
                    Subject = subjects[16],
                    Name = "Mordor"
                },
                //17
                new Entity()
                {
                    Subject = subjects[17],
                    Name = "Rivendell"
                },
                //18
                new Entity()
                {
                    Subject = subjects[19],
                    Name = "The One Ring"
                },
                //19
                new Entity()
                {
                    Subject = subjects[19],
                    Name = "Forming of the Fellowship of the Ring"
                },
                //20
                new Entity()
                {
                    Subject = subjects[19],
                    Name = "Gandalf Falls"
                },
                //21
                new Entity()
                {
                    Subject = subjects[19],
                    Name = "Destruction of The One Ring"
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
                    Subject = subjects[18],
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
            var desireSubjects = new List<DesireSubject>() {
                new DesireSubject()
                {
                    Subject = subjects[19]
                },
                new DesireSubject()
                {
                    Subject = subjects[16]
                }
            };
            desires[0].DesireSubjects = new List<DesireSubject> { desireSubjects[0], desireSubjects[1] };

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


            #region EntityEntityRelationship
            var entityRMemberOfGroup = new EntityEntityRelationship();
            var entityRIsOfRace = new EntityEntityRelationship();
            var entityRPresentForEvent = new EntityEntityRelationship();
            var entityROccurredAtLocation = new EntityEntityRelationship();
            #endregion

            #region EntityEntities
            var entityEntities = new List<EntityEntity>() {
                new EntityEntity()
                {
                    Entity1 = entities[0],
                    Entity2 = entities[10],
                    EntityEntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[1],
                    Entity2 = entities[10],
                    EntityEntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[2],
                    Entity2 = entities[10],
                    EntityEntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[3],
                    Entity2 = entities[10],
                    EntityEntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[4],
                    Entity2 = entities[10],
                    EntityEntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[5],
                    Entity2 = entities[10],
                    EntityEntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[6],
                    Entity2 = entities[10],
                    EntityEntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[7],
                    Entity2 = entities[10],
                    EntityEntityRelationship = entityRMemberOfGroup
                },
                new EntityEntity()
                {
                    Entity1 = entities[8],
                    Entity2 = entities[10],
                    EntityEntityRelationship = entityRMemberOfGroup
                },
                //hobbits
                new EntityEntity()
                {
                    Entity1 = entities[0],
                    Entity2 = entities[11],
                    EntityEntityRelationship = entityRIsOfRace
                },
                new EntityEntity()
                {
                    Entity1 = entities[1],
                    Entity2 = entities[11],
                    EntityEntityRelationship = entityRIsOfRace
                },
                new EntityEntity()
                {
                    Entity1 = entities[3],
                    Entity2 = entities[11],
                    EntityEntityRelationship = entityRIsOfRace
                },
                new EntityEntity()
                {
                    Entity1 = entities[4],
                    Entity2 = entities[11],
                    EntityEntityRelationship = entityRIsOfRace
                },
                //men
                new EntityEntity()
                {
                    Entity1 = entities[5],
                    Entity2 = entities[12],
                    EntityEntityRelationship = entityRIsOfRace
                },
                new EntityEntity()
                {
                    Entity1 = entities[8],
                    Entity2 = entities[12],
                    EntityEntityRelationship = entityRIsOfRace
                },
                //elves
                new EntityEntity()
                {
                    Entity1 = entities[6],
                    Entity2 = entities[13],
                    EntityEntityRelationship = entityRIsOfRace
                },
                //dwarves
                new EntityEntity()
                {
                    Entity1 = entities[7],
                    Entity2 = entities[14],
                    EntityEntityRelationship = entityRIsOfRace
                },
                //Events occur in locations
                new EntityEntity()
                {
                    Entity1 = entities[19],
                    Entity2 = entities[17],
                    EntityEntityRelationship = entityROccurredAtLocation
                },
                new EntityEntity()
                {
                    Entity1 = entities[21],
                    Entity2 = entities[16],
                    EntityEntityRelationship = entityROccurredAtLocation
                },
                //Entities involved in Events
                new EntityEntity()
                {
                    Entity1 = entities[10],
                    Entity2 = entities[19],
                    EntityEntityRelationship = entityRPresentForEvent
                },
                new EntityEntity()
                {
                    Entity1 = entities[0],
                    Entity2 = entities[19],
                    EntityEntityRelationship = entityRPresentForEvent
                },
                new EntityEntity()
                {
                    Entity1 = entities[4],
                    Entity2 = entities[19],
                    EntityEntityRelationship = entityRPresentForEvent
                },
                new EntityEntity()
                {
                    Entity1 = entities[18],
                    Entity2 = entities[19],
                    EntityEntityRelationship = entityRPresentForEvent
                }
            };

            entities[0].EntityEntities = new List<EntityEntity> { entityEntities[0], entityEntities[9] };
            entities[1].EntityEntities = new List<EntityEntity> { entityEntities[1], entityEntities[10] };
            entities[2].EntityEntities = new List<EntityEntity> { entityEntities[2] };
            entities[3].EntityEntities = new List<EntityEntity> { entityEntities[3], entityEntities[11] };
            entities[4].EntityEntities = new List<EntityEntity> { entityEntities[4], entityEntities[12] };
            entities[5].EntityEntities = new List<EntityEntity> { entityEntities[5], entityEntities[13] };
            entities[6].EntityEntities = new List<EntityEntity> { entityEntities[6], entityEntities[15] };
            entities[7].EntityEntities = new List<EntityEntity> { entityEntities[7], entityEntities[16] };
            entities[8].EntityEntities = new List<EntityEntity> { entityEntities[8], entityEntities[14] };
            #endregion

        }

    }
}
