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
                new Administrator { Name = "Алексей", Surname = "Желепов", FatherName = "Сергеевич", Sex = true, BirthDate = DateTime.Now.AddYears(-20), RegistrationDate = DateTime.Now, Login = "alexey", Password = "0000", Email = "a.zhelepov@yandex.ru", PhoneNumber = "44-67-77"},
                new Administrator { Name = "Владислав", Surname = "Моисеев", FatherName = "Валерьевич", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "vladdy", Password = "moses", Email = "vladdy@yandex.ru", PhoneNumber = "34-20-23"}
            );

            db.SaveChanges();

            db.Secretaries.AddOrUpdate(
                n => n.Surname,
                new Secretary { Name = "Евгений", Surname = "Прохоров", FatherName = "Эдуардович", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "evgwed", Password = "qwerty", Email = "evgeni@yandex.ru", IndividualTaxNumber = "9089605302943"}
            );

            db.SaveChanges();

            db.Ecologists.AddOrUpdate(
                n => n.Surname,
                new Ecologist { Name = "Алексей", Surname = "Харитонов", FatherName = "Иванович", Sex = true, BirthDate = DateTime.Now.AddYears(-17), RegistrationDate = DateTime.Now, Login = "demarvel", Password = "hariton", Email = "demarvel@yandex.ru", InterestsSphere = "Животные и растения. Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов.", Education = "УлГТУ. Факультет информационных систем и технологий. Высшее", DistrictLocation = "Калининградская область"},
                new Ecologist { Name = "Игорь", Surname = "Муравьев", FatherName = "Игоревич", Sex = true, BirthDate = DateTime.Now.AddYears(-18), RegistrationDate = DateTime.Now, Login = "muravei", Password = "muravei", Email = "muravey@yandex.ru", InterestsSphere = "Океан, море и озера. Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов.", Education = "УлГТУ. Факультет информационных систем и технологий. Высшее", DistrictLocation = "Краснодарский край"},
                new Ecologist { Name = "Сергей", Surname = "Смеречинский", FatherName = "Орестович", Sex = true, BirthDate = DateTime.Now.AddYears(-20), RegistrationDate = DateTime.Now, Login = "sergey", Password = "sergey", Email = "smerechinskiy@yandex.ru", InterestsSphere = "Интересуюсь многими сферами биологии и экологии. Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов.", Education = "УлГТУ. Факультет информационных систем и технологий. Высшее", DistrictLocation = "Смоленская область"},
                new Ecologist { Name = "Дмитрий", Surname = "Ефимов", FatherName = "Дмитриевич", Sex = true, BirthDate = DateTime.Now.AddYears(-21), RegistrationDate = DateTime.Now, Login = "dima", Password = "dima", Email = "dimaefimov@yandex.ru", InterestsSphere = "Горы. Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов.", Education = "УлГТУ. Факультет информационных систем и технологий. Высшее", DistrictLocation = "Кавказ"},
                new Ecologist { Name = "Иван", Surname = "Загайчук", FatherName = "Анатольевич", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "zagaichuk", Password = "ziga", Email = "zagaichuk@yandex.ru", InterestsSphere = "Все. Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов.", Education = "УлГТУ. Факультет информационных систем и технологий. Высшее", DistrictLocation = "Урал"}            
            );

            db.SaveChanges();

            db.Partners.AddOrUpdate(
                n => n.CompanyName,
                new Partner { Name = "Анна", Surname = "Голобокова", FatherName = "Андреевна", Sex = false, Email = "golobokova_ann@gmail.ru", Login = "ann", Password = "ann", BirthDate = DateTime.Now.AddYears(-20), RegistrationDate = DateTime.Now, CompanyName = "AnnCompanyGroup", Address = "Ульяновск", Description = "Мы компания, занимающаяся помощью природе." }
            );

            db.SaveChanges();

            db.PartnershipRequests.AddOrUpdate(
                n => n.Reason,
                new PartnershipRequest { Reason = "Хотим присоединиться к вашему фонду и сотрудничать вместе. Мы очень богатые.", IsAccepted = true, Partner = db.Partners.First(n => n.CompanyName == "AnnCompanyGroup"), Secretary = db.Secretaries.First(n => n.Surname == "Прохоров") }
            );

            db.SaveChanges();

            db.Complaints.AddOrUpdate(
                n => n.Title,
                new Complaint { Title = "Загрязнение Амура", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века." },
                new Complaint { Title = "Загрязнение озера Байкал", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века." },
                new Complaint { Title = "Лесные пожары на Алтае", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века." },
                new Complaint { Title = "Выбросы в атмосферу на Кавказе", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века." },
                new Complaint { Title = "Лесные пожары в Сибири", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века." }
            );

            db.SaveChanges();

            db.EcologicalProblems.AddOrUpdate(
                n => n.Title,
                new EcologicalProblem { Title = "Загрязнение реки Амур", Description = "Проблема загрязнения реки Амур. Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов.",  RequiredSum = 2000000, IsSolved = false, PublicationDate = DateTime.Now.AddYears(-3), PhotoFile = null, PhotoType = string.Empty, Creator = db.Ecologists.First(n => n.Surname == "Харитонов"), Complaint = db.Complaints.First(n => n.Title == "Загрязнение Амура")},
                new EcologicalProblem { Title = "Загрязнение озера Байкал", Description = "Проблема загрязнения озера Байкал. Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов.", RequiredSum = 2000000, IsSolved = false, PublicationDate = DateTime.Now.AddYears(-3), PhotoFile = null, PhotoType = string.Empty, Creator = db.Ecologists.First(n => n.Surname == "Ефимов"), Complaint = db.Complaints.First(n => n.Title == "Загрязнение озера Байкал") },
                new EcologicalProblem { Title = "Лесные пожары на Алтае", Description = "Проблема лесных пожаров. Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов.", RequiredSum = 2000000, IsSolved = true, PublicationDate = DateTime.Now.AddYears(-3), PhotoFile = null, PhotoType = string.Empty, Creator = db.Ecologists.First(n => n.Surname == "Ефимов"), Complaint = db.Complaints.First(n => n.Title == "Лесные пожары на Алтае") },
                new EcologicalProblem { Title = "Лесные пожары в Сибири", Description = "Лесной пожар в Сибири. Срочно требуется помощи фонда \"Слон\". Идем на помощь", RequiredSum = 100000000, IsSolved = true, PublicationDate = DateTime.Now.AddYears(-1), PhotoFile = null, PhotoType = string.Empty, Creator = db.Ecologists.First(n => n.Surname == "Смеречинский"), Complaint = db.Complaints.First(n => n.Title == "Лесные пожары в Сибири")}
                );

            db.SaveChanges();

            db.Sections.AddOrUpdate(
                n => n.Title,
                new Section { Title = "Общий курс экологии. Часть 1.", SpotsCount = 40, StartLessonsTime = DateTime.Now.AddDays(5), Ecologist = db.Ecologists.First(n => n.Surname == "Загайчук"), Description = "Очень интересеный курс. Подойдет для тех кто только начинается знакомиться с экологией. Ведет просто замечательный преподаватель", LessonsCount = 15 },
                new Section { Title = "Общий курс экологии. Часть 2.", SpotsCount = 20, StartLessonsTime = DateTime.Now.AddDays(10), Ecologist = db.Ecologists.First(n => n.Surname == "Харитонов"), Description = "Очень интересеный курс. Продолжение предыдущего курса. Подойдет для продвинутых пользователей. Ведет также просто замечательный преподаватель", LessonsCount = 10 },
                new Section { Title = "Общий курс экологии. Часть 3.", SpotsCount = 15, StartLessonsTime = DateTime.Now.AddDays(15), Ecologist = db.Ecologists.First(), Description = "Очень интересеный курс. Продолжение предыдущего курса. Подойдет для супер-продвинутых пользователей. Ведет также просто замечательный преподаватель", LessonsCount = 5 }
            );

            db.SaveChanges();

            foreach (var s in db.Sections)
            {
                s.CalculateFreeSpots();
            }

            db.SaveChanges();

            db.Achivements.AddOrUpdate(
                n => n.Title,
                new Achievement { Title = "Пожар в Сибири потушен!", Description = "При непосредственной поддержке фонда был потушен большой пожар в Сибирских лесах. Фонд удостоился правительственной награды.", EcologicalProblem = db.EcologicalProblems.First(n => n.Title == "Лесные пожары в Сибири"), Administrator = db.Administrators.First(), PhotoFile = null, PhotoType = string.Empty },
                new Achievement { Title = "Пожар на Алтае потушен!", Description = "При непосредственной поддержке фонда был потушен большой пожар в Алтайских лесах. Фонд удостоился правительственной награды.", EcologicalProblem = db.EcologicalProblems.First(n => n.Title == "Лесные пожары на Алтае"), Administrator = db.Administrators.First(n => n.Surname == "Моисеев"), PhotoFile = null, PhotoType = string.Empty }
            );

            db.SaveChanges();

            db.Complaints.AddOrUpdate(
                n => n.Title,
                new Complaint { Title = "Жалоба1", AppearingDate = DateTime.Now, Creator = db.Ecologists.First(), Description = "description1111" }
            );

            db.SaveChanges();

            db.Achivements.AddOrUpdate(
                n => n.Title,
                new Achievement { Administrator = db.Administrators.First(), EcologicalProblem = db.EcologicalProblems.First(), Title = "Достижение1", Description = "gfhjsdgfjsgjfghsdjfjsdgfjsdgfhsdjfgsdjf sd f sdf sd f ds f sd f sd f" }
            );

            db.SaveChanges();
        }
    }
}
