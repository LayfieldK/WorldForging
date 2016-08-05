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
            var worlds = new List<World> {
                new World() { WorldId = 1, Name = "Middle-Earth" },
                new World() { WorldId = 2, Name = "Tamriel" }
            };
            worlds.ForEach(c => context.Worlds.AddOrUpdate(c));

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
                }
                };
            subjects.ForEach(c => context.Subjects.AddOrUpdate(c));

            var entities = new List<Entity> {
                //0
                new Entity()
                {
                    Subject = subjects[0],
                    Name = "Frodo Baggins"
                },
                //0
                new Entity()
                {
                    Subject = subjects[1],
                    Name = "Pippin Took"
                },
                //0
                new Entity()
                {
                    Subject = subjects[2],
                    Name = "Gandalf"
                },
                //0
                new Entity()
                {
                    Subject = subjects[3],
                    Name = "Merry Brandybuck"
                },
                //0
                new Entity()
                {
                    Subject = subjects[4],
                    Name = "Samwise Gamgee"
                },
                //0
                new Entity()
                {
                    Subject = subjects[5],
                    Name = "Aragorn"
                },
                //0
                new Entity()
                {
                    Subject = subjects[6],
                    Name = "Legolas"
                },
                //0
                new Entity()
                {
                    Subject = subjects[7],
                    Name = "Gimli"
                },
                //0
                new Entity()
                {
                    Subject = subjects[8],
                    Name = "Boromir"
                },
                //0
                new Entity()
                {
                    Subject = subjects[9],
                    Name = "Alduin"
                },
                //0
                new Entity()
                {
                    Subject = subjects[10],
                    Name = "The Fellowship of the Ring"
                },
                //0
                new Entity()
                {
                    Subject = subjects[11],
                    Name = "Hobbits"
                },
                //0
                new Entity()
                {
                    Subject = subjects[12],
                    Name = "Men"
                },
                new Entity()
                {
                    Subject = subjects[13],
                    Name = "Elves"
                },
                new Entity()
                {
                    Subject = subjects[14],
                    Name = "Dwarves"
                }
                };

            entities.ForEach(c => context.Entities.AddOrUpdate(c));

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

            var entityRMemberOfGroup = new EntityEntityRelationship();
            var entityRIsOfRace = new EntityEntityRelationship();

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

                      

        }
        
    }
}
