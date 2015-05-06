using System;
using System.Data.Entity;
using Sample08.Models;

namespace Sample08.Config
{
    public class MyContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public MyContext()
            : base("Connection1")
        {
            this.Database.Log = sql => Console.Write(sql);
        }
    }
}