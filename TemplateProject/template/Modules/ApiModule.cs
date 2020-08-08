using System;
namespace DotnetCoreApiDemo.Modules
{
    using Autofac;
    using AutofacSerilogIntegration;
    using DotnetCoreApiDemo.AutoMapper;
    using global::AutoMapper.Contrib.Autofac.DependencyInjection;

    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterLogger();
            builder.AddAutoMapper(x=>x.AddProfile<ApiAutoMapperProfile>());
        }
    }
}
