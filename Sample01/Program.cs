using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sample01.Config;
using Sample01.Models;

namespace Sample01
{
    public class UserViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public ICollection<BlogPost> BlogPosts { get; set; }
    }

    public class TestProfile : Profile
    {
        public TestProfile()
        {
            this.CreateMap<User, UserViewModel>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InitEF.StartDb();

            var mapperConfiguration = new MapperConfiguration(cfg => // In Application_Start()
            {
                cfg.AddProfile<TestProfile>();
            });
            mapperConfiguration.AssertConfigurationIsValid();
            var mapper = mapperConfiguration.CreateMapper();

            eagerLoadingAutoMapper(mapper);
            eagerLoadingEF(mapper);
            incorrectLazyLoading(mapper);
        }

        private static void incorrectLazyLoading(IMapper mapper)
        {
            Console.WriteLine("\nincorrectLazyLoading");

            using (var context = new MyContext())
            {
                var user1 = context.Users.FirstOrDefault();
                if (user1 != null)
                {
                    var uiUser = new UserViewModel();
                    mapper.Map(source: user1, destination: uiUser);

                    Console.WriteLine(uiUser.Name);
                    foreach (var post in uiUser.BlogPosts)
                    {
                        Console.WriteLine(post.Title);
                    }
                }
            }
        }

        private static void eagerLoadingAutoMapper(IMapper mapper)
        {
            Console.WriteLine("\neagerLoadingAutoMapper");

            using (var context = new MyContext())
            {
                var uiUser = context.Users.ProjectTo<UserViewModel>(mapper.ConfigurationProvider)
                                          .FirstOrDefault();
                if (uiUser != null)
                {
                    Console.WriteLine(uiUser.Name);
                    foreach (var post in uiUser.BlogPosts)
                    {
                        Console.WriteLine(post.Title);
                    }
                }
            }
        }

        private static void eagerLoadingEF(IMapper mapper)
        {
            Console.WriteLine("\neagerLoadingEF");

            using (var context = new MyContext())
            {
                var user1 = context.Users.Include(user => user.BlogPosts)
                                          .FirstOrDefault();
                if (user1 != null)
                {
                    var uiUser = new UserViewModel();
                    mapper.Map(source: user1, destination: uiUser);

                    Console.WriteLine(uiUser.Name);
                    foreach (var post in uiUser.BlogPosts)
                    {
                        Console.WriteLine(post.Title);
                    }
                }
            }
        }
    }
}