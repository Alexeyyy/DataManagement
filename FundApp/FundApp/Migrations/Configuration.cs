namespace FundApp.Migrations
{
    using System;
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

            db.Partners.AddOrUpdate(
                n => n.CompanyName,
                new Partner { Name = "����", Surname = "����������", FatherName = "���������", Sex = false, Email = "golobokova_ann@gmail.ru", Login = "ann", Password = "ann", BirthDate = DateTime.Now.AddYears(-20), RegistrationDate = DateTime.Now, CompanyName = "AnnCompanyGroup", Address = "���������", Description = "�� ��������, ������������ ������� �������." }
            );

            db.SaveChanges();

            db.PartnershipRequests.AddOrUpdate(
                n => n.Reason,
                new PartnershipRequest { Reason = "����� �������������� � ������ ����� � ������������ ������. �� ����� �������.", IsAccepted = true, Partner = db.Partners.First(n => n.CompanyName == "AnnCompanyGroup"), Secretary = db.Secretaries.First(n => n.Surname == "��������") }
            );

            db.SaveChanges();

            db.Complaints.AddOrUpdate(
                n => n.Title,
                new Complaint { Title = "����������� �����", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����." },
                new Complaint { Title = "����������� ����� ������", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����." },
                new Complaint { Title = "������ ������ �� �����", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����." },
                new Complaint { Title = "������� � ��������� �� �������", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����." },
                new Complaint { Title = "������ ������ � ������", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����." }
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
                new Section { Title = "����� ���� ��������. ����� 1.", SpotsCount = 40, StartLessonsTime = DateTime.Now.AddDays(5), Ecologist = db.Ecologists.First(n => n.Surname == "��������"), Description = "����� ����������� ����. �������� ��� ��� ��� ������ ���������� ����������� � ���������. ����� ������ ������������� �������������", LessonsCount = 15 },
                new Section { Title = "����� ���� ��������. ����� 2.", SpotsCount = 20, StartLessonsTime = DateTime.Now.AddDays(10), Ecologist = db.Ecologists.First(n => n.Surname == "���������"), Description = "����� ����������� ����. ����������� ����������� �����. �������� ��� ����������� �������������. ����� ����� ������ ������������� �������������", LessonsCount = 10 },
                new Section { Title = "����� ���� ��������. ����� 3.", SpotsCount = 15, StartLessonsTime = DateTime.Now.AddDays(15), Ecologist = db.Ecologists.First(), Description = "����� ����������� ����. ����������� ����������� �����. �������� ��� �����-����������� �������������. ����� ����� ������ ������������� �������������", LessonsCount = 5 }
            );

            db.SaveChanges();

            foreach (var s in db.Sections)
            {
                s.CalculateFreeSpots();
            }

            db.SaveChanges();

            db.Achivements.AddOrUpdate(
                n => n.Title,
                new Achievement { Title = "����� � ������ �������!", Description = "��� ���������������� ��������� ����� ��� ������� ������� ����� � ��������� �����. ���� ���������� ����������������� �������.", EcologicalProblem = db.EcologicalProblems.First(n => n.Title == "������ ������ � ������"), Administrator = db.Administrators.First(), PhotoFile = null, PhotoType = string.Empty },
                new Achievement { Title = "����� �� ����� �������!", Description = "��� ���������������� ��������� ����� ��� ������� ������� ����� � ��������� �����. ���� ���������� ����������������� �������.", EcologicalProblem = db.EcologicalProblems.First(n => n.Title == "������ ������ �� �����"), Administrator = db.Administrators.First(n => n.Surname == "�������"), PhotoFile = null, PhotoType = string.Empty }
            );

            db.SaveChanges();

            db.Complaints.AddOrUpdate(
                n => n.Title,
                new Complaint { Title = "������1", AppearingDate = DateTime.Now, Creator = db.Ecologists.First(), Description = "description1111" }
            );

            db.SaveChanges();

            db.Achivements.AddOrUpdate(
                n => n.Title,
                new Achievement { Administrator = db.Administrators.First(), EcologicalProblem = db.EcologicalProblems.First(), Title = "����������1", Description = "gfhjsdgfjsgjfghsdjfjsdgfjsdgfhsdjfgsdjf sd f sdf sd f ds f sd f sd f" }
            );

            db.SaveChanges();
        }
    }
}
