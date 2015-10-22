using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sample11.Config;
using Sample11.MappingsConfig;
using Sample11.ViewModels;

namespace Sample11
{
    class Program
    {
        static void Main(string[] args)
        {
            InitEF.StartDb();

            Mapper.Initialize(cfg => // In Application_Start()
            {
                cfg.AddProfile<TestProfile>();
            });
            Mapper.AssertConfigurationIsValid();

            using (var context = new MyContext())
            {
                var user1 = context.Users
                                   .ProjectTo<UserViewModel>(
                                            parameters: new { },
                                            membersToExpand: viewModel => viewModel.Emails)
                                   .FirstOrDefault();

                /*
                 SELECT
                    [Project1].[Id] AS [Id],
                    [Project1].[Name] AS [Name],
                    [Project1].[C1] AS [C1],
                    [Project1].[Id1] AS [Id1],
                    [Project1].[Text] AS [Text],
                    [Project1].[SiteUserId] AS [SiteUserId]
                    FROM ( SELECT
                        [Limit1].[Id] AS [Id],
                        [Limit1].[Name] AS [Name],
                        [Extent2].[Id] AS [Id1],
                        [Extent2].[Text] AS [Text],
                        [Extent2].[SiteUserId] AS [SiteUserId],
                        CASE WHEN ([Extent2].[Id] IS NULL) THEN CAST(NULL AS int) ELSE 1 END AS [C1]
                        FROM   (SELECT TOP (1) [c].[Id] AS [Id], [c].[Name] AS [Name]
                            FROM [dbo].[SiteUsers] AS [c] ) AS [Limit1]
                        LEFT OUTER JOIN [dbo].[Emails] AS [Extent2] ON [Limit1].[Id] = [Extent2].[SiteUserId]
                    )  AS [Project1]
                    ORDER BY [Project1].[Id] ASC, [Project1].[C1] ASC
                 */

                if (user1 != null)
                {
                    foreach (var email in user1.Emails)
                    {
                        Console.WriteLine(email.Text);
                    }
                }
            }
        }
    }
}