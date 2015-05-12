using System.Data.Entity;

namespace Sample11.Config
{
    public static class InitEF
    {
        public static void StartDb()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, Configuration>());
            using (var context = new MyContext())
            {
                context.Database.Initialize(force: true);
            }
        }
    }
}