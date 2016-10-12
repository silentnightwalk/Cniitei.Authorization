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
    public class AllClaimValuesProvider_Tests
    {
        [TestMethod]
        public void AllClaimValuesProviderBuilder_should_build()
        {
            var testBuilder = new TestBuilder<AllClaimValuesProvider, AllClaimValuesProviderBuilder<Root>>();

            testBuilder
                .BeginTestElement()
                    .LeaveExistingFilter()
                .End();

            testBuilder.Result.Should().NotBeNull();
        }
    }
}
