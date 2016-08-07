namespace WorldForging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeditemtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Desires", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Desires", "Description");
        }
    }
}
