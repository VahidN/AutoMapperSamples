using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Omu.ValueInjecter;

namespace Sample06
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
    }

    class Program
    {
        public static void RunActionMeasurePerformance(Action action)
        {
            GC.Collect();
            var initMemUsage = Process.GetCurrentProcess().WorkingSet64;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            var currentMemUsage = Process.GetCurrentProcess().WorkingSet64;
            var memUsage = currentMemUsage - initMemUsage;
            if (memUsage < 0) memUsage = 0;
            Console.WriteLine("Elapsed time: {0}, Memory Usage: {1:N2} KB", stopwatch.Elapsed.TotalSeconds, memUsage / 1024);
        }


        static void Main(string[] args)
        {
            var length = 1000000;
            var users = new List<User>(length);
            for (var i = 0; i < length; i++)
            {

                var user = new User
                {
                    Id = i,
                    UserName = string.Format("User{0}", i),
                    Password = string.Format("1{0}2{0}", i),
                    LastLogin = DateTime.Now
                };
                users.Add(user);
            }

            Console.WriteLine("Custom mapping");
            RunActionMeasurePerformance(() =>
            {
                var userList =
                    users.Select(
                        o =>
                            new User
                            {
                                Id = o.Id,
                                UserName = o.UserName,
                                Password = o.Password,
                                LastLogin = o.LastLogin
                            }).ToList();
            });

            Console.WriteLine("EmitMapper mapping");
            RunActionMeasurePerformance(() =>
            {
                var map = EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<User, User>();
                var emitUsers = users.Select(o => map.Map(o)).ToList();
            });

            Console.WriteLine("ValueInjecter mapping");
            RunActionMeasurePerformance(() =>
            {
                var valueUsers = users.Select(o => (User)new User().InjectFrom(o)).ToList();
            });

            Console.WriteLine("AutoMapper mapping, DynamicMap using List");

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMissingTypeMaps = true; // = Mapper.DynamicMap
            });
            var mapper = config.CreateMapper();

            RunActionMeasurePerformance(() =>
            {
                var userMap = mapper.Map<List<User>>(users).ToList();
            });

            Console.WriteLine("AutoMapper mapping, Map using List");
            RunActionMeasurePerformance(() =>
            {
                var userMap = mapper.Map<List<User>>(users).ToList();
            });

            Console.WriteLine("AutoMapper mapping, Map using IEnumerable");
            RunActionMeasurePerformance(() =>
            {
                var userMap = mapper.Map<IEnumerable<User>>(users).ToList();
            });


            Console.WriteLine("Press a key ...");
            Console.ReadKey();
        }
    }
}