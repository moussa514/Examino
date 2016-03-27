using Microsoft.AspNet.Identity.EntityFramework;

namespace Examino.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Examino.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Examino.Models.ApplicationDbContext context)
        {
            //Ajouter de Roles
            context.Roles.AddOrUpdate(m => m.Name, new IdentityRole { Name = "Student" });
            context.Roles.AddOrUpdate(m => m.Name, new IdentityRole { Name = "Teacher" });
            context.Roles.AddOrUpdate(m => m.Name, new IdentityRole { Name = "Director" });
            context.Roles.AddOrUpdate(m => m.Name, new IdentityRole { Name = "Admin" });
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
        }
    }
}
