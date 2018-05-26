using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NDC.UI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private const string USR = "elyor.blog@gmail.com";
        private const string PSW = "123456";

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var user = userManager.FindById(USR);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    Email = USR,
                    UserName = USR,
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };
                userManager.Create(user, PSW);
            }
        }
    }
}