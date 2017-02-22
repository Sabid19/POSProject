namespace POSWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.Account;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<POSWeb.Models.Account.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(POSWeb.Models.Account.ApplicationDbContext context)
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
            AddRoles(context);
        }

        private void AddRoles(ApplicationDbContext context)
        {
            List<string> roles = new List<string>() { "Admin", "User" };
            foreach (var item in roles)
            {
                IdentityRole identityRole = context.Roles.FirstOrDefault(x => x.Name == item);
                if (identityRole==null)
                {
                    identityRole = new IdentityRole(item);
                    context.Roles.Add(identityRole);
                }
            }
            context.SaveChanges();
        }
    }
}
