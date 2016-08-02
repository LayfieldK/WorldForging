namespace WorldForging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntityEntities", "Entity1Id", "dbo.Entities");
            DropIndex("dbo.EntityEntities", new[] { "Entity1Id" });
            AlterColumn("dbo.EntityEntities", "Entity1Id", c => c.Int(nullable: false));
            CreateIndex("dbo.EntityEntities", "Entity1Id");
            AddForeignKey("dbo.EntityEntities", "Entity1Id", "dbo.Entities", "EntityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntityEntities", "Entity1Id", "dbo.Entities");
            DropIndex("dbo.EntityEntities", new[] { "Entity1Id" });
            AlterColumn("dbo.EntityEntities", "Entity1Id", c => c.Int());
            CreateIndex("dbo.EntityEntities", "Entity1Id");
            AddForeignKey("dbo.EntityEntities", "Entity1Id", "dbo.Entities", "EntityId");
        }
    }
}
