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
                p => p.Login,
                new Administrator { BirthDate = DateTime.Now.AddYears(-18), FatherName = "Sergeevich", Login = "Alexey", Name = "Alexey", Password = "0000", PhoneNumber = "44-67-77", RegistrationDate = DateTime.Now, Sex = true, Email = "a.zhelepov@yandex.ru", Surname = "Zhelepov" }
            );
            context.SaveChanges();
        }
    }
}
