using System.Data.Entity.Migrations;
using System.Linq;
using Sample08.Models;

namespace Sample08.Config
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
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
            {
                LastName = "LastName 1",
                FirstName = "FirstName 1"
            });

            context.Students.Add(new Student
            {
                LastName = "LastName 2",
                FirstName = "FirstName 2"
            });

            base.Seed(context);
        }
    }
}