using System;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DotnetCoreApiDemo.Tests
{
    public class TestBase
    {
        protected IFixture Fixture { get; private set; }

        [SetUp]
        public void SetupBase()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            Fixture.Customize<BindingInfo>(c => c.OmitAutoProperties());
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}
