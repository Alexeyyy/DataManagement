namespace FundApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2309 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PartnershipRequests", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PartnershipRequests", "Description", c => c.Int(nullable: false));
        }
    }
}
