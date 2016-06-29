﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Sample04.Config;
using Sample04.Models;
using System.Data.Entity;

namespace Sample04
{
    public class AdvertisementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
    }

    public class UserViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public List<AdvertisementViewModel> Advertisements { get; set; }
    }

    public class TestProfile : Profile
    {
        public TestProfile()
        {
            this.CreateMap<UserViewModel, User>()
                .ForMember(user => user.Advertisements, opt => opt.Ignore());

            this.CreateMap<Advertisement, AdvertisementViewModel>();

            this.CreateMap<AdvertisementViewModel, Advertisement>()
                .ForMember(advertisement => advertisement.Description, opt => opt.Ignore())
                .ForMember(advertisement => advertisement.User, opt => opt.Ignore());
        }
    }

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

            updateCollection(mapper);
            mappToCollection(mapper);
        }

        private static void updateCollection(IMapper mapper)
        {
            var uiUser1 = new UserViewModel
            {
                Id = 1,
                Name = "user 1",
                Advertisements = new List<AdvertisementViewModel>
                {
                    new AdvertisementViewModel
                    {
                        Id = 1,
                        Title = "Adv 1",
                        UserId = 1
                    },
                    new AdvertisementViewModel
                    {
                        Id = 2,
                        Title = "Adv 2",
                        UserId = 1
                    }
                }
            };

            using (var ctx = new MyContext())
            {
                var dbUser1 = ctx.Users.Include(user => user.Advertisements).First(x => x.Id == uiUser1.Id);
                mapper.Map(source: uiUser1, destination: dbUser1);

                foreach (var uiUserAdvertisement in uiUser1.Advertisements)
                {
                    var dbUserAdvertisement = dbUser1.Advertisements.FirstOrDefault(ad => ad.Id == uiUserAdvertisement.Id);
                    if (dbUserAdvertisement == null)
                    {
                        // Add new record
                        var advertisement = mapper.Map<AdvertisementViewModel, Advertisement>(uiUserAdvertisement);
                        dbUser1.Advertisements.Add(advertisement);
                    }
                    else
                    {
                        // Update the existing record
                        mapper.Map(uiUserAdvertisement, dbUserAdvertisement);
                    }
                }

                ctx.SaveChanges();
            }
        }

        private static void mappToCollection(IMapper mapper)
        {
            using (var ctx = new MyContext())
            {
                var adsList = ctx.Advertisements.ToList();
                var adsViewModel = new List<AdvertisementViewModel>();
                mapper.Map(source: adsList, destination: adsViewModel);

                Console.Write(adsViewModel.First().Title);
            }

            //todo: don't use this method, and try using `ctx.Advertisements.Where(...).Project().To<AdvertisementViewModel>().ToList()`
        }
    }
}