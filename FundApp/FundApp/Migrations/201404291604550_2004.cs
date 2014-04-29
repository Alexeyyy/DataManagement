namespace FundApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                        CompanyName = c.String(),
                        Description = c.String(),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        StartLessonsTime = c.DateTime(nullable: false),
                        ParticipantsCount = c.Int(nullable: false),
                        SpotsCount = c.Int(nullable: false),
                        FreeSpotsCount = c.Int(nullable: false),
                        LessonsCount = c.Int(nullable: false),
                        Ecologist_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SectionID)
                .ForeignKey("dbo.Ecologists", t => t.Ecologist_ID, cascadeDelete: true)
                .Index(t => t.Ecologist_ID);
            
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        ComplaintID = c.Int(nullable: false, identity: true),
                        AppearingDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Creator_ID = c.Int(nullable: false),
                        Partner_ID = c.Int(),
                        Ecologist_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ComplaintID)
                .ForeignKey("dbo.Users", t => t.Creator_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Partner_ID)
                .ForeignKey("dbo.Ecologists", t => t.Ecologist_ID)
                .Index(t => t.Creator_ID)
                .Index(t => t.Partner_ID)
                .Index(t => t.Ecologist_ID);
            
            CreateTable(
                "dbo.OrganisationDeptors",
                c => new
                    {
                        OrganisationDeptorID = c.Int(nullable: false),
                        Reason = c.String(nullable: false),
                        FineAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayTime = c.DateTime(nullable: false),
                        IsPayed = c.Boolean(nullable: false),
                        Email = c.String(),
                        ResponsiblePerson_ID = c.Int(),
                    })
                .PrimaryKey(t => t.OrganisationDeptorID)
                .ForeignKey("dbo.Complaints", t => t.OrganisationDeptorID)
                .ForeignKey("dbo.Secretaries", t => t.ResponsiblePerson_ID)
                .Index(t => t.OrganisationDeptorID)
                .Index(t => t.ResponsiblePerson_ID);
            
            CreateTable(
                "dbo.PartnershipRequests",
                c => new
                    {
                        RequestID = c.Int(nullable: false),
                        Description = c.Int(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        Secretary_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Secretaries", t => t.Secretary_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.RequestID)
                .Index(t => t.Secretary_ID)
                .Index(t => t.RequestID);
            
            CreateTable(
                "dbo.EcologicalProblems",
                c => new
                    {
                        ProblemID = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        PhotoType = c.String(),
                        PhotoFile = c.Binary(),
                        RequiredSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSolved = c.Boolean(nullable: false),
                        Title = c.String(nullable: false),
                        PublicationDate = c.DateTime(nullable: false),
                        Creator_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProblemID)
                .ForeignKey("dbo.Complaints", t => t.ProblemID)
                .ForeignKey("dbo.Ecologists", t => t.Creator_ID, cascadeDelete: true)
                .Index(t => t.ProblemID)
                .Index(t => t.Creator_ID);
            
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        AchievementID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        PhotoType = c.String(),
                        PhotoFile = c.Binary(),
                        Title = c.String(nullable: false),
                        Administrator_ID = c.Int(nullable: false),
                        EcologicalProblem_ProblemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AchievementID)
                .ForeignKey("dbo.Administrators", t => t.Administrator_ID, cascadeDelete: true)
                .ForeignKey("dbo.EcologicalProblems", t => t.EcologicalProblem_ProblemID, cascadeDelete: true)
                .Index(t => t.Administrator_ID)
                .Index(t => t.EcologicalProblem_ProblemID);
            
            CreateTable(
                "dbo.Councils",
                c => new
                    {
                        CouncilID = c.Int(nullable: false, identity: true),
                        AssignmentDate = c.DateTime(nullable: false),
                        CounsilResult = c.Boolean(nullable: false),
                        Description = c.String(nullable: false),
                        Problem_ProblemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CouncilID)
                .ForeignKey("dbo.EcologicalProblems", t => t.Problem_ProblemID, cascadeDelete: true)
                .Index(t => t.Problem_ProblemID);
            
            CreateTable(
                "dbo.SectionRankUsers",
                c => new
                    {
                        Section_SectionID = c.Int(nullable: false),
                        RankUser_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Section_SectionID, t.RankUser_ID })
                .ForeignKey("dbo.Sections", t => t.Section_SectionID, cascadeDelete: true)
                .ForeignKey("dbo.RankUsers", t => t.RankUser_ID, cascadeDelete: true)
                .Index(t => t.Section_SectionID)
                .Index(t => t.RankUser_ID);
            
            CreateTable(
                "dbo.RankUsers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Information = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Secretaries",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        IndividualTaxNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Ecologists",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Council_CouncilID = c.Int(),
                        InterestsSphere = c.String(),
                        Education = c.String(nullable: false),
                        DistrictLocation = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .ForeignKey("dbo.Councils", t => t.Council_CouncilID)
                .Index(t => t.ID)
                .Index(t => t.Council_CouncilID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ecologists", new[] { "Council_CouncilID" });
            DropIndex("dbo.Ecologists", new[] { "ID" });
            DropIndex("dbo.Administrators", new[] { "ID" });
            DropIndex("dbo.Secretaries", new[] { "ID" });
            DropIndex("dbo.RankUsers", new[] { "ID" });
            DropIndex("dbo.SectionRankUsers", new[] { "RankUser_ID" });
            DropIndex("dbo.SectionRankUsers", new[] { "Section_SectionID" });
            DropIndex("dbo.Councils", new[] { "Problem_ProblemID" });
            DropIndex("dbo.Achievements", new[] { "EcologicalProblem_ProblemID" });
            DropIndex("dbo.Achievements", new[] { "Administrator_ID" });
            DropIndex("dbo.EcologicalProblems", new[] { "Creator_ID" });
            DropIndex("dbo.EcologicalProblems", new[] { "ProblemID" });
            DropIndex("dbo.PartnershipRequests", new[] { "RequestID" });
            DropIndex("dbo.PartnershipRequests", new[] { "Secretary_ID" });
            DropIndex("dbo.OrganisationDeptors", new[] { "ResponsiblePerson_ID" });
            DropIndex("dbo.OrganisationDeptors", new[] { "OrganisationDeptorID" });
            DropIndex("dbo.Complaints", new[] { "Ecologist_ID" });
            DropIndex("dbo.Complaints", new[] { "Partner_ID" });
            DropIndex("dbo.Complaints", new[] { "Creator_ID" });
            DropIndex("dbo.Sections", new[] { "Ecologist_ID" });
            DropForeignKey("dbo.Ecologists", "Council_CouncilID", "dbo.Councils");
            DropForeignKey("dbo.Ecologists", "ID", "dbo.Users");
            DropForeignKey("dbo.Administrators", "ID", "dbo.Users");
            DropForeignKey("dbo.Secretaries", "ID", "dbo.Users");
            DropForeignKey("dbo.RankUsers", "ID", "dbo.Users");
            DropForeignKey("dbo.SectionRankUsers", "RankUser_ID", "dbo.RankUsers");
            DropForeignKey("dbo.SectionRankUsers", "Section_SectionID", "dbo.Sections");
            DropForeignKey("dbo.Councils", "Problem_ProblemID", "dbo.EcologicalProblems");
            DropForeignKey("dbo.Achievements", "EcologicalProblem_ProblemID", "dbo.EcologicalProblems");
            DropForeignKey("dbo.Achievements", "Administrator_ID", "dbo.Administrators");
            DropForeignKey("dbo.EcologicalProblems", "Creator_ID", "dbo.Ecologists");
            DropForeignKey("dbo.EcologicalProblems", "ProblemID", "dbo.Complaints");
            DropForeignKey("dbo.PartnershipRequests", "RequestID", "dbo.Users");
            DropForeignKey("dbo.PartnershipRequests", "Secretary_ID", "dbo.Secretaries");
            DropForeignKey("dbo.OrganisationDeptors", "ResponsiblePerson_ID", "dbo.Secretaries");
            DropForeignKey("dbo.OrganisationDeptors", "OrganisationDeptorID", "dbo.Complaints");
            DropForeignKey("dbo.Complaints", "Ecologist_ID", "dbo.Ecologists");
            DropForeignKey("dbo.Complaints", "Partner_ID", "dbo.Users");
            DropForeignKey("dbo.Complaints", "Creator_ID", "dbo.Users");
            DropForeignKey("dbo.Sections", "Ecologist_ID", "dbo.Ecologists");
            DropTable("dbo.Ecologists");
            DropTable("dbo.Administrators");
            DropTable("dbo.Secretaries");
            DropTable("dbo.RankUsers");
            DropTable("dbo.SectionRankUsers");
            DropTable("dbo.Councils");
            DropTable("dbo.Achievements");
            DropTable("dbo.EcologicalProblems");
            DropTable("dbo.PartnershipRequests");
            DropTable("dbo.OrganisationDeptors");
            DropTable("dbo.Complaints");
            DropTable("dbo.Sections");
            DropTable("dbo.Users");
        }
    }
}
