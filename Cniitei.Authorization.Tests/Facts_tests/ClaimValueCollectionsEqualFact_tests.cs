using Cniitei.Authorization.v1;
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
    public class ClaimValueCollectionsEqualFact_tests
    {
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
