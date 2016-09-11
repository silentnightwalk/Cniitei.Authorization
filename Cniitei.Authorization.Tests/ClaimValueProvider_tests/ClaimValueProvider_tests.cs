using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Cniitei.Authorization.v1.Core;

namespace Cniitei.Authorization.Tests.ClaimValueProvider_tests
{
    [TestClass]
    public class ClaimValueProvider_tests
    {
        [TestMethod]
        public void ClaimValueProviderBuilder_should_build()
        {
            var testBuilder = new TestBuilder();

            var testElement = testBuilder
                .BeginClaimValueProvider()
                    .SetValue("0")
                .End()
                .BeginClaimValueProvider()
                    .SetValue("1")
                .End()
                .Result;

            testElement.X[0].Value.Should().Be("0");
            testElement.X[1].Value.Should().Be("1");
        }

        [TestMethod]
        [ExpectedException(typeof(CniiteiAuthorizationModelBuildingException))]
        public void ClaimValueProviderBuilder_should_validate()
        {
            var testBuilder = new TestBuilder();

            var testElement = testBuilder
                .BeginClaimValueProvider()
                    .SetValue("0")
                .End()
                .BeginClaimValueProvider()
                    .SetValue(null)
                .End()
                .Result;
        }

        [TestMethod]
        [ExpectedException(typeof(CniiteiAuthorizationModelBuildingException))]
        public void ClaimValueProviderBuilder_should_validate_2()
        {
            var testBuilder = new TestBuilder();

            var testElement = testBuilder
                .BeginClaimValueProvider()
                .End()
                .Result;
        }
    }
}
