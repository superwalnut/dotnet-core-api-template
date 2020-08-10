using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
