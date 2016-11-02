using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Sample09.Models;

namespace Sample09.Config
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
            if (context.Customers.Any())
            {
                return;
            }

            var attr1 = context.CustomerAttributes.Add(new CustomerAttribute
            {
                Name = "Grumpy"
            });

            var attr2 = context.CustomerAttributes.Add(new CustomerAttribute
            {
                Name = "Rich"
            });

            var attr3 = context.CustomerAttributes.Add(new CustomerAttribute
            {
                Name = "Poor"
            });

            var customer1 = context.Customers.Add(new Customer
            {
                Bio = null,
                FirstName = "F 1",
                LastName = "L 1",
                CustomerAttributes = new List<CustomerAttribute> { attr1, attr2 }
            });

            var customer2 = context.Customers.Add(new Customer
            {
                Bio = "Bio 2",
                FirstName = "F 2",
                LastName = "L 2",
                CustomerAttributes = new List<CustomerAttribute> { attr1, attr3 }
            });

            var order1 = context.Orders.Add(new Order
            {
                Customer = customer1,
                OrderNo = "no 1",
                PurchaseDate = DateTime.Now,
                ShipToHomeAddress = true
            });

            var order2 = context.Orders.Add(new Order
            {
                Customer = customer1,
                OrderNo = "no 2",
                PurchaseDate = DateTime.Now,
                ShipToHomeAddress = true
            });

            var order3 = context.Orders.Add(new Order
            {
                Customer = customer2,
                OrderNo = "no 3",
                PurchaseDate = DateTime.Now,
                ShipToHomeAddress = false
            });

            var orderItem1 = context.OrderItems.Add(new OrderItem
            {
                Order = order1,
                Name = "Ord 1",
                Price = 1234,
                Quantity = 2
            });

            var orderItem2 = context.OrderItems.Add(new OrderItem
            {
                Order = order1,
                Name = "Ord 2",
                Price = 124,
                Quantity = 1
            });

            var orderItem3 = context.OrderItems.Add(new OrderItem
            {
                Order = order2,
                Name = "Ord 3",
                Price = 1244,
                Quantity = 1
            });

            var orderItem4 = context.OrderItems.Add(new OrderItem
            {
                Order = order3,
                Name = "Ord 4",
                Price = 12445,
                Quantity = 3
            });

            base.Seed(context);
        }
    }
}