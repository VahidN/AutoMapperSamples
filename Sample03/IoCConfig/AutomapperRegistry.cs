﻿using System;
using System.Linq;
using AutoMapper;
using StructureMap;

namespace Sample03.IoCConfig
{
    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            var currentAssembly = typeof(AutoMapperRegistry).Assembly;
            var profiles =
                currentAssembly.GetTypes()
                    .Where(t => typeof(Profile).IsAssignableFrom(t))
                    .Select(t => (Profile)Activator.CreateInstance(t));

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            For<MapperConfiguration>().Use(config);
            For<IMapper>().Use(ctx => ctx.GetInstance<MapperConfiguration>().CreateMapper(ctx.GetInstance));
        }
    }
}