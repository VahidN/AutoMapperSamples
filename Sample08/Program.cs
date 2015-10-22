using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DelegateDecompiler;
using PagedList;
using Sample08.Config;
using Sample08.MappingProfiles;
using Sample08.Models;

namespace Sample08
{
    class Program
    {
        static void Main(string[] args)
        {
            InitEF.StartDb();
            Mapper.Initialize(cfg => // In Application_Start()
            {
                cfg.AddProfile<StudentsProfile>();
            });

            getNamesDoesNotWork();
            getFullNamesDoesNotWork();
            getFullNamesDoesWork();
            getPagedFullNamesDoesWork();
        }

        private static void getPagedFullNamesDoesWork()
        {
            using (var context = new MyContext())
            {
                var students = context.Students
                    .ProjectTo<StudentViewModel>()
                    .OrderBy(x => x.Id)
                    .Decompile()
                    .ToPagedList(pageNumber: 1, pageSize: 1);
                /*
                    SELECT
                        [Project1].[Id] AS [Id],
                        [Project1].[C1] AS [C1]
                        FROM ( SELECT
                            [Extent1].[Id] AS [Id],
                            [Extent1].[LastName] + N', ' + [Extent1].[FirstName] AS [C1]
                            FROM [dbo].[Students] AS [Extent1]
                        )  AS [Project1]
                        ORDER BY [Project1].[Id] ASC
                        OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY
                 */

                foreach (var student in students)
                {
                    Console.WriteLine(student.FullName);
                }
            }
        }

        private static void getFullNamesDoesWork()
        {
            using (var context = new MyContext())
            {
                var students = context.Students
                    .ProjectTo<StudentViewModel>()
                    .Decompile()
                    .ToList();

                /*
                SELECT
                    [Extent1].[Id] AS [Id],
                    [Extent1].[LastName] + N', ' + [Extent1].[FirstName] AS [C1]
                    FROM [dbo].[Students] AS [Extent1]
                 */

                foreach (var student in students)
                {
                    Console.WriteLine(student.FullName);
                }
            }
        }

        private static void getFullNamesDoesNotWork()
        {
            using (var context = new MyContext())
            {
                try
                {
                    var students = context.Students.ProjectTo<StudentViewModel>().ToList();
                    foreach (var student in students)
                    {
                        Console.WriteLine(student.FullName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private static void getNamesDoesNotWork()
        {
            using (var context = new MyContext())
            {
                try
                {
                    var fullNames = context.Students.Select(x => x.FullName).ToList();
                    foreach (var name in fullNames)
                    {
                        Console.WriteLine(name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}