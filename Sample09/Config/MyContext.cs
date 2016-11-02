using System;
using System.Data.Entity;
using Sample09.Models;

namespace Sample09.Config
{
    public class MyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAttribute> CustomerAttributes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public MyContext()
            : base("Connection1")
        {
            this.Database.Log = sql => Console.Write(sql);
        }
    }
}