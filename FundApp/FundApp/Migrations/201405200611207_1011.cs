namespace FundApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1011 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Complaints", "Partner_ID", "dbo.Partners");
            DropForeignKey("dbo.Partners", "ID", "dbo.Users");
            DropForeignKey("dbo.Partners", "Secretary_ID", "dbo.Secretaries");
            DropIndex("dbo.Complaints", new[] { "Partner_ID" });
            DropIndex("dbo.Partners", new[] { "ID" });
            DropIndex("dbo.Partners", new[] { "Secretary_ID" });
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "CompanyName", c => c.String());
            AddColumn("dbo.Users", "Description", c => c.String());
            AddColumn("dbo.Users", "Reason", c => c.String());
            AddColumn("dbo.Users", "IsSolved", c => c.Boolean());
            AddColumn("dbo.Users", "Discriminator", c => c.String(maxLength: 128));
            AddColumn("dbo.Users", "Secretary_ID", c => c.Int());
            AddForeignKey("dbo.Users", "Secretary_ID", "dbo.Secretaries", "ID");
            AddForeignKey("dbo.Complaints", "Partner_ID", "dbo.Users", "ID");
            CreateIndex("dbo.Users", "Secretary_ID");
            CreateIndex("dbo.Complaints", "Partner_ID");
            DropTable("dbo.Partners");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Secretary_ID = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Reason = c.String(nullable: false),
                        IsSolved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropIndex("dbo.Complaints", new[] { "Partner_ID" });
            DropIndex("dbo.Users", new[] { "Secretary_ID" });
            DropForeignKey("dbo.Complaints", "Partner_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "Secretary_ID", "dbo.Secretaries");
            DropColumn("dbo.Users", "Secretary_ID");
            DropColumn("dbo.Users", "Discriminator");
            DropColumn("dbo.Users", "IsSolved");
            DropColumn("dbo.Users", "Reason");
            DropColumn("dbo.Users", "Description");
            DropColumn("dbo.Users", "CompanyName");
            DropColumn("dbo.Users", "Address");
            CreateIndex("dbo.Partners", "Secretary_ID");
            CreateIndex("dbo.Partners", "ID");
            CreateIndex("dbo.Complaints", "Partner_ID");
            AddForeignKey("dbo.Partners", "Secretary_ID", "dbo.Secretaries", "ID");
            AddForeignKey("dbo.Partners", "ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Complaints", "Partner_ID", "dbo.Partners", "ID");
        }
    }
}
