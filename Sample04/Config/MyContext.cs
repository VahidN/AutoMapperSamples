using System;
using System.Data.Entity;
using Sample04.Models;

namespace Sample04.Config
{
    public class MyContext : DbContext
    {
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<User> Users { get; set; }

        public MyContext()
            : base("Connection1")
        {
            this.Database.Log = sql => Console.Write(sql);
        }
    }
}