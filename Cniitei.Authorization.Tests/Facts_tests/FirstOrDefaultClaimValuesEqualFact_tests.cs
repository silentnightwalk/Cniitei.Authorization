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
    public class FirstOrDefaultClaimValuesEqualFact_tests
    {
        [TestMethod]
        public void FirstOrDefaultClaimValuesEqualFact_should_say_true_for_same_first_CVs()
        {
            var fact = new FirstOrDefaultClaimValuesEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderTwo());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderThree());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(true);

            fact = new FirstOrDefaultClaimValuesEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderThree());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderTwo());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(true);
        }

        [TestMethod]
        public void FirstOrDefaultClaimValuesEqualFact_should_say_false_for_different_first_CVs()
        {
            var fact = new FirstOrDefaultClaimValuesEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne_WithOtherValuesOrder());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(false);

            fact = new FirstOrDefaultClaimValuesEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne_WithOtherValuesOrder());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderOne());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(false);
        }

        [TestMethod]
        public void FirstOrDefaultClaimValuesEqualFact_should_say_true_comparing_empty_collections()
        {
            var fact = new FirstOrDefaultClaimValuesEqualFact();
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderWithEmptyCollection());
            fact.TwoClaimValuesProviders.Add(TestData.CreateProviderWithEmptyCollection());
            fact.CanSay(TestData.Create_EmptyAuthorizationRequest()).Should().Be(true);
        }
    }
}
