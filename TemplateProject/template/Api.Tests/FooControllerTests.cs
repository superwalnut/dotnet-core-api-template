using System;
using System.Collections.Generic;
using AutoFixture;
using AutoMapper;
using DotnetCoreApiDemo.Controllers;
using DotnetCoreApiDemo.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Serilog;

namespace DotnetCoreApiDemo.Tests
{
    [TestFixture]
    public class FooControllerTests : TestBase
    {
        private Mock<ILogger> _loggerMock;
        private Mock<IMapper> _mapperMock;

        private List<FooDto> _dtos;

        [SetUp]
        public void Setup()
        {
            _loggerMock = Fixture.Freeze<Mock<ILogger>>();
            _mapperMock = Fixture.Freeze<Mock<IMapper>>();

            _dtos = new List<FooDto> { new FooDto { Id = new Guid("59a54f7c-f7ea-41dc-89a8-d34aef7c8932"), Name = "test1" } };
            _mapperMock.Setup(x => x.Map<List<Foo>, List<FooDto>>(It.IsAny<List<Foo>>())).Returns(_dtos);
        }

        [Test]
        public void ServiceModuleShouldRegisterServices()
        {
            var target = Fixture.Create<FooController>();

            IActionResult result = target.Get();

            var okObjectResult = result as OkObjectResult;
            okObjectResult.Should().NotBeNull();

            okObjectResult.Value.Should().BeOfType<List<FooDto>>();

            okObjectResult.Value.As<List<FooDto>>().Should().BeSameAs(_dtos);
        }
    }
}
