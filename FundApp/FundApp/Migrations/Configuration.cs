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

        protected override void Seed(FundApp.Models.FundContext context)
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
            context.Administrators.AddOrUpdate(
                n => n.Surname,
                new Administrator { Name = "�������", Surname = "�������", FatherName = "���������", Sex = true, BirthDate = DateTime.Now.AddYears(-20), RegistrationDate = DateTime.Now, Login = "alexey", Password = "0000", Email = "a.zhelepov@yandex.ru", PhoneNumber = "44-67-77"},
                new Administrator { Name = "���������", Surname = "�������", FatherName = "����������", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "vladdy", Password = "moses", Email = "vladdy@yandex.ru", PhoneNumber = "34-20-23"}
            );

            context.SaveChanges();

            context.Secretaries.AddOrUpdate(
                n => n.Surname,
                new Secretary { Name = "�������", Surname = "��������", FatherName = "����������", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "evgwed", Password = "qwerty", Email = "evgeni@yandex.ru", IndividualTaxNumber = "9089605302943"}
            );

            context.SaveChanges();

            context.Ecologists.AddOrUpdate(
                n => n.Surname,
                new Ecologist { Name = "�������", Surname = "���������", FatherName = "��������", Sex = true, BirthDate = DateTime.Now.AddYears(-17), RegistrationDate = DateTime.Now, Login = "demarvel", Password = "hariton", Email = "demarvel@yandex.ru", InterestsSphere = "�������� � ��������. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", Education = "�����. ��������� �������������� ������ � ����������. ������", DistrictLocation = "��������������� �������"},
                new Ecologist { Name = "�����", Surname = "��������", FatherName = "��������", Sex = true, BirthDate = DateTime.Now.AddYears(-18), RegistrationDate = DateTime.Now, Login = "muravei", Password = "muravei", Email = "muravey@yandex.ru", InterestsSphere = "�����, ���� � �����. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", Education = "�����. ��������� �������������� ������ � ����������. ������", DistrictLocation = "������������� ����"},
                new Ecologist { Name = "������", Surname = "������������", FatherName = "���������", Sex = true, BirthDate = DateTime.Now.AddYears(-20), RegistrationDate = DateTime.Now, Login = "sergey", Password = "sergey", Email = "smerechinskiy@yandex.ru", InterestsSphere = "����������� ������� ������� �������� � ��������. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", Education = "�����. ��������� �������������� ������ � ����������. ������", DistrictLocation = "���������� �������"},
                new Ecologist { Name = "�������", Surname = "������", FatherName = "����������", Sex = true, BirthDate = DateTime.Now.AddYears(-21), RegistrationDate = DateTime.Now, Login = "dima", Password = "dima", Email = "dimaefimov@yandex.ru", InterestsSphere = "����. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", Education = "�����. ��������� �������������� ������ � ����������. ������", DistrictLocation = "������"},
                new Ecologist { Name = "����", Surname = "��������", FatherName = "�����������", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "zagaichuk", Password = "ziga", Email = "zagaichuk@yandex.ru", InterestsSphere = "���. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", Education = "�����. ��������� �������������� ������ � ����������. ������", DistrictLocation = "����"}            
            );

            context.SaveChanges();

            context.Complaints.AddOrUpdate(
                n => n.Title,
                new Complaint { Title = "����������� �����", Creator = context.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����." },
                new Complaint { Title = "����������� ����� ������", Creator = context.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����." },
                new Complaint { Title = "������ ������ �� �����", Creator = context.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����." },
                new Complaint { Title = "������� � ��������� �� �������", Creator = context.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����." },
                new Complaint { Title = "������ ������ � ������", Creator = context.Ecologists.First(), AppearingDate = DateTime.Now, Description = "����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����." }
            );

            context.SaveChanges();

            context.EcologicalProblems.AddOrUpdate(
                n => n.Title,
                new EcologicalProblem { Title = "����������� ���� ����", Description = "�������� ����������� ���� ����. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.",  RequiredSum = 2000000, IsSolved = false, PublicationDate = DateTime.Now.AddYears(-3), PhotoFile = null, PhotoType = string.Empty, Creator = context.Ecologists.First(n => n.Surname == "���������"), Complaint = context.Complaints.First(n => n.Title == "����������� �����")},
                new EcologicalProblem { Title = "����������� ����� ������", Description = "�������� ����������� ����� ������. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", RequiredSum = 2000000, IsSolved = false, PublicationDate = DateTime.Now.AddYears(-3), PhotoFile = null, PhotoType = string.Empty, Creator = context.Ecologists.First(n => n.Surname == "������"), Complaint = context.Complaints.First(n => n.Title == "����������� ����� ������") },
                new EcologicalProblem { Title = "������ ������ �� �����", Description = "�������� ������ �������. Lorem Ipsum - ��� �����-\"����\", ����� ������������ � ������ � ���-�������. Lorem Ipsum �������� ����������� ����� ��� ������� �� �������� � ������ XVI ����. � �� ����� ����� ���������� �������� ������ ������� ��������� �������� � ���� �������, ��������� Lorem Ipsum ��� ���������� ��������.", RequiredSum = 2000000, IsSolved = true, PublicationDate = DateTime.Now.AddYears(-3), PhotoFile = null, PhotoType = string.Empty, Creator = context.Ecologists.First(n => n.Surname == "������"), Complaint = context.Complaints.First(n => n.Title == "������ ������ �� �����") },
                new EcologicalProblem { Title = "������ ������ � ������", Description = "������ ����� � ������. ������ ��������� ������ ����� \"����\". ���� �� ������", RequiredSum = 100000000, IsSolved = true, PublicationDate = DateTime.Now.AddYears(-1), PhotoFile = null, PhotoType = string.Empty, Creator = context.Ecologists.First(n => n.Surname == "������������"), Complaint = context.Complaints.First(n => n.Title == "������ ������ � ������")}
                );

            context.SaveChanges();

            context.Sections.AddOrUpdate(
                n => n.Title,
                new Section { Title = "����� ���� ��������. ����� 1.", SpotsCount = 40, StartLessonsTime = DateTime.Now.AddDays(5), Ecologist = context.Ecologists.First(n => n.Surname == "��������"), Description = "����� ����������� ����. �������� ��� ��� ��� ������ ���������� ����������� � ���������. ����� ������ ������������� �������������", LessonsCount = 15 },
                new Section { Title = "����� ���� ��������. ����� 2.", SpotsCount = 20, StartLessonsTime = DateTime.Now.AddDays(10), Ecologist = context.Ecologists.First(n => n.Surname == "���������"), Description = "����� ����������� ����. ����������� ����������� �����. �������� ��� ����������� �������������. ����� ����� ������ ������������� �������������", LessonsCount = 10 },
                new Section { Title = "����� ���� ��������. ����� 3.", SpotsCount = 15, StartLessonsTime = DateTime.Now.AddDays(15), Ecologist = context.Ecologists.First(), Description = "����� ����������� ����. ����������� ����������� �����. �������� ��� �����-����������� �������������. ����� ����� ������ ������������� �������������", LessonsCount = 5 }
            );

            context.SaveChanges();

            foreach (var s in context.Sections)
            {
                s.CalculateFreeSpots();
            }

            context.SaveChanges();

            context.Achivements.AddOrUpdate(
                n => n.Title,
                new Achievement { Title = "����� � ������ �������!", Description = "��� ���������������� ��������� ����� ��� ������� ������� ����� � ��������� �����. ���� ���������� ����������������� �������.", EcologicalProblem = context.EcologicalProblems.First(n => n.Title == "������ ������ � ������"), Administrator = context.Administrators.First(), PhotoFile = null, PhotoType = string.Empty },
                new Achievement { Title = "����� �� ����� �������!", Description = "��� ���������������� ��������� ����� ��� ������� ������� ����� � ��������� �����. ���� ���������� ����������������� �������.", EcologicalProblem = context.EcologicalProblems.First(n => n.Title == "������ ������ �� �����"), Administrator = context.Administrators.First(n => n.Surname == "�������"), PhotoFile = null, PhotoType = string.Empty }
            );

            context.SaveChanges();

            context.Complaints.AddOrUpdate(
                n => n.Title,
                new Complaint { Title = "������1", AppearingDate = DateTime.Now, Creator = context.Ecologists.First(), Description = "description1111" }
            );

            context.SaveChanges();

            context.Achivements.AddOrUpdate(
                n => n.Title,
                new Achievement { Administrator = context.Administrators.First(), EcologicalProblem = context.EcologicalProblems.First(), Title = "����������1", Description = "gfhjsdgfjsgjfghsdjfjsdgfjsdgfhsdjfgsdjf sd f sdf sd f ds f sd f sd f" }
            );

            context.SaveChanges();
        }
    }
}
