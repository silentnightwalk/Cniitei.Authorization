using Cniitei.Authorization.v1.Core;
using Cniitei.Authorization.v1.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.Tests.ClaimValueProvider_tests
{
    public class TestElement: TestElementBase, IElement
    {
        internal List<ClaimValueProvider> X { get; set; } = new List<ClaimValueProvider>();
    }

    public class TestBuilder : FluentElmBuilder<TestElement, Root>
    {
        public new TestElement Result { get; set; }

        public TestBuilder()
            : base("test_element", new Root())
        {
            Result = new TestElement();
        }

        public ClaimValueProviderBuilder<TestBuilder> BeginClaimValueProvider()
        {
            var builder = new ClaimValueProviderBuilder<TestBuilder>(parentBuilder: this);
            var earlyResult = builder.GetEarlyResult();

            Result.X.Add(earlyResult);

            return builder;
        }
    }
}
