using Cniitei.Authorization.v1.Elements;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.Tests.ValueProviders_tests
{
    [TestClass]
    public class ClaimValueCollectionProvider_tests
    {
        [TestMethod]
        public void ClaimValueProviderBuilder_should_build_when_no_claimValues_set()
        {
            var testBuilder = new TestBuilder<ClaimValueCollectionProvider, ClaimValueCollectionProviderBuilder<Root>>();

            testBuilder
                .BeginTestElement()
                    .SetClaimValueCollection()
                .End();

            testBuilder.Result
                .GetClaimValues(TestData.Create_EmptyAuthorizationRequest()).Count()
                .Should().Be(0);

        }

        [TestMethod]
        public void ClaimValueProviderBuilder_should_build_when_set_method_is_not_called()
        {
            var testBuilder = new TestBuilder<ClaimValueCollectionProvider, ClaimValueCollectionProviderBuilder<Root>>();

            testBuilder
                .BeginTestElement()
                .End();

            testBuilder.Result
                .GetClaimValues(TestData.Create_EmptyAuthorizationRequest()).Count()
                .Should().Be(0);

        }

        [TestMethod]
        public void ClaimValueProviderBuilder_should_build_when_collection_set()
        {
            var testBuilder = new TestBuilder<ClaimValueCollectionProvider, ClaimValueCollectionProviderBuilder<Root>>();

            var claimValues = TestData.CreateSomeClaimValueCollection().ToArray();

            testBuilder
                .BeginTestElement()
                    .SetClaimValueCollection(claimValues)
                .End();

            testBuilder.Result
                .GetClaimValues(TestData.Create_EmptyAuthorizationRequest()).Count()
                .Should().Be(claimValues.Count());

        }
    }
}
