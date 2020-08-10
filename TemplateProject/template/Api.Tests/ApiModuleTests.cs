using Autofac;
using Autofac.Builder;
using AutoMapper;
using DotnetCoreApiDemo.Modules;
using FluentAssertions;
using NUnit.Framework;
using Serilog;

namespace DotnetCoreApiDemo.Tests
{
    [TestFixture]
    public class ApiModuleTests : TestBase
    {
        private IContainer _container;

        [SetUp]
        public void Setup()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<ApiModule>();

            _container = containerBuilder.Build(ContainerBuildOptions.IgnoreStartableComponents);
        }

        [Test]
        public void ServiceModuleShouldRegisterServices()
        {
            _container.IsRegistered<ILogger>().Should().BeTrue();
            _container.IsRegistered<IMapper>().Should().BeTrue();
        }
    }
}