using Cniitei.Authorization.v1.Core;
using Cniitei.Authorization.v1.Elements;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.Tests.Facts_tests
{
    [TestClass]
    public class TwoProvidersFactBuilder_tests
    {
        [TestMethod]
        public void TestAllFactsWithTwoProviders()
        {
            Test<ClaimValueCollectionsEqualFact>();
        }

        private void Test<TTwoProvidersFact>()
            where TTwoProvidersFact : TwoProvidersFact, new()
        {
            TwoProvidersFactBuilder_should_throw_when_no_providers<TTwoProvidersFact>();
            TwoProvidersFactBuilder_should_throw_when_one_provider<TTwoProvidersFact>();
            TwoProvidersFactBuilder_should_throw_when_three_providers<TTwoProvidersFact>();
            TwoProvidersFactBuilder_should_build_when_two_providers<TTwoProvidersFact>();
        }


        private void TwoProvidersFactBuilder_should_throw_when_no_providers<TTwoProvidersFact>()
            where TTwoProvidersFact : TwoProvidersFact, new()
        {
            var testBuilder = new TestBuilder<TTwoProvidersFact, TwoProvidersFactBuilder<TTwoProvidersFact, Root>>();

            MyAssert.Throws<CniiteiAuthorizationModelBuildingException>(
                () => testBuilder
                    .BeginTestElement()
                    .End()
                );
        }


        private void TwoProvidersFactBuilder_should_throw_when_one_provider<TTwoProvidersFact>()
            where TTwoProvidersFact : TwoProvidersFact, new()
        {
            var testBuilder = new TestBuilder<TTwoProvidersFact, TwoProvidersFactBuilder<TTwoProvidersFact, Root>>();

            MyAssert.Throws<CniiteiAuthorizationModelBuildingException>(
                () => testBuilder
                    .BeginTestElement()
                        .BeginActionClaimValuesProvider()
                            .SetClaimType("MyClaimType")
                        .End()
                    .End()
                );
        }


        private void TwoProvidersFactBuilder_should_throw_when_three_providers<TTwoProvidersFact>()
            where TTwoProvidersFact : TwoProvidersFact, new()
        {
            var testBuilder = new TestBuilder<TTwoProvidersFact, TwoProvidersFactBuilder<TTwoProvidersFact, Root>>();

            MyAssert.Throws<CniiteiAuthorizationModelBuildingException>(
                () => testBuilder
                    .BeginTestElement()
                        .BeginActionClaimValuesProvider()
                            .SetClaimType("MyClaimType")
                        .End()
                        .BeginActionClaimValuesProvider()
                            .SetClaimType("MyClaimType_2")
                        .End()
                        .BeginActionClaimValuesProvider()
                            .SetClaimType("MyClaimType_3")
                        .End()
                    .End()
                );
        }


        private void TwoProvidersFactBuilder_should_build_when_two_providers<TTwoProvidersFact>()
            where TTwoProvidersFact : TwoProvidersFact, new()
        {
            var testBuilder = new TestBuilder<TTwoProvidersFact, TwoProvidersFactBuilder<TTwoProvidersFact, Root>>();

            testBuilder
                .BeginTestElement()
                    .BeginActionClaimValuesProvider()
                        .SetClaimType("Org")
                    .End()
                    .BeginResourceClaimValuesProvider()
                        .SetClaimType("Org")
                    .End()
                .End();

            testBuilder.Result.TwoClaimValuesProviders.Count.Should().Be(2);
        }
        
    }
}
