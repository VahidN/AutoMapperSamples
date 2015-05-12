using System.Data.Entity.Migrations;
using System.Linq;
using Sample11.Models;

namespace Sample11.Config
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
            if (context.Users.Any())
            {
                return;
            }

            var user1 = context.Users.Add(new SiteUser
            {
                Name = "Test 1"
            });

            var email1 = context.Emails.Add(new Email
            {
                Text = "tst@site.com",
                SiteUser = user1
            });

            var address1 = context.Addresses.Add(new Address
            {
                Text = "Address 1",
                SiteUser = user1
            });


            var user2 = context.Users.Add(new SiteUser
            {
                Name = "Test 2"
            });

            var email2 = context.Emails.Add(new Email
            {
                Text = "name@site.com",
                SiteUser = user2
            });

            var address2 = context.Addresses.Add(new Address
            {
                Text = "Address 2",
                SiteUser = user2
            });


            base.Seed(context);
        }
    }
}