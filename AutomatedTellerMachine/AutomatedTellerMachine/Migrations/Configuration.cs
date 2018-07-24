namespace AutomatedTellerMachine.Migrations
{
    using AutomatedTellerMachine.Models;
    using AutomatedTellerMachine.Services;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutomatedTellerMachine.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AutomatedTellerMachine.Models.ApplicationDbContext";
        }

        protected override void Seed(AutomatedTellerMachine.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if(!context.Users.Any(t=>t.UserName == "admin@test.com"))
            {
                var user = new ApplicationUser { UserName = "admin@test.com", Email = "admin@test.com" };
                userManager.Create(user, "passW0rd!");

                var service = new CheckingAccountService(context);
                service.CreateCheckingAccount("admin", "user", user.Id, 1000);

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }

            context.Transactions.Add(new Transaction { Amount = 300, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 301, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 302, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 303, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 304, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 300, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 301, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 302, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 303, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 304, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 300, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 301, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 302, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 303, CheckingAccountId = 4 });
            context.Transactions.Add(new Transaction { Amount = 304, CheckingAccountId = 4 });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
