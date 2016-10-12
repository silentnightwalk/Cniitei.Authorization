using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Cniitei.Authorization.v1.Core;
using Cniitei.Authorization.v1.Elements;

namespace Cniitei.Authorization.Tests.ClaimValueProvider_tests
{
    [TestClass]
    public class ClaimValueProvider_tests
    {
        [TestMethod]
        public void ClaimValueProviderBuilder_should_build()
        {
            var testBuilder = new TestBuilder<ClaimValueProvider, ClaimValueProviderBuilder<Root>>();

            testBuilder
                .BeginTestElement()
                    .SetValue("0")
                .End();
            testBuilder.Result.Value.Should().Be("0");

            testBuilder
                .BeginTestElement()
                    .SetValue("1")
                .End();
            testBuilder.Result.Value.Should().Be("1");
        }

        [TestMethod]
        [ExpectedException(typeof(CniiteiAuthorizationModelBuildingException))]
        public void ClaimValueProviderBuilder_should_validate()
        {
            var testBuilder = new TestBuilder<ClaimValueProvider, ClaimValueProviderBuilder<Root>>();

            testBuilder
                .BeginTestElement()
                    .SetValue(null)
                .End();
        }

        [TestMethod]
        [ExpectedException(typeof(CniiteiAuthorizationModelBuildingException))]
        public void ClaimValueProviderBuilder_should_validate_2()
        {
            var testBuilder = new TestBuilder<ClaimValueProvider, ClaimValueProviderBuilder<Root>>();

            testBuilder
                .BeginTestElement()
                .End();
        }
    }
}
