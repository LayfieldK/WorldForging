namespace WorldForging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FactionAndCharacter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DescriptionShort = c.String(),
                        World_WorldId = c.Int(),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Worlds", t => t.World_WorldId)
                .Index(t => t.World_WorldId);
            
            CreateTable(
                "dbo.Factions",
                c => new
                    {
                        FactionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DescriptionShort = c.String(),
                        World_WorldId = c.Int(),
                    })
                .PrimaryKey(t => t.FactionId)
                .ForeignKey("dbo.Worlds", t => t.World_WorldId)
                .Index(t => t.World_WorldId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factions", "World_WorldId", "dbo.Worlds");
            DropForeignKey("dbo.Characters", "World_WorldId", "dbo.Worlds");
            DropIndex("dbo.Factions", new[] { "World_WorldId" });
            DropIndex("dbo.Characters", new[] { "World_WorldId" });
            DropTable("dbo.Factions");
            DropTable("dbo.Characters");
        }
    }
}
