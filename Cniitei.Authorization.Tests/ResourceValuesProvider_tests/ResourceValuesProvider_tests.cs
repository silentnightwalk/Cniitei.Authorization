using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace Cniitei.Authorization.Tests.ResourceValuesProvider_tests
{
    [TestClass]
    public class ResourceValuesProvider_tests
    {
        [TestMethod]
        public void ActionValuesProviderBuilder_should_build()
        {
            var testBuilder = new Builder_for_testing_ResourceValuesProvider();

            var testElement = testBuilder
                .BeginResourceValuesProvider()
                    .SetClaimType("MyName")
                .End()
                .Result;

            testElement.X[0].ClaimType.Should().Be("MyName");
        }
    }
}
