namespace MVC5project.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC5project.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC5project.Models.ApplicationDbContext";
        }

        protected override void Seed(MVC5project.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "sallen"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "sallen" };

                manager.Create(user, "password");
            }
            //var hasher = new PasswordHasher();
            //context.Users.AddOrUpdate(u => u.UserName,
            //        new ApplicationUser { UserName = "sallen", PasswordHash = hasher.HashPassword("password") }
            //    );
        }
    }
}
