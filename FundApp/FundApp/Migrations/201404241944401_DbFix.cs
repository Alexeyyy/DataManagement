namespace FundApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrganisationDeptors", "Ecologist_ID", "dbo.Ecologists");
            DropIndex("dbo.OrganisationDeptors", new[] { "Ecologist_ID" });
            DropColumn("dbo.OrganisationDeptors", "Ecologist_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrganisationDeptors", "Ecologist_ID", c => c.Int());
            CreateIndex("dbo.OrganisationDeptors", "Ecologist_ID");
            AddForeignKey("dbo.OrganisationDeptors", "Ecologist_ID", "dbo.Ecologists", "ID");
        }
    }
}
