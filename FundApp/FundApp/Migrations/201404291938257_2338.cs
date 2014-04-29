namespace FundApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2338 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sections", "Title");
        }
    }
}
