using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Cniitei.Authorization.v1.Elements;

namespace Cniitei.Authorization.Tests.ActionValuesProvider_tests
{
    [TestClass]
    public class ActionClaimValuesProvider_Tests
    {
        

        [TestMethod]
        public void ActionClaimValuesProviderBuilder_should_build()
        {
            var testBuilder = new TestBuilder<ActionClaimValuesProvider, ActionClaimValuesProviderBuilder<Root>>();

            testBuilder
                .BeginTestElement()
                    .SetClaimType("MyName")
                .End();

            testBuilder.Result.ClaimType.Should().Be("MyName");
        }
    }
}
