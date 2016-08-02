namespace WorldForging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "WorldId", "dbo.Worlds");
            DropForeignKey("dbo.Factions", "WorldId", "dbo.Worlds");
            DropIndex("dbo.Characters", new[] { "WorldId" });
            DropIndex("dbo.Factions", new[] { "WorldId" });
            CreateTable(
                "dbo.Beliefs",
                c => new
                    {
                        BeliefId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeliefId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.BeliefEntities",
                c => new
                    {
                        BeliefEntityId = c.Int(nullable: false, identity: true),
                        BeliefId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeliefEntityId)
                .ForeignKey("dbo.Beliefs", t => t.BeliefId, cascadeDelete: true)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.BeliefId)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        EntityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.EntityId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.EntityBeliefs",
                c => new
                    {
                        EntityBeliefId = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        BeliefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntityBeliefId)
                .ForeignKey("dbo.Beliefs", t => t.BeliefId, cascadeDelete: true)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.EntityId)
                .Index(t => t.BeliefId);
            
            CreateTable(
                "dbo.EntityConventions",
                c => new
                    {
                        EntityConventionId = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        ConventionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntityConventionId)
                .ForeignKey("dbo.Conventions", t => t.ConventionId, cascadeDelete: true)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.EntityId)
                .Index(t => t.ConventionId);
            
            CreateTable(
                "dbo.Conventions",
                c => new
                    {
                        ConventionId = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConventionId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        WorldId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Worlds", t => t.WorldId, cascadeDelete: true)
                .Index(t => t.WorldId);
            
            CreateTable(
                "dbo.EntityDesires",
                c => new
                    {
                        EntityDesireId = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        DesireId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntityDesireId)
                .ForeignKey("dbo.Desires", t => t.DesireId, cascadeDelete: true)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.EntityId)
                .Index(t => t.DesireId);
            
            CreateTable(
                "dbo.Desires",
                c => new
                    {
                        DesireId = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DesireId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.EntityDesireReasons",
                c => new
                    {
                        EntityDesireReasonId = c.Int(nullable: false, identity: true),
                        EntityDesireId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntityDesireReasonId)
                .ForeignKey("dbo.EntityDesires", t => t.EntityDesireId, cascadeDelete: true)
                .Index(t => t.EntityDesireId);
            
            CreateTable(
                "dbo.EntityEntities",
                c => new
                    {
                        EntityEntityId = c.Int(nullable: false, identity: true),
                        Entity1Id = c.Int(),
                        Entity2Id = c.Int(),
                        EntityEntityRelationshipId = c.Int(nullable: false),
                        Entity_EntityId = c.Int(),
                    })
                .PrimaryKey(t => t.EntityEntityId)
                .ForeignKey("dbo.Entities", t => t.Entity1Id)
                .ForeignKey("dbo.Entities", t => t.Entity2Id)
                .ForeignKey("dbo.EntityEntityRelationships", t => t.EntityEntityRelationshipId, cascadeDelete: true)
                .ForeignKey("dbo.Entities", t => t.Entity_EntityId)
                .Index(t => t.Entity1Id)
                .Index(t => t.Entity2Id)
                .Index(t => t.EntityEntityRelationshipId)
                .Index(t => t.Entity_EntityId);
            
            CreateTable(
                "dbo.EntityEntityRelationships",
                c => new
                    {
                        EntityEntityRelationshipId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.EntityEntityRelationshipId);
            
            CreateTable(
                "dbo.EntityEntityRelationshipReasons",
                c => new
                    {
                        EntityEntityRelationshipReasonId = c.Int(nullable: false, identity: true),
                        EntityEntityRelationshipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntityEntityRelationshipReasonId)
                .ForeignKey("dbo.EntityEntityRelationships", t => t.EntityEntityRelationshipId, cascadeDelete: true)
                .Index(t => t.EntityEntityRelationshipId);
            
            CreateTable(
                "dbo.EntityWorldEvents",
                c => new
                    {
                        EntityWorldEventId = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        WorldEventId = c.Int(nullable: false),
                        EntityWorldEventRelationshipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntityWorldEventId)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.EntityWorldEventRelationships", t => t.EntityWorldEventRelationshipId, cascadeDelete: true)
                .ForeignKey("dbo.WorldEvents", t => t.WorldEventId, cascadeDelete: true)
                .Index(t => t.EntityId)
                .Index(t => t.WorldEventId)
                .Index(t => t.EntityWorldEventRelationshipId);
            
            CreateTable(
                "dbo.EntityWorldEventRelationships",
                c => new
                    {
                        EntityWorldEventRelationshipId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.EntityWorldEventRelationshipId);
            
            CreateTable(
                "dbo.WorldEvents",
                c => new
                    {
                        WorldEventId = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(),
                    })
                .PrimaryKey(t => t.WorldEventId)
                .ForeignKey("dbo.Entities", t => t.EntityId)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Cultures",
                c => new
                    {
                        CultureId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CultureId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DescriptionShort = c.String(),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        RaceId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RaceId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        ReasonId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReasonId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.ReasonEntities",
                c => new
                    {
                        ReasonEntityId = c.Int(nullable: false, identity: true),
                        ReasonId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReasonEntityId)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.Reasons", t => t.ReasonId, cascadeDelete: true)
                .Index(t => t.ReasonId)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        ReligionId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReligionId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            AddColumn("dbo.Characters", "EntityId", c => c.Int(nullable: false));
            AddColumn("dbo.Worlds", "Description", c => c.String());
            AddColumn("dbo.Factions", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Characters", "EntityId");
            CreateIndex("dbo.Factions", "GroupId");
            AddForeignKey("dbo.Characters", "EntityId", "dbo.Entities", "EntityId", cascadeDelete: true);
            AddForeignKey("dbo.Factions", "GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
            DropColumn("dbo.Characters", "Name");
            DropColumn("dbo.Characters", "DescriptionShort");
            DropColumn("dbo.Characters", "WorldId");
            DropColumn("dbo.Worlds", "DescriptionShort");
            DropColumn("dbo.Factions", "WorldId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Factions", "WorldId", c => c.Int(nullable: false));
            AddColumn("dbo.Worlds", "DescriptionShort", c => c.String());
            AddColumn("dbo.Characters", "WorldId", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "DescriptionShort", c => c.String());
            AddColumn("dbo.Characters", "Name", c => c.String());
            DropForeignKey("dbo.Religions", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Reasons", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.ReasonEntities", "ReasonId", "dbo.Reasons");
            DropForeignKey("dbo.ReasonEntities", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Races", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Locations", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Factions", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Cultures", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Characters", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Beliefs", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.BeliefEntities", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Entities", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.EntityWorldEvents", "WorldEventId", "dbo.WorldEvents");
            DropForeignKey("dbo.WorldEvents", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.EntityWorldEvents", "EntityWorldEventRelationshipId", "dbo.EntityWorldEventRelationships");
            DropForeignKey("dbo.EntityWorldEvents", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.EntityEntities", "Entity_EntityId", "dbo.Entities");
            DropForeignKey("dbo.EntityEntityRelationshipReasons", "EntityEntityRelationshipId", "dbo.EntityEntityRelationships");
            DropForeignKey("dbo.EntityEntities", "EntityEntityRelationshipId", "dbo.EntityEntityRelationships");
            DropForeignKey("dbo.EntityEntities", "Entity2Id", "dbo.Entities");
            DropForeignKey("dbo.EntityEntities", "Entity1Id", "dbo.Entities");
            DropForeignKey("dbo.EntityDesireReasons", "EntityDesireId", "dbo.EntityDesires");
            DropForeignKey("dbo.EntityDesires", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Desires", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.EntityDesires", "DesireId", "dbo.Desires");
            DropForeignKey("dbo.EntityConventions", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.EntityConventions", "ConventionId", "dbo.Conventions");
            DropForeignKey("dbo.Conventions", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "WorldId", "dbo.Worlds");
            DropForeignKey("dbo.EntityBeliefs", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.EntityBeliefs", "BeliefId", "dbo.Beliefs");
            DropForeignKey("dbo.BeliefEntities", "BeliefId", "dbo.Beliefs");
            DropIndex("dbo.Religions", new[] { "GroupId" });
            DropIndex("dbo.ReasonEntities", new[] { "EntityId" });
            DropIndex("dbo.ReasonEntities", new[] { "ReasonId" });
            DropIndex("dbo.Reasons", new[] { "SubjectId" });
            DropIndex("dbo.Races", new[] { "GroupId" });
            DropIndex("dbo.Locations", new[] { "EntityId" });
            DropIndex("dbo.Factions", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "EntityId" });
            DropIndex("dbo.Cultures", new[] { "GroupId" });
            DropIndex("dbo.Characters", new[] { "EntityId" });
            DropIndex("dbo.WorldEvents", new[] { "EntityId" });
            DropIndex("dbo.EntityWorldEvents", new[] { "EntityWorldEventRelationshipId" });
            DropIndex("dbo.EntityWorldEvents", new[] { "WorldEventId" });
            DropIndex("dbo.EntityWorldEvents", new[] { "EntityId" });
            DropIndex("dbo.EntityEntityRelationshipReasons", new[] { "EntityEntityRelationshipId" });
            DropIndex("dbo.EntityEntities", new[] { "Entity_EntityId" });
            DropIndex("dbo.EntityEntities", new[] { "EntityEntityRelationshipId" });
            DropIndex("dbo.EntityEntities", new[] { "Entity2Id" });
            DropIndex("dbo.EntityEntities", new[] { "Entity1Id" });
            DropIndex("dbo.EntityDesireReasons", new[] { "EntityDesireId" });
            DropIndex("dbo.Desires", new[] { "SubjectId" });
            DropIndex("dbo.EntityDesires", new[] { "DesireId" });
            DropIndex("dbo.EntityDesires", new[] { "EntityId" });
            DropIndex("dbo.Subjects", new[] { "WorldId" });
            DropIndex("dbo.Conventions", new[] { "SubjectId" });
            DropIndex("dbo.EntityConventions", new[] { "ConventionId" });
            DropIndex("dbo.EntityConventions", new[] { "EntityId" });
            DropIndex("dbo.EntityBeliefs", new[] { "BeliefId" });
            DropIndex("dbo.EntityBeliefs", new[] { "EntityId" });
            DropIndex("dbo.Entities", new[] { "SubjectId" });
            DropIndex("dbo.BeliefEntities", new[] { "EntityId" });
            DropIndex("dbo.BeliefEntities", new[] { "BeliefId" });
            DropIndex("dbo.Beliefs", new[] { "SubjectId" });
            DropColumn("dbo.Factions", "GroupId");
            DropColumn("dbo.Worlds", "Description");
            DropColumn("dbo.Characters", "EntityId");
            DropTable("dbo.Religions");
            DropTable("dbo.ReasonEntities");
            DropTable("dbo.Reasons");
            DropTable("dbo.Races");
            DropTable("dbo.Locations");
            DropTable("dbo.Groups");
            DropTable("dbo.Cultures");
            DropTable("dbo.WorldEvents");
            DropTable("dbo.EntityWorldEventRelationships");
            DropTable("dbo.EntityWorldEvents");
            DropTable("dbo.EntityEntityRelationshipReasons");
            DropTable("dbo.EntityEntityRelationships");
            DropTable("dbo.EntityEntities");
            DropTable("dbo.EntityDesireReasons");
            DropTable("dbo.Desires");
            DropTable("dbo.EntityDesires");
            DropTable("dbo.Subjects");
            DropTable("dbo.Conventions");
            DropTable("dbo.EntityConventions");
            DropTable("dbo.EntityBeliefs");
            DropTable("dbo.Entities");
            DropTable("dbo.BeliefEntities");
            DropTable("dbo.Beliefs");
            CreateIndex("dbo.Factions", "WorldId");
            CreateIndex("dbo.Characters", "WorldId");
            AddForeignKey("dbo.Factions", "WorldId", "dbo.Worlds", "WorldId", cascadeDelete: true);
            AddForeignKey("dbo.Characters", "WorldId", "dbo.Worlds", "WorldId", cascadeDelete: true);
        }
    }
}
