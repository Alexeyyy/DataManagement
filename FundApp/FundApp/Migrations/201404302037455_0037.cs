namespace FundApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0037 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PartnershipRequests", "Secretary_ID", "dbo.Secretaries");
            DropIndex("dbo.PartnershipRequests", new[] { "Secretary_ID" });
            AlterColumn("dbo.PartnershipRequests", "Secretary_ID", c => c.Int());
            AddForeignKey("dbo.PartnershipRequests", "Secretary_ID", "dbo.Secretaries", "ID");
            CreateIndex("dbo.PartnershipRequests", "Secretary_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PartnershipRequests", new[] { "Secretary_ID" });
            DropForeignKey("dbo.PartnershipRequests", "Secretary_ID", "dbo.Secretaries");
            AlterColumn("dbo.PartnershipRequests", "Secretary_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.PartnershipRequests", "Secretary_ID");
            AddForeignKey("dbo.PartnershipRequests", "Secretary_ID", "dbo.Secretaries", "ID", cascadeDelete: true);
        }
    }
}
