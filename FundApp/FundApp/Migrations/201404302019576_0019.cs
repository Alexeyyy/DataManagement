namespace FundApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartnershipRequests", "Reason", c => c.String(nullable: false));
            DropColumn("dbo.PartnershipRequests", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartnershipRequests", "Description", c => c.String());
            DropColumn("dbo.PartnershipRequests", "Reason");
        }
    }
}
