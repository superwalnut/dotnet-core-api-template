using System;
using AutoMapper;
using DotnetCoreApiDemo.Models;

namespace DotnetCoreApiDemo.AutoMapper
{
    public class ApiAutoMapperProfile : Profile
    {
        public ApiAutoMapperProfile()
        {
            CreateMap<Foo, FooDto>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
