namespace FundApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0029 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PartnershipRequests", "Reason", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PartnershipRequests", "Reason", c => c.String(nullable: false));
        }
    }
}
