using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DelegateDecompiler;
using Sample09.Config;
using Sample09.MappingsConfig.Profiles;
using Sample09.ViewModels;
using System.Data.Entity;

namespace Sample09
{
    //Customer Domain Object

    class Program
    {
        static void Main(string[] args)
        {
            InitEF.StartDb();

            var config = new MapperConfiguration(cfg => // In Application_Start()
            {
                cfg.AddProfile<OrderProfile>();
                cfg.AddProfile<OrderItemsProfile>();
                cfg.AddProfile<CustomerProfile>();
                cfg.AddProfile<CustomerAttributeProfile>();
            });
            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();

            printCustomers(mapper);
            printOrders(mapper);
            printOrderItems(mapper);
            printOrderDates(mapper);
            printOrderShips(mapper);
            printNumberOfOrders(mapper);
            printCustomerAttributeViewModelNormally();
            printCustomerAttributeViewModelUsingAutoMapper(mapper);
        }

        private static void printCustomerAttributeViewModelUsingAutoMapper(IMapper mapper)
        {
            using (var context = new MyContext())
            {
                var list = mapper.Map<ICollection<CustomerAttributeViewModel>>(
                                context.Customers.Include(x => x.CustomerAttributes).ToList());

                foreach (var item in list)
                {
                        Console.WriteLine("{0} - {1}", item.CustomerName, item.AttributeName);
                }
            }
        }

        private static void printCustomerAttributeViewModelNormally()
        {
            using (var context = new MyContext())
            {
                var list = context.Customers
                                    .SelectMany(customer => customer.CustomerAttributes.Select(attribute =>
                                                        new CustomerAttributeViewModel
                                                        {
                                                            AttributeName = attribute.Name,
                                                            CustomerName = customer.FullName
                                                        }))
                                    .Decompile() // for FullName
                                    .ToList();

                foreach (var item in list)
                {
                    Console.WriteLine("{0} - {1}", item.CustomerName, item.AttributeName);
                }
            }
        }

        /// <summary>
        /// Custom formatter
        /// </summary>
        private static void printNumberOfOrders(IMapper mapper)
        {
            using (var context = new MyContext())
            {
                var viewOrders = context.Orders
                    .ProjectTo<NumberOfOrderViewModel>(mapper.ConfigurationProvider)
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
        private static void printOrderShips(IMapper mapper)
        {
            using (var context = new MyContext())
            {
                var viewOrders = context.Orders
                    .ProjectTo<OrderShipViewModel>(mapper.ConfigurationProvider)
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
        private static void printOrderDates(IMapper mapper)
        {
            using (var context = new MyContext())
            {
                var viewOrder = context.Orders
                    .ProjectTo<OrderDateViewModel>(mapper.ConfigurationProvider)
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
        private static void printOrderItems(IMapper mapper)
        {
            using (var context = new MyContext())
            {
                var viewOrders = context.Orders
                    .ProjectTo<OrderViewModel>(mapper.ConfigurationProvider)
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
        private static void printOrders(IMapper mapper)
        {
            using (var context = new MyContext())
            {
                var viewOrders = context.Orders
                    .ProjectTo<OrderViewModel>(mapper.ConfigurationProvider)
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
        private static void printCustomers(IMapper mapper)
        {
            using (var context = new MyContext())
            {
                var viewCustomers = context.Customers
                    .ProjectTo<CustomerViewModel>(mapper.ConfigurationProvider)
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