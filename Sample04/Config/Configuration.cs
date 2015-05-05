using System.Data.Entity.Migrations;
using System.Linq;
using Sample04.Models;

namespace Sample04.Config
{
    public class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyContext context)
        {
            if (context.Advertisements.Any())
            {
                return;
            }

            var user1 = context.Users.Add(new User
            {
                Name = "Test 1"
            });


            context.Users.Add(new User
            {
                Name = "Test 2"
            });

            context.Advertisements.Add(new Advertisement
            {
                Title = "Ad 1",
                Description = "bla bla ......... 1",
                User = user1
            });

            context.Advertisements.Add(new Advertisement
            {
                Title = "Ad 2",
                Description = "bla bla ......... 2",
                User = user1
            });

            base.Seed(context);
        }
    }
}