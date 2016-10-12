﻿using Cniitei.Authorization.v1;
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
    public class ClaimValueCollectionsEqualFact_tests
    {
        [TestMethod]
        [ExpectedException(typeof(CniiteiAuthorizationModelBuildingException))]
        public void ClaimValueCollectionsEqualFactBuilder_should_trow_when_no_providers()
        {
            var testBuilder = new TestBuilder<ClaimValueCollectionsEqualFact, ClaimValueCollectionsEqualFactBuilder<Root>>();

            testBuilder
                .BeginTestElement()
                .End();
        }

        [TestMethod]
        [ExpectedException(typeof(CniiteiAuthorizationModelBuildingException))]
        public void ClaimValueCollectionsEqualFactBuilder_should_throw_when_one_provider()
        {
            var testBuilder = new TestBuilder<ClaimValueCollectionsEqualFact, ClaimValueCollectionsEqualFactBuilder<Root>>();

            testBuilder
                .BeginTestElement()
                    .BeginActionClaimValuesProvider()
                        .SetClaimType("MyClaimType")
                    .End()
                .End();
        }

        [TestMethod]
        [ExpectedException(typeof(CniiteiAuthorizationModelBuildingException))]
        public void ClaimValueCollectionsEqualFactBuilder_should_throw_when_three_providers()
        {
            var testBuilder = new TestBuilder<ClaimValueCollectionsEqualFact, ClaimValueCollectionsEqualFactBuilder<Root>>();

            testBuilder
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
                .End();
        }

        [TestMethod]
        public void ClaimValueCollectionsEqualFactBuilder_should_build_when_two_providers()
        {
            var testBuilder = new TestBuilder<ClaimValueCollectionsEqualFact, ClaimValueCollectionsEqualFactBuilder<Root>>();

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

        [TestMethod]
        public void ClaimValueCollectionsEqualFact_should_say_true_for_same_collections_in_different_order()
        {
            var fact = new ClaimValueCollectionsEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne_WithOtherValuesOrder());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(true);
        }

        [TestMethod]
        public void ClaimValueCollectionsEqualFact_should_say_true_for_same_collections()
        {
            var fact = new ClaimValueCollectionsEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(true);
        }

        [TestMethod]
        public void ClaimValueCollectionsEqualFact_should_say_false_for_different_collections_comparing_one_two()
        {
            var fact = new ClaimValueCollectionsEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderTwo());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(false);
        }

        [TestMethod]
        public void ClaimValueCollectionsEqualFact_should_say_false_for_different_collections_comparing_two_one()
        {
            var fact = new ClaimValueCollectionsEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderTwo());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(false);
        }

        [TestMethod]
        public void ClaimValueCollectionsEqualFact_should_say_false_for_different_collections_comparing_one_three()
        {
            var fact = new ClaimValueCollectionsEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderThree());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(false);
        }

        [TestMethod]
        public void ClaimValueCollectionsEqualFact_should_say_false_for_different_collections_comparing_three_one()
        {
            var fact = new ClaimValueCollectionsEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderThree());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(false);
        }

        [TestMethod]
        public void ClaimValueCollectionsEqualFact_should_say_false_for_different_collections_comparing_one_four()
        {
            var fact = new ClaimValueCollectionsEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderFour());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(false);
        }

        [TestMethod]
        public void ClaimValueCollectionsEqualFact_should_say_false_for_different_collections_comparing_four_one()
        {
            var fact = new ClaimValueCollectionsEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderFour());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(false);
        }

        [TestMethod]
        public void ClaimValueCollectionsEqualFact_should_say_false_for_different_collections_comparing_one_five()
        {
            var fact = new ClaimValueCollectionsEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderFive());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(false);
        }

        [TestMethod]
        public void ClaimValueCollectionsEqualFact_should_say_false_for_different_collections_comparing_five_one()
        {
            var fact = new ClaimValueCollectionsEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderFive());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(false);
        }
    }
}
