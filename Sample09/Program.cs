using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DelegateDecompiler;
using Sample09.Config;
using Sample09.MappingsConfig.Profiles;
using Sample09.ViewModels;

namespace Sample09
{
    //Customer Domain Object

    class Program
    {
        static void Main(string[] args)
        {
            InitEF.StartDb();

            Mapper.Initialize(cfg => // In Application_Start()
            {
                cfg.AddProfile<OrderProfile>();
                cfg.AddProfile<OrderItemsProfile>();
                cfg.AddProfile<CustomerProfile>();
            });
            Mapper.AssertConfigurationIsValid();


            printCustomers();
            printOrders();
            printOrderItems();
            printOrderDates();
            printOrderShips();
            printNumberOfOrders();
        }

        /// <summary>
        /// Custom formatter
        /// </summary>
        private static void printNumberOfOrders()
        {
            using (var context = new MyContext())
            {
                var viewOrders = context.Orders
                    .ProjectTo<NumberOfOrderViewModel>()
                    .Decompile()
                    .ToList();
                // don't use
                // var viewOrders = Mapper.Map<IEnumerable<Order>, IEnumerable<NumberOfOrderViewModel>>(dbOrders);
                foreach (var order in viewOrders)
                {
                    Console.WriteLine("{0} - {1}", order.CustomerName, order.NumberOfOrders);
                }
            }
        }

        /// <summary>
        /// Custom Resolver
        /// </summary>
        private static void printOrderShips()
        {
            using (var context = new MyContext())
            {
                var viewOrders = context.Orders
                    .ProjectTo<OrderShipViewModel>()
                    .Decompile()
                    .ToList();
                // don't use
                // var viewOrders = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderShipViewModel>>(dbOrders);
                foreach (var order in viewOrders)
                {
                    Console.WriteLine("{0} - {1}", order.CustomerName, order.ShipHome);
                }
            }
        }

        /// <summary>
        /// Projection
        /// </summary>
        private static void printOrderDates()
        {
            using (var context = new MyContext())
            {
                var viewOrder = context.Orders
                    .ProjectTo<OrderDateViewModel>()
                    .Decompile()
                    .FirstOrDefault();
                // don't use
                // var viewOrder = Mapper.Map<Order, OrderDateViewModel>(dbOrder);

                if (viewOrder != null)
                {
                    Console.WriteLine("{0}, {1}:{2}", viewOrder.CustomerName, viewOrder.PurchaseHour, viewOrder.PurchaseMinute);
                }
            }
        }


        /// <summary>
        /// Nested Mapping
        /// </summary>
        private static void printOrderItems()
        {
            using (var context = new MyContext())
            {
                var viewOrders = context.Orders
                    .ProjectTo<OrderViewModel>()
                    .Decompile()
                    .ToList();
                // don't use
                // var viewOrders = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(dbOrders);
                foreach (var order in viewOrders)
                {
                    Console.WriteLine("{0} - {1} - {2}", order.OrderNumber, order.CustomerName, order.Total);
                    foreach (var item in order.OrderItems)
                    {
                        Console.WriteLine("({0}) {1} - {2}", item.Quantity, item.Name, item.Price);
                    }
                }
            }
        }

        /// <summary>
        /// Flattening
        /// </summary>
        private static void printOrders()
        {
            using (var context = new MyContext())
            {
                var viewOrders = context.Orders
                    .ProjectTo<OrderViewModel>()
                    .Decompile()
                    .ToList();
                // don't use
                // var viewOrders = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(dbOrders);
                foreach (var order in viewOrders)
                {
                    Console.WriteLine("{0} - {1} - {2}", order.OrderNumber, order.CustomerName, order.Total);
                }
            }
        }

        /// <summary>
        /// NullSubstitution
        /// </summary>
        private static void printCustomers()
        {
            using (var context = new MyContext())
            {
                var viewCustomers = context.Customers
                    .ProjectTo<CustomerViewModel>()
                    .Decompile()
                    .ToList();
                // don't use
                // var viewCustomers = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(dbCustomers);
                foreach (var customer in viewCustomers)
                {
                    Console.WriteLine("{0} - {1}", customer.CustomerName, customer.Bio);
                }
            }
        }
    }
}