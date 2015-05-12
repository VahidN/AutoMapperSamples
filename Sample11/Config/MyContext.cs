using System;
using System.Data.Entity;
using Sample11.Models;

namespace Sample11.Config
{
    public class MyContext : DbContext
    {
        public DbSet<SiteUser> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }

        public MyContext()
            : base("Connection1")
        {
            this.Database.Log = sql => Console.Write(sql);
        }
    }
}