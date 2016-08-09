namespace WorldForging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangexxxEntitiestoxxxSubjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BeliefEntities", "BeliefId", "dbo.Beliefs");
            DropForeignKey("dbo.DesireEntities", "DesireId", "dbo.Desires");
            DropForeignKey("dbo.DesireEntities", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.EntityWorldEvents", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.EntityWorldEvents", "EntityWorldEventRelationshipId", "dbo.EntityWorldEventRelationships");
            DropForeignKey("dbo.EntityWorldEvents", "WorldEventId", "dbo.WorldEvents");
            DropForeignKey("dbo.BeliefEntities", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.ReasonEntities", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.ReasonEntities", "ReasonId", "dbo.Reasons");
            DropIndex("dbo.BeliefEntities", new[] { "BeliefId" });
            DropIndex("dbo.BeliefEntities", new[] { "EntityId" });
            DropIndex("dbo.DesireEntities", new[] { "DesireId" });
            DropIndex("dbo.DesireEntities", new[] { "EntityId" });
            DropIndex("dbo.EntityWorldEvents", new[] { "EntityId" });
            DropIndex("dbo.EntityWorldEvents", new[] { "WorldEventId" });
            DropIndex("dbo.EntityWorldEvents", new[] { "EntityWorldEventRelationshipId" });
            DropIndex("dbo.ReasonEntities", new[] { "ReasonId" });
            DropIndex("dbo.ReasonEntities", new[] { "EntityId" });
            CreateTable(
                "dbo.BeliefSubjects",
                c => new
                    {
                        BeliefSubjectId = c.Int(nullable: false, identity: true),
                        BeliefId = c.Int(nullable: false),
                        SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.BeliefSubjectId)
                .ForeignKey("dbo.Beliefs", t => t.BeliefId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.BeliefId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.DesireSubjects",
                c => new
                    {
                        DesireSubjectId = c.Int(nullable: false, identity: true),
                        DesireId = c.Int(nullable: false),
                        SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.DesireSubjectId)
                .ForeignKey("dbo.Desires", t => t.DesireId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.DesireId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.ReasonSubjects",
                c => new
                    {
                        ReasonSubjectId = c.Int(nullable: false, identity: true),
                        ReasonId = c.Int(nullable: false),
                        SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.ReasonSubjectId)
                .ForeignKey("dbo.Reasons", t => t.ReasonId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.ReasonId)
                .Index(t => t.SubjectId);
            
            DropTable("dbo.BeliefEntities");
            DropTable("dbo.DesireEntities");
            DropTable("dbo.EntityWorldEvents");
            DropTable("dbo.EntityWorldEventRelationships");
            DropTable("dbo.ReasonEntities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReasonEntities",
                c => new
                    {
                        ReasonEntityId = c.Int(nullable: false, identity: true),
                        ReasonId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReasonEntityId);
            
            CreateTable(
                "dbo.EntityWorldEventRelationships",
                c => new
                    {
                        EntityWorldEventRelationshipId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.EntityWorldEventRelationshipId);
            
            CreateTable(
                "dbo.EntityWorldEvents",
                c => new
                    {
                        EntityWorldEventId = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        WorldEventId = c.Int(nullable: false),
                        EntityWorldEventRelationshipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntityWorldEventId);
            
            CreateTable(
                "dbo.DesireEntities",
                c => new
                    {
                        DesireEntityId = c.Int(nullable: false, identity: true),
                        DesireId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DesireEntityId);
            
            CreateTable(
                "dbo.BeliefEntities",
                c => new
                    {
                        BeliefEntityId = c.Int(nullable: false, identity: true),
                        BeliefId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeliefEntityId);
            
            DropForeignKey("dbo.ReasonSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.ReasonSubjects", "ReasonId", "dbo.Reasons");
            DropForeignKey("dbo.DesireSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.DesireSubjects", "DesireId", "dbo.Desires");
            DropForeignKey("dbo.BeliefSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.BeliefSubjects", "BeliefId", "dbo.Beliefs");
            DropIndex("dbo.ReasonSubjects", new[] { "SubjectId" });
            DropIndex("dbo.ReasonSubjects", new[] { "ReasonId" });
            DropIndex("dbo.DesireSubjects", new[] { "SubjectId" });
            DropIndex("dbo.DesireSubjects", new[] { "DesireId" });
            DropIndex("dbo.BeliefSubjects", new[] { "SubjectId" });
            DropIndex("dbo.BeliefSubjects", new[] { "BeliefId" });
            DropTable("dbo.ReasonSubjects");
            DropTable("dbo.DesireSubjects");
            DropTable("dbo.BeliefSubjects");
            CreateIndex("dbo.ReasonEntities", "EntityId");
            CreateIndex("dbo.ReasonEntities", "ReasonId");
            CreateIndex("dbo.EntityWorldEvents", "EntityWorldEventRelationshipId");
            CreateIndex("dbo.EntityWorldEvents", "WorldEventId");
            CreateIndex("dbo.EntityWorldEvents", "EntityId");
            CreateIndex("dbo.DesireEntities", "EntityId");
            CreateIndex("dbo.DesireEntities", "DesireId");
            CreateIndex("dbo.BeliefEntities", "EntityId");
            CreateIndex("dbo.BeliefEntities", "BeliefId");
            AddForeignKey("dbo.ReasonEntities", "ReasonId", "dbo.Reasons", "ReasonId", cascadeDelete: true);
            AddForeignKey("dbo.ReasonEntities", "EntityId", "dbo.Entities", "EntityId", cascadeDelete: true);
            AddForeignKey("dbo.BeliefEntities", "EntityId", "dbo.Entities", "EntityId", cascadeDelete: true);
            AddForeignKey("dbo.EntityWorldEvents", "WorldEventId", "dbo.WorldEvents", "WorldEventId", cascadeDelete: true);
            AddForeignKey("dbo.EntityWorldEvents", "EntityWorldEventRelationshipId", "dbo.EntityWorldEventRelationships", "EntityWorldEventRelationshipId", cascadeDelete: true);
            AddForeignKey("dbo.EntityWorldEvents", "EntityId", "dbo.Entities", "EntityId", cascadeDelete: true);
            AddForeignKey("dbo.DesireEntities", "EntityId", "dbo.Entities", "EntityId", cascadeDelete: true);
            AddForeignKey("dbo.DesireEntities", "DesireId", "dbo.Desires", "DesireId", cascadeDelete: true);
            AddForeignKey("dbo.BeliefEntities", "BeliefId", "dbo.Beliefs", "BeliefId", cascadeDelete: true);
        }
    }
}
