using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sample10.Config;
using Sample10.MappingsConfig;
using Sample10.ViewModels;

namespace Sample10
{
    class Program
    {
        static void Main(string[] args)
        {
            InitEF.StartDb();

            var config = new MapperConfiguration(cfg => // In Application_Start()
            {
                cfg.AddProfile<TestProfile>();
            });
            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();

            using (var context = new MyContext())
            {
                var user1 = context.Users
                                   .ProjectTo<UserViewModel>(mapper.ConfigurationProvider)
                                   .FirstOrDefault();

                /*
                SELECT
                    [Limit1].[Id] AS [Id],
                    [Limit1].[C1] AS [C1],
                    [Limit1].[C2] AS [C2]
                    FROM ( SELECT TOP (1)
                        [Project1].[Id] AS [Id],
                        CASE WHEN ([Project1].[Name] IS NULL) THEN N'' ELSE [Project1].[Name] END
                     + N'[' +  CAST( [Project1].[Age] AS nvarchar(max)) + N']' AS [C1],
                        [Project1].[C1] AS [C2]
                        FROM ( SELECT
                            [Extent1].[Id] AS [Id],
                            [Extent1].[Name] AS [Name],
                            [Extent1].[Age] AS [Age],
                            (SELECT
                                COUNT(1) AS [A1]
                                FROM [dbo].[BlogPosts] AS [Extent2]
                                WHERE [Extent1].[Id] = [Extent2].[UserId]) AS [C1]
                            FROM [dbo].[Users] AS [Extent1]
                        )  AS [Project1]
                    )  AS [Limit1]
                 */

                if (user1 != null)
                {
                    Console.Write(user1.CustomName);
                    Console.Write(user1.PostsCount);
                }
            }
        }
    }
}