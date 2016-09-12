﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace Cniitei.Authorization.Tests.ActionValuesProvider_tests
{
    [TestClass]
    public class ActionValuesProvider_Tests
    {
        [TestMethod]
        public void ActionValuesProviderBuilder_should_build()
        {
            var testBuilder = new Builder_for_testing_ActionValuesProvider();

            var testElement = testBuilder
                .BeginActionValuesProvider()
                    .SetClaimType("MyName")
                .End()
                .Result;

            testElement.X[0].ClaimType.Should().Be("MyName");
        }
    }
}
