namespace WorldForging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDesireEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DesireEntities",
                c => new
                    {
                        DesireEntityId = c.Int(nullable: false, identity: true),
                        DesireId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DesireEntityId)
                .ForeignKey("dbo.Desires", t => t.DesireId, cascadeDelete: true)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.DesireId)
                .Index(t => t.EntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DesireEntities", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.DesireEntities", "DesireId", "dbo.Desires");
            DropIndex("dbo.DesireEntities", new[] { "EntityId" });
            DropIndex("dbo.DesireEntities", new[] { "DesireId" });
            DropTable("dbo.DesireEntities");
        }
    }
}
