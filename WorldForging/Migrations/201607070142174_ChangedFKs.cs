namespace WorldForging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "World_WorldId", "dbo.Worlds");
            DropForeignKey("dbo.Factions", "World_WorldId", "dbo.Worlds");
            DropIndex("dbo.Characters", new[] { "World_WorldId" });
            DropIndex("dbo.Factions", new[] { "World_WorldId" });
            RenameColumn(table: "dbo.Characters", name: "World_WorldId", newName: "WorldId");
            RenameColumn(table: "dbo.Factions", name: "World_WorldId", newName: "WorldId");
            RenameColumn(table: "dbo.Worlds", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Worlds", name: "IX_User_Id", newName: "IX_UserId");
            AlterColumn("dbo.Characters", "WorldId", c => c.Int(nullable: false));
            AlterColumn("dbo.Factions", "WorldId", c => c.Int(nullable: false));
            CreateIndex("dbo.Characters", "WorldId");
            CreateIndex("dbo.Factions", "WorldId");
            AddForeignKey("dbo.Characters", "WorldId", "dbo.Worlds", "WorldId", cascadeDelete: true);
            AddForeignKey("dbo.Factions", "WorldId", "dbo.Worlds", "WorldId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factions", "WorldId", "dbo.Worlds");
            DropForeignKey("dbo.Characters", "WorldId", "dbo.Worlds");
            DropIndex("dbo.Factions", new[] { "WorldId" });
            DropIndex("dbo.Characters", new[] { "WorldId" });
            AlterColumn("dbo.Factions", "WorldId", c => c.Int());
            AlterColumn("dbo.Characters", "WorldId", c => c.Int());
            RenameIndex(table: "dbo.Worlds", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Worlds", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Factions", name: "WorldId", newName: "World_WorldId");
            RenameColumn(table: "dbo.Characters", name: "WorldId", newName: "World_WorldId");
            CreateIndex("dbo.Factions", "World_WorldId");
            CreateIndex("dbo.Characters", "World_WorldId");
            AddForeignKey("dbo.Factions", "World_WorldId", "dbo.Worlds", "WorldId");
            AddForeignKey("dbo.Characters", "World_WorldId", "dbo.Worlds", "WorldId");
        }
    }
}
