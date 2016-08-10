namespace WorldForging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Separatedentitiesandsubjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entities", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Entities", new[] { "SubjectId" });
            CreateTable(
                "dbo.BeliefEntities",
                c => new
                    {
                        BeliefEntityId = c.Int(nullable: false, identity: true),
                        BeliefId = c.Int(nullable: false),
                        EntityId = c.Int(),
                    })
                .PrimaryKey(t => t.BeliefEntityId)
                .ForeignKey("dbo.Beliefs", t => t.BeliefId, cascadeDelete: true)
                .ForeignKey("dbo.Entities", t => t.EntityId)
                .Index(t => t.BeliefId)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.DesireEntities",
                c => new
                    {
                        DesireEntityId = c.Int(nullable: false, identity: true),
                        DesireId = c.Int(nullable: false),
                        EntityId = c.Int(),
                    })
                .PrimaryKey(t => t.DesireEntityId)
                .ForeignKey("dbo.Desires", t => t.DesireId, cascadeDelete: true)
                .ForeignKey("dbo.Entities", t => t.EntityId)
                .Index(t => t.DesireId)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.ReasonEntities",
                c => new
                    {
                        ReasonEntityId = c.Int(nullable: false, identity: true),
                        ReasonId = c.Int(nullable: false),
                        EntityId = c.Int(),
                    })
                .PrimaryKey(t => t.ReasonEntityId)
                .ForeignKey("dbo.Entities", t => t.EntityId)
                .ForeignKey("dbo.Reasons", t => t.ReasonId, cascadeDelete: true)
                .Index(t => t.ReasonId)
                .Index(t => t.EntityId);
            
            AddColumn("dbo.Entities", "WorldId", c => c.Int());
            CreateIndex("dbo.Entities", "WorldId");
            AddForeignKey("dbo.Entities", "WorldId", "dbo.Worlds", "WorldId");
            DropColumn("dbo.Entities", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entities", "SubjectId", c => c.Int());
            DropForeignKey("dbo.ReasonEntities", "ReasonId", "dbo.Reasons");
            DropForeignKey("dbo.ReasonEntities", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.BeliefEntities", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.DesireEntities", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.DesireEntities", "DesireId", "dbo.Desires");
            DropForeignKey("dbo.Entities", "WorldId", "dbo.Worlds");
            DropForeignKey("dbo.BeliefEntities", "BeliefId", "dbo.Beliefs");
            DropIndex("dbo.ReasonEntities", new[] { "EntityId" });
            DropIndex("dbo.ReasonEntities", new[] { "ReasonId" });
            DropIndex("dbo.DesireEntities", new[] { "EntityId" });
            DropIndex("dbo.DesireEntities", new[] { "DesireId" });
            DropIndex("dbo.Entities", new[] { "WorldId" });
            DropIndex("dbo.BeliefEntities", new[] { "EntityId" });
            DropIndex("dbo.BeliefEntities", new[] { "BeliefId" });
            DropColumn("dbo.Entities", "WorldId");
            DropTable("dbo.ReasonEntities");
            DropTable("dbo.DesireEntities");
            DropTable("dbo.BeliefEntities");
            CreateIndex("dbo.Entities", "SubjectId");
            AddForeignKey("dbo.Entities", "SubjectId", "dbo.Subjects", "SubjectId");
        }
    }
}
