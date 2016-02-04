using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoMapper;

namespace Sample05
{

    public class SalaryList
    {
        public string User { set; get; }
        public int Month { set; get; }
        public decimal Salary { set; get; }
    }

    public interface ICustomerService
    {
        string Code { get; set; }
        string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
               cfg.CreateMissingTypeMaps = true; // = Mapper.DynamicMap
            });
            var mapper = config.CreateMapper();

            interfaceDynamicMap(mapper);
            iqueryableToGenericList(mapper);
            anonymousListToGenericList(mapper);
            dataTableToGenericList(mapper);
        }

        private static void interfaceDynamicMap(IMapper mapper)
        {
            var anonymousObject = new
            {
                Code = "111",
                Name = "Test 1"
            };
            var result = mapper.Map<ICustomerService>(anonymousObject);
        }

        private static void iqueryableToGenericList(IMapper mapper)
        {
            var query1 = new List<SalaryList>
            {
                new SalaryList
                {
                    User = "User 1",
                    Month = 1,
                    Salary = 100000
                },
                new SalaryList
                {
                    User = "User 2",
                    Month = 1,
                    Salary = 300000
                }
            }.AsQueryable();

            var result = query1.Select(item => mapper.Map<SalaryList>(item)).ToList(); ;
        }

        private static void anonymousListToGenericList(IMapper mapper)
        {
            var anonymousObject = new
            {
                User = "User 1",
                Month = 1,
                Salary = 100000
            };
            var salary = mapper.Map<SalaryList>(anonymousObject);

            var anonymousList = new[]
            {
                new
                {
                    User = "User 1",
                    Month = 1,
                    Salary = 100000
                },
                new
                {
                    User = "User 2",
                    Month = 1,
                    Salary = 300000
                }
            };
            var salaryList = anonymousList.Select(item => mapper.Map<SalaryList>(item)).ToList();
        }

        private static void dataTableToGenericList(IMapper mapper)
        {
            var dataTable = new DataTable("SalaryList");
            dataTable.Columns.Add("User", typeof(string));
            dataTable.Columns.Add("Month", typeof(int));
            dataTable.Columns.Add("Salary", typeof(decimal));

            var rnd = new Random();
            for (var i = 0; i < 200; i++)
                dataTable.Rows.Add(string.Format("User {0}", i), rnd.Next(1, 12), rnd.Next(400, 2000));

            // Moved to: https://github.com/AutoMapper/AutoMapper.Data/
            // PM> Install-Package AutoMapper.Data -Pre
            var salaryList = mapper.Map<IDataReader, List<SalaryList>>(
                dataTable.CreateDataReader());
        }
    }
}