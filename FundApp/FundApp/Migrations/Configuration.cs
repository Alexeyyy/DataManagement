namespace FundApp.Migrations
{
    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FundApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FundApp.Models.FundContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FundApp.Models.FundContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            db.Administrators.AddOrUpdate(
                n => n.Surname,
                new Administrator { Name = "�������", Surname = "�������", FatherName = "���������", Sex = true, BirthDate = DateTime.Now.AddYears(-20), RegistrationDate = DateTime.Now, Login = "alexey", Password = "0000", Email = "a.zhelepov@yandex.ru", PhoneNumber = "44-67-77"},
                new Administrator { Name = "���������", Surname = "�������", FatherName = "����������", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "vladdy", Password = "moses", Email = "vladdy@yandex.ru", PhoneNumber = "34-20-23"}
            );

            db.SaveChanges();

            db.Secretaries.AddOrUpdate(
                n => n.Surname,
                new Secretary { Name = "�������", Surname = "��������", FatherName = "����������", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "evgwed", Password = "qwerty", Email = "evgeni@yandex.ru", IndividualTaxNumber = "9089605302943"}
            );

            db.SaveChanges();

            db.Ecologists.AddOrUpdate(
                n => n.Surname,
                new Ecologist { Name = "�������", Surname = "���������", FatherName = "��������", Sex = true, BirthDate = DateTime.Now.AddYears(-17), RegistrationDate = DateTime.Now, Login = "demarvel", Password = "hariton", Email = "demarvel@yandex.ru", InterestsSphere = "�������� � ��������. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", Education = "�����. ��������� �������������� ������ � ����������. ������", DistrictLocation = "��������������� �������"},
                new Ecologist { Name = "�����", Surname = "��������", FatherName = "��������", Sex = true, BirthDate = DateTime.Now.AddYears(-18), RegistrationDate = DateTime.Now, Login = "muravei", Password = "muravei", Email = "muravey@yandex.ru", InterestsSphere = "�����, ���� � �����. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", Education = "�����. ��������� �������������� ������ � ����������. ������", DistrictLocation = "������������� ����"},
                new Ecologist { Name = "������", Surname = "������������", FatherName = "���������", Sex = true, BirthDate = DateTime.Now.AddYears(-20), RegistrationDate = DateTime.Now, Login = "sergey", Password = "sergey", Email = "smerechinskiy@yandex.ru", InterestsSphere = "����������� ������� ������� �������� � ��������. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", Education = "�����. ��������� �������������� ������ � ����������. ������", DistrictLocation = "���������� �������"},
                new Ecologist { Name = "�������", Surname = "������", FatherName = "����������", Sex = true, BirthDate = DateTime.Now.AddYears(-21), RegistrationDate = DateTime.Now, Login = "dima", Password = "dima", Email = "dimaefimov@yandex.ru", InterestsSphere = "����. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", Education = "�����. ��������� �������������� ������ � ����������. ������", DistrictLocation = "������"},
                new Ecologist { Name = "����", Surname = "��������", FatherName = "�����������", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "zagaichuk", Password = "ziga", Email = "zagaichuk@yandex.ru", InterestsSphere = "���. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", Education = "�����. ��������� �������������� ������ � ����������. ������", DistrictLocation = "����"}            
            );

            db.SaveChanges();

            db.RankUsers.AddOrUpdate(
                n => n.Surname,
                new RankUser{Name = "������", Surname = "��������", FatherName = "���������", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "ravil", Password = "lalka", Email = "zagaichuk@yandex.ru", Information = "� ������� ����!"},
                new RankUser{Name = "����", Surname = "�������", FatherName = "���������", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "serg", Password = "serg", Email = "zagaichuk@yandex.ru", Information = "� ������� ����!"}
                );

            db.SaveChanges();

            db.Partners.AddOrUpdate(
                n => n.CompanyName,
                new Partner { Name = "����", Surname = "����������", FatherName = "���������", Sex = false, Email = "golobokova_ann@gmail.ru", Login = "ann", Password = "ann", BirthDate = DateTime.Now.AddYears(-20), RegistrationDate = DateTime.Now, CompanyName = "AnnCompanyGroup", Address = "���������", Description = "�� ��������, ������������ ������� �������.", Reason = "����� ������� ��� �����. �� ����� �������", IsSolved = true, Secretary = db.Secretaries.First(n => n.Surname == "��������") }
            );

            db.SaveChanges();

            db.Complaints.AddOrUpdate(
                n => n.Title,
                new Complaint { Title = "����������� �����", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����.", IsHidden = true },
                new Complaint { Title = "����������� ����� ������", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����.", IsHidden = true },
                new Complaint { Title = "������ ������ �� �����", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����.", IsHidden = true },
                new Complaint { Title = "������� � ��������� �� �������", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����.", IsHidden = false },
                new Complaint { Title = "������ ������ � ������", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����.", IsHidden = true }
            );

            db.SaveChanges();

            db.EcologicalProblems.AddOrUpdate(
                n => n.Title,
                new EcologicalProblem { Title = "����������� ���� ����", Description = "�������� ����������� ���� ����. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.",  RequiredSum = 2000000, IsSolved = false, PublicationDate = DateTime.Now.AddYears(-3), PhotoFile = null, PhotoType = string.Empty, Creator = db.Ecologists.First(n => n.Surname == "���������"), Complaint = db.Complaints.First(n => n.Title == "����������� �����")},
                new EcologicalProblem { Title = "����������� ����� ������", Description = "�������� ����������� ����� ������. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", RequiredSum = 2000000, IsSolved = false, PublicationDate = DateTime.Now.AddYears(-3), PhotoFile = null, PhotoType = string.Empty, Creator = db.Ecologists.First(n => n.Surname == "������"), Complaint = db.Complaints.First(n => n.Title == "����������� ����� ������") },
                new EcologicalProblem { Title = "������ ������ �� �����", Description = "�������� ������ �������. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", RequiredSum = 2000000, IsSolved = true, PublicationDate = DateTime.Now.AddYears(-3), PhotoFile = null, PhotoType = string.Empty, Creator = db.Ecologists.First(n => n.Surname == "������"), Complaint = db.Complaints.First(n => n.Title == "������ ������ �� �����") },
                new EcologicalProblem { Title = "������ ������ � ������", Description = "������ ����� � ������. ������ ��������� ������ ����� \"����\". ���� �� ������", RequiredSum = 100000000, IsSolved = true, PublicationDate = DateTime.Now.AddYears(-1), PhotoFile = null, PhotoType = string.Empty, Creator = db.Ecologists.First(n => n.Surname == "������������"), Complaint = db.Complaints.First(n => n.Title == "������ ������ � ������")}
            );

            db.SaveChanges();

            db.Sections.AddOrUpdate(
                n => n.Title,
                new Section { Title = "����� ���� ��������. ����� 1.", SpotsCount = 40, StartLessonsTime = DateTime.Now.AddDays(5), Ecologist = db.Ecologists.First(n => n.Surname == "��������"), Description = "����� ����������� ����. �������� ��� ��� ��� ������ ���������� ����������� � ���������. ����� ������ ������������� �������������", LessonsCount = 15, Participants = db.RankUsers.ToList() },
                new Section { Title = "����� ���� ��������. ����� 2.", SpotsCount = 20, StartLessonsTime = DateTime.Now.AddDays(10), Ecologist = db.Ecologists.First(n => n.Surname == "���������"), Description = "����� ����������� ����. ����������� ����������� �����. �������� ��� ����������� �������������. ����� ����� ������ ������������� �������������", LessonsCount = 10 },
                new Section { Title = "����� ���� ��������. ����� 3.", SpotsCount = 15, StartLessonsTime = DateTime.Now.AddDays(15), Ecologist = db.Ecologists.First(), Description = "����� ����������� ����. ����������� ����������� �����. �������� ��� �����-����������� �������������. ����� ����� ������ ������������� �������������", LessonsCount = 5 }
            );

            db.SaveChanges();

            foreach (var s in db.Sections)
            {
                //s.CalculateParticipantsCount();
                s.CalculateFreeSpots();
            }

            db.SaveChanges();

            db.Achivements.AddOrUpdate(
                n => n.Title,
                new Achievement { Title = "����� � ������ �������!", Description = "��� ���������������� ��������� ����� ��� ������� ������� ����� � ��������� �����. ���� ���������� ����������������� �������.", EcologicalProblem = db.EcologicalProblems.First(n => n.Title == "������ ������ � ������"), Administrator = db.Administrators.First(), PhotoFile = null, PhotoType = string.Empty },
                new Achievement { Title = "����� �� ����� �������!", Description = "��� ���������������� ��������� ����� ��� ������� ������� ����� � ��������� �����. ���� ���������� ����������������� �������.", EcologicalProblem = db.EcologicalProblems.First(n => n.Title == "������ ������ �� �����"), Administrator = db.Administrators.First(n => n.Surname == "�������"), PhotoFile = null, PhotoType = string.Empty },
                new Achievement { Title = "���� ����!", Description = "��� ���������������� ��������� ����� ��� ������� ������� ����� � ��������� �����. ���� ���������� ����������������� �������.", EcologicalProblem = db.EcologicalProblems.First(n => n.Title == "����������� ���� ����"), Administrator = db.Administrators.First(n => n.Surname == "�������"), PhotoFile = null, PhotoType = string.Empty }
            );

            db.SaveChanges();

            db.Complaints.AddOrUpdate(
                n => n.Title,
                new Complaint { Title = "������1", AppearingDate = DateTime.Now, Creator = db.Ecologists.First(), Description = "description1111", IsHidden = false }
            );

            db.SaveChanges();

            db.Councils.AddOrUpdate(
                n => n.Title,
                new Council { Title = "������ ������ � ������", AssignmentDate = DateTime.Now.AddMonths(-10), Description = "�� ������ ������ ����� ��������������� �������� ������ � ������", CounsilResult = true, Ecologists = db.Ecologists.ToList(), Problem = db.EcologicalProblems.First(n => n.Title == "������ ������ � ������") }
            );

            db.SaveChanges();

            //�����������-���������
            db.OrganisationDeptors.AddOrUpdate(
                n => n.Name,
                new OrganisationDeptor { Name = "���� ��������", Reason = "������ ���� � ������", PayTime = DateTime.Now.AddDays(100), FineAmount = 10000000, IsPayed = false, Complaint = db.Complaints.First(n => n.Title == "������ ������ � ������"), Email = "petr@email.ru", ResponsiblePerson = db.Secretaries.First() }
            );

            db.SaveChanges();

            //�������� ���������
            DbCommand cmd = null;
            db.Database.Connection.Open();
            cmd = db.Database.Connection.CreateCommand();
            //if(db.Database.)

            cmd.CommandText = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCrucialDebtor]') AND type in (N'P', N'PC'))
                            DROP PROCEDURE [dbo].[GetCrucialDebtor]";
            cmd.ExecuteNonQuery();


            //1. �������� ��������� - ���������� ���������, �� ����� ������� ������� �������� @day_count ����  
            cmd.CommandText = @"
                            CREATE PROCEDURE [dbo].[GetCrucialDebtor] 
	                            @day_count int
                            AS
                            BEGIN
	                            SET NOCOUNT ON;
	                            SELECT * FROM [dbo].[OrganisationDeptors] WHERE (PayTime <= DATEADD(DAY, @day_count, GETDATE()) AND IsPayed = 0)
                            END
                            ";
            cmd.ExecuteNonQuery();

            //2. �������� ��������� - 


            /*
             CREATE PROCEDURE <Procedure_Name, sysname, ProcedureName> 
	            -- Add the parameters for the stored procedure here
	            <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	            <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
            AS
            BEGIN
	            -- SET NOCOUNT ON added to prevent extra result sets from
	            -- interfering with SELECT statements.
	            SET NOCOUNT ON;

                -- Insert statements for procedure here
	            SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
            END
            GO
             */
        }
    }
}
