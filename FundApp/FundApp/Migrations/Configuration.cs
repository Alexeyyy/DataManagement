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

            db.RankUsers.AddOrUpdate(
                n => n.Surname,
                new RankUser{Name = "Равиль", Surname = "Альмяшев", FatherName = "Камилевич", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "ravil", Password = "12345", Email = "zagaichuk@yandex.ru", Information = "Я простой юзер!"},
                new RankUser{Name = "Петр", Surname = "Сергеев", FatherName = "Сергеевич", Sex = true, BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, Login = "serg", Password = "12345", Email = "sergeev_piotr@yandex.ru", Information = "Я простой пользователь!"},
                new RankUser{Name = "Игорь", Surname = "Александров", FatherName = "Игоревич", Sex = true, BirthDate = DateTime.Now.AddYears(-12), RegistrationDate = DateTime.Now, Login = "igor", Password = "12345", Email = "mail1@yandex.ru", Information = "Я пользователь!"},
                new RankUser{Name = "Иван", Surname = "Волынов", FatherName = "Пантелеевич", Sex = true, BirthDate = DateTime.Now.AddYears(-14), RegistrationDate = DateTime.Now, Login = "volina", Password = "12345", Email = "mail2@yandex.ru", Information = "Я пользователь!"},
                new RankUser{Name = "Камиль", Surname = "Валиуллов", FatherName = "Акимович", Sex = true, BirthDate = DateTime.Now.AddYears(-15), RegistrationDate = DateTime.Now, Login = "valiullov", Password = "12345", Email = "mail3@yandex.ru", Information = "Я пользователь!"},
                new RankUser{Name = "Олег", Surname = "Седов", FatherName = "Моисеевич", Sex = true, BirthDate = DateTime.Now.AddYears(-13), RegistrationDate = DateTime.Now, Login = "sedov", Password = "12345", Email = "mail4@yandex.ru", Information = "Я пользователь!"},
                new RankUser{Name = "Виктор", Surname = "Князев", FatherName = "Валерьевич", Sex = true, BirthDate = DateTime.Now.AddYears(-9), RegistrationDate = DateTime.Now, Login = "kniazev", Password = "12345", Email = "mail5@yandex.ru", Information = "Я пользователь!"},
                new RankUser{Name = "Вадим", Surname = "Карайченцев", FatherName = "Иванович", Sex = true, BirthDate = DateTime.Now.AddYears(-20), RegistrationDate = DateTime.Now, Login = "caraichencev", Password = "12345", Email = "mail6@yandex.ru", Information = "Я пользователь!"},
                new RankUser{Name = "Зоя", Surname = "Царева", FatherName = "Алексеевна", Sex = false, BirthDate = DateTime.Now.AddYears(-43), RegistrationDate = DateTime.Now, Login = "careva", Password = "12345", Email = "mail7@yandex.ru", Information = "Я пользователь!"},
                new RankUser{Name = "Иван", Surname = "Павлов", FatherName = "Игоревич", Sex = true, BirthDate = DateTime.Now.AddYears(-54), RegistrationDate = DateTime.Now, Login = "pavlov", Password = "12345", Email = "mail8@yandex.ru", Information = "Я пользователь!"}
                );

            db.SaveChanges();

            db.Partners.AddOrUpdate(
                n => n.CompanyName,
                new Partner { Name = "Анна", Surname = "Голобокова", FatherName = "Андреевна", Sex = false, Email = "golobokova_ann@gmail.ru", Login = "ann", Password = "ann", BirthDate = DateTime.Now.AddYears(-20), RegistrationDate = DateTime.Now, CompanyName = "AnnCompanyGroup", Address = "Ульяновск", Description = "Мы компания, занимающаяся помощью природе.", Reason = "Хотим сделать мир лучше. Мы очень богатые", IsSolved = true, Secretary = db.Secretaries.First(n => n.Surname == "Прохоров")},
                new Partner { Name = "Василий", Surname = "Гапонов", FatherName = "Леонидович", Sex = true, Email = "gaponov@gmail.ru", Login = "gaponov", Password = "12345", BirthDate = DateTime.Now.AddYears(-25), RegistrationDate = DateTime.Now, CompanyName = "GaponovCompany", Address = "Ульяновск", Description = "Мы компания, занимающаяся помощью природе.", Reason = "Хотим сделать мир лучше. Мы очень богатые", IsSolved = false, Secretary = db.Secretaries.First(n => n.Surname == "Прохоров") },
                new Partner { Name = "Александр", Surname = "Романов", FatherName = "Николаевич", Sex = true, Email = "romanov@gmail.ru", Login = "romanov", Password = "12345", BirthDate = DateTime.Now.AddYears(-19), RegistrationDate = DateTime.Now, CompanyName = "GaponovCompany", Address = "Ульяновск", Description = "Мы компания, занимающаяся помощью природе.", Reason = "Хотим сделать мир лучше. Мы очень богатые", IsSolved = false, Secretary = db.Secretaries.First(n => n.Surname == "Прохоров") }
            );

            db.SaveChanges();

            db.Complaints.AddOrUpdate(
                n => n.Title,
                new Complaint { Title = "Загрязнение Амура", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века.", IsHidden = true },
                new Complaint { Title = "Загрязнение озера Байкал", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века.", IsHidden = true },
                new Complaint { Title = "Лесные пожары на Алтае", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века.", IsHidden = true },
                new Complaint { Title = "Выбросы в атмосферу на Кавказе", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века.", IsHidden = false },
                new Complaint { Title = "Лесные пожары в Сибири", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века.", IsHidden = true },
                new Complaint { Title = "Загрязнение Оки", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века.", IsHidden = false },
                new Complaint { Title = "Выбросы BP в Мексиканский залив", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века.", IsHidden = false },
                new Complaint { Title = "Загрязнение Волги", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века.", IsHidden = false },
                new Complaint { Title = "Лесной пожар в Калифорнии", Creator = db.Ecologists.First(), AppearingDate = DateTime.Now, Description = "Часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века.", IsHidden = false }
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
                new Section { Title = "Общий курс экологии. Часть 1.", SpotsCount = 40, StartLessonsTime = DateTime.Now.AddDays(5), Ecologist = db.Ecologists.First(n => n.Surname == "Загайчук"), Description = "Очень интересеный курс. Подойдет для тех кто только начинается знакомиться с экологией. Ведет просто замечательный преподаватель", LessonsCount = 15, Participants = db.RankUsers.ToList() },
                new Section { Title = "Общий курс экологии. Часть 2.", SpotsCount = 20, StartLessonsTime = DateTime.Now.AddDays(10), Ecologist = db.Ecologists.First(n => n.Surname == "Харитонов"), Description = "Очень интересеный курс. Продолжение предыдущего курса. Подойдет для продвинутых пользователей. Ведет также просто замечательный преподаватель", LessonsCount = 10 },
                new Section { Title = "Общий курс экологии. Часть 3.", SpotsCount = 15, StartLessonsTime = DateTime.Now.AddDays(15), Ecologist = db.Ecologists.First(), Description = "Очень интересеный курс. Продолжение предыдущего курса. Подойдет для супер-продвинутых пользователей. Ведет также просто замечательный преподаватель", LessonsCount = 5 },
                new Section { Title = "Стихии", SpotsCount = 25, StartLessonsTime = DateTime.Now.AddDays(180), Ecologist = db.Ecologists.ToList()[1], Description = "Очень интересеный курс. Продолжение предыдущего курса. Подойдет для супер-продвинутых пользователей. Ведет также просто замечательный преподаватель", LessonsCount = 5 },
                new Section { Title = "Метеорология", SpotsCount = 30, StartLessonsTime = DateTime.Now.AddDays(15), Ecologist = db.Ecologists.ToList()[3], Description = "Очень интересный курс.", LessonsCount = 5 },
                new Section { Title = "Загрязнение и люди", SpotsCount = 40, StartLessonsTime = DateTime.Now.AddDays(15), Ecologist = db.Ecologists.ToList()[2], Description = "Очень интересный курс.", LessonsCount = 25 },
                new Section { Title = "Кто мы?", SpotsCount = 10, StartLessonsTime = DateTime.Now.AddDays(15), Ecologist = db.Ecologists.ToList()[1], Description = "Очень интересный курс.", LessonsCount = 35 },
                new Section { Title = "Роль человека в окружающей среде.", SpotsCount = 15, StartLessonsTime = DateTime.Now.AddDays(15), Ecologist = db.Ecologists.ToList()[1], Description = "Очень интересный курс.", LessonsCount = 15 }
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
                new Achievement { Title = "Пожар в Сибири потушен!", Description = "При непосредственной поддержке фонда был потушен большой пожар в Сибирских лесах. Фонд удостоился правительственной награды.", EcologicalProblem = db.EcologicalProblems.First(n => n.Title == "Лесные пожары в Сибири"), Administrator = db.Administrators.First(), PhotoFile = null, PhotoType = string.Empty },
                new Achievement { Title = "Пожар на Алтае потушен!", Description = "При непосредственной поддержке фонда был потушен большой пожар в Алтайских лесах. Фонд удостоился правительственной награды.", EcologicalProblem = db.EcologicalProblems.First(n => n.Title == "Лесные пожары на Алтае"), Administrator = db.Administrators.First(n => n.Surname == "Моисеев"), PhotoFile = null, PhotoType = string.Empty },
                new Achievement { Title = "Река Амур!", Description = "При непосредственной поддержке фонда был потушен большой пожар в Алтайских лесах. Фонд удостоился правительственной награды.", EcologicalProblem = db.EcologicalProblems.First(n => n.Title == "Загрязнение реки Амур"), Administrator = db.Administrators.First(n => n.Surname == "Моисеев"), PhotoFile = null, PhotoType = string.Empty }
            );

            db.SaveChanges();

            /*db.Complaints.AddOrUpdate(
                n => n.Title,
                new Complaint { Title = "Жалоба1", AppearingDate = DateTime.Now, Creator = db.Ecologists.First(), Description = "description1111", IsHidden = false }
            );

            db.SaveChanges();*/

            db.Councils.AddOrUpdate(
                n => n.Title,
                new Council { Title = "Разбор пожара в Сибири", AssignmentDate = DateTime.Now.AddMonths(-10), Description = "На данном совете будет рассматриваться проблема пожара в Сибири", CounsilResult = true, Ecologists = db.Ecologists.ToList(), Problem = db.EcologicalProblems.First(n => n.Title == "Лесные пожары в Сибири") }
            );

            db.SaveChanges();

            //Организации-штрафники
            db.OrganisationDeptors.AddOrUpdate(
                n => n.Name,
                new OrganisationDeptor { Name = "Петр Петрович", Reason = "Поджог леса в Сибири", PayTime = DateTime.Now.AddDays(100), FineAmount = 10000000, IsPayed = false, Complaint = db.Complaints.First(n => n.Title == "Лесные пожары в Сибири"), Email = "petr@email.ru", ResponsiblePerson = db.Secretaries.First() }
            );

            db.SaveChanges();

            DbCommand cmd = null;
            db.Database.Connection.Open();
            cmd = db.Database.Connection.CreateCommand();
        
            //1. Хранимая процедура - возвращает должников, до срока выплаты которых остается @day_count дней  
            cmd.CommandText = @"IF  EXISTS 
                                (SELECT * FROM sys.objects 
                                 WHERE object_id = OBJECT_ID(N'[dbo].[GetCrucialDebtor]') AND type in (N'P', N'PC'))
                                DROP PROCEDURE [dbo].[GetCrucialDebtor]";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"
                            CREATE PROCEDURE [dbo].[GetCrucialDebtor] 
	                            @day_count int
                            AS
                            BEGIN
                                BEGIN TRANSACTION;
	                            SET NOCOUNT ON;
	                            SELECT * FROM [dbo].[OrganisationDeptors] WHERE (PayTime <= DATEADD(DAY, @day_count, GETDATE()) AND IsPayed = 0)
                                COMMIT TRANSACTION;
                            END
                            ";
            cmd.ExecuteNonQuery();

            //2. Хранимая процедура - возвращает экологические проблемы, опубликованные в течение указанного числа дней
            cmd.CommandText = @"IF  EXISTS 
                                (SELECT * FROM sys.objects 
                                 WHERE object_id = OBJECT_ID(N'[dbo].[GetEcologicalProblems]') AND type in (N'P', N'PC'))
                                DROP PROCEDURE [dbo].[GetEcologicalProblems]";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE PROCEDURE [dbo].[GetEcologicalProblems]
	                                @days_range int
                                AS
                                BEGIN
	                                BEGIN TRANSACTION;
                                    SET NOCOUNT ON;
                                    SELECT * FROM [dbo].[EcologicalProblems] WHERE (PublicationDate >= DATEADD(DAY, -@days_range, GETDATE()))
                                    COMMIT TRANSACTION;
                                END
                                ";
            cmd.ExecuteNonQuery();
                        
            //3. Скалярная функция (возвращает число совершеннолетних пользователей)
            cmd.CommandText = @"IF EXISTS (SELECT *
                               FROM   sys.objects
                               WHERE  object_id = OBJECT_ID(N'[dbo].[GetAdultsQuantity]')
                                      AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
                               DROP FUNCTION [dbo].[GetAdultsQuantity]";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = @"CREATE FUNCTION [dbo].[GetAdultsQuantity]
                                (
                                )
                                RETURNS int
                                AS
                                BEGIN
	                                DECLARE @adults int;
	                                SELECT @adults = COUNT(*)
	                                FROM [dbo].[Users] WHERE BirthDate <= DATEADD(YEAR, -18, GETDATE())
	                                RETURN @adults
                                END";

            cmd.ExecuteNonQuery();

            //4. Скалярная функция (возвращает число несовершеннолетних пользователей)
            cmd.CommandText = @"IF EXISTS (SELECT *
                               FROM   sys.objects
                               WHERE  object_id = OBJECT_ID(N'[dbo].[GetChildrenQuantity]')
                                      AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
                               DROP FUNCTION [dbo].[GetChildrenQuantity]";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE FUNCTION [dbo].[GetChildrenQuantity]
                                (
                                )
                                RETURNS int
                                AS
                                BEGIN
	                                DECLARE @children int;
	                                SELECT @children = COUNT(*)
	                                FROM [dbo].[Users] WHERE BirthDate >= DATEADD(YEAR, -18, GETDATE())
	                                RETURN @children
                                END";

            cmd.ExecuteNonQuery();


            //Триггеры
            //1 Рассчитывает число участников секции, количество свободных мест после регистрации
            cmd.CommandText = @"IF EXISTS (SELECT * FROM sys.triggers
                                WHERE parent_class = 1 AND name = 'CalculateSpotsForInsert')
                                DROP TRIGGER [dbo].[CalculateSpotsForInsert];";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TRIGGER [dbo].[CalculateSpotsForInsert]
                                   ON  [dbo].[SectionRankUsers]
                                   AFTER INSERT
                                AS 
                                BEGIN
	                                SET NOCOUNT ON;
	                                UPDATE dbo.Sections SET ParticipantsCount = (SELECT COUNT(*) FROM [dbo].[SectionRankUsers] WHERE [dbo].[SectionRankUsers].Section_SectionID = SectionId) WHERE SectionId IN (SELECT i.Section_SectionId FROM inserted AS i)
                                    UPDATE dbo.Sections SET FreeSpotsCount =  SpotsCount - (SELECT COUNT(*) FROM [dbo].[SectionRankUsers] WHERE [dbo].[SectionRankUsers].Section_SectionID = SectionId) WHERE SectionId IN (SELECT i.Section_SectionId FROM inserted AS i)
                                END";
            cmd.ExecuteNonQuery();

            //2 Рассчитывает число участников секции, число свободных мест после дерегистрации
            cmd.CommandText = @"IF EXISTS (SELECT * FROM sys.triggers
                                WHERE parent_class = 1 AND name = 'CalculateSpotsForDelete')
                                DROP TRIGGER [dbo].[CalculateSpotsForDelete];";
            cmd.ExecuteNonQuery();

            
            cmd.CommandText = @"CREATE TRIGGER [dbo].[CalculateSpotsForDelete]
                                   ON  [dbo].[SectionRankUsers]
                                   AFTER DELETE
                                AS 
                                BEGIN
	                                SET NOCOUNT ON;
	                                UPDATE dbo.Sections SET ParticipantsCount = (SELECT COUNT(*) FROM [dbo].[SectionRankUsers] WHERE [dbo].[SectionRankUsers].Section_SectionID = SectionId) WHERE SectionId IN (SELECT i.Section_SectionId FROM deleted AS i)
                                    UPDATE dbo.Sections SET FreeSpotsCount =  SpotsCount - (SELECT COUNT(*) FROM [dbo].[SectionRankUsers] WHERE [dbo].[SectionRankUsers].Section_SectionID = SectionId) WHERE SectionId IN (SELECT i.Section_SectionId FROM deleted AS i)
                                END";
            cmd.ExecuteNonQuery();
        }
    }
}
