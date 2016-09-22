namespace WorldForging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class C : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntityEntityRelationshipReasons", "EntityEntityRelationship_EntityRelationshipId", "dbo.EntityRelationships");
            DropForeignKey("dbo.EntityEntities", "EntityEntityRelationship_EntityRelationshipId", "dbo.EntityRelationships");
            DropIndex("dbo.EntityEntities", new[] { "EntityEntityRelationship_EntityRelationshipId" });
            DropIndex("dbo.EntityEntityRelationshipReasons", new[] { "EntityEntityRelationship_EntityRelationshipId" });
            RenameColumn(table: "dbo.EntityEntities", name: "EntityEntityRelationship_EntityRelationshipId", newName: "EntityRelationshipId");
            CreateTable(
                "dbo.EntityRelationshipReasons",
                c => new
                    {
                        EntityRelationshipReasonId = c.Int(nullable: false, identity: true),
                        EntityRelationshipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntityRelationshipReasonId)
                .ForeignKey("dbo.EntityRelationships", t => t.EntityRelationshipId, cascadeDelete: true)
                .Index(t => t.EntityRelationshipId);
            
            AlterColumn("dbo.EntityEntities", "EntityRelationshipId", c => c.Int(nullable: false));
            CreateIndex("dbo.EntityEntities", "EntityRelationshipId");
            AddForeignKey("dbo.EntityEntities", "EntityRelationshipId", "dbo.EntityRelationships", "EntityRelationshipId", cascadeDelete: true);
            DropColumn("dbo.EntityEntities", "EntityEntityRelationshipId");
            DropTable("dbo.EntityEntityRelationshipReasons");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EntityEntityRelationshipReasons",
                c => new
                    {
                        EntityEntityRelationshipReasonId = c.Int(nullable: false, identity: true),
                        EntityEntityRelationshipId = c.Int(nullable: false),
                        EntityEntityRelationship_EntityRelationshipId = c.Int(),
                    })
                .PrimaryKey(t => t.EntityEntityRelationshipReasonId);
            
            AddColumn("dbo.EntityEntities", "EntityEntityRelationshipId", c => c.Int(nullable: false));
            DropForeignKey("dbo.EntityEntities", "EntityRelationshipId", "dbo.EntityRelationships");
            DropForeignKey("dbo.EntityRelationshipReasons", "EntityRelationshipId", "dbo.EntityRelationships");
            DropIndex("dbo.EntityRelationshipReasons", new[] { "EntityRelationshipId" });
            DropIndex("dbo.EntityEntities", new[] { "EntityRelationshipId" });
            AlterColumn("dbo.EntityEntities", "EntityRelationshipId", c => c.Int());
            DropTable("dbo.EntityRelationshipReasons");
            RenameColumn(table: "dbo.EntityEntities", name: "EntityRelationshipId", newName: "EntityEntityRelationship_EntityRelationshipId");
            CreateIndex("dbo.EntityEntityRelationshipReasons", "EntityEntityRelationship_EntityRelationshipId");
            CreateIndex("dbo.EntityEntities", "EntityEntityRelationship_EntityRelationshipId");
            AddForeignKey("dbo.EntityEntities", "EntityEntityRelationship_EntityRelationshipId", "dbo.EntityRelationships", "EntityRelationshipId");
            AddForeignKey("dbo.EntityEntityRelationshipReasons", "EntityEntityRelationship_EntityRelationshipId", "dbo.EntityRelationships", "EntityRelationshipId");
        }
    }
}
