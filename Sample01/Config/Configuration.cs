using System.Data.Entity.Migrations;
using System.Linq;
using Sample01.Models;

namespace Sample01.Config
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

            var user1 = context.Users.Add(new User
            {
                Name = "Test 1",
                Age = 25
            });

            var user2 = context.Users.Add(new User
            {
                Name = "Test 2",
                Age = 35
            });

            context.BlogPosts.Add(new BlogPost
            {
                Title = "Title 1",
                Content = "Content 1",
                User = user1
            });

            context.BlogPosts.Add(new BlogPost
            {
                Title = "Title 11",
                Content = "Content 11",
                User = user1
            });

            context.BlogPosts.Add(new BlogPost
            {
                Title = "Title 2",
                Content = "Content 2",
                User = user2
            });

            base.Seed(context);
        }
    }
}