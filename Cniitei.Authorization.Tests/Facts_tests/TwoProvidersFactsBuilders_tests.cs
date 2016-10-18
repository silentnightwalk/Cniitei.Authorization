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
    public class TwoProvidersFactsBuilders_tests
    {
        [TestMethod]
        public void Test_All_Fact_Builders_Of_Facts_With_Two_Providers()
        {
            TestBuilder<ClaimValueCollectionsEqualFact>();
            TestBuilder<FirstOrDefaultClaimValuesEqualFact>();
        }

        private void TestBuilder<TTwoProvidersFact>()
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
            var builder = new TestBuilder<TTwoProvidersFact, TwoProvidersFactBuilder<TTwoProvidersFact, Root>>();

            MyAssert.Throws<CniiteiAuthorizationModelBuildingException>(
                () => builder
                    .BeginTestElement()
                    .End()
                );
        }


        private void TwoProvidersFactBuilder_should_throw_when_one_provider<TTwoProvidersFact>()
            where TTwoProvidersFact : TwoProvidersFact, new()
        {
            var builder = new TestBuilder<TTwoProvidersFact, TwoProvidersFactBuilder<TTwoProvidersFact, Root>>();

            MyAssert.Throws<CniiteiAuthorizationModelBuildingException>(
                () => builder
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
            var builder = new TestBuilder<TTwoProvidersFact, TwoProvidersFactBuilder<TTwoProvidersFact, Root>>();

            MyAssert.Throws<CniiteiAuthorizationModelBuildingException>(
                () => builder
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
            var builder = new TestBuilder<TTwoProvidersFact, TwoProvidersFactBuilder<TTwoProvidersFact, Root>>();

            builder
                .BeginTestElement()
                    .BeginActionClaimValuesProvider()
                        .SetClaimType("Org")
                    .End()
                    .BeginResourceClaimValuesProvider()
                        .SetClaimType("Org")
                    .End()
                .End();

            builder.Result.TwoClaimValuesProviders.Count.Should().Be(2);
        }
        
    }
}
