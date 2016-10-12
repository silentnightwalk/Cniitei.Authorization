using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Cniitei.Authorization.v1.Elements;

namespace Cniitei.Authorization.Tests.ResourceValuesProvider_tests
{
    [TestClass]
    public class ResourceClaimValuesProvider_tests
    {
        [TestMethod]
        public void ActionValuesProviderBuilder_should_build()
        {
            var testBuilder = new TestBuilder<ResourceClaimValuesProvider, ResourceClaimValuesProviderBuilder<Root>>();

            testBuilder
                .BeginTestElement()
                    .SetClaimType("MyName")
                .End();

            testBuilder.Result.ClaimType.Should().Be("MyName");
        }
    }
}
