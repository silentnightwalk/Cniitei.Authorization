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

        public void AddChild(IElement child)
        {
            X.Add(child as ClaimValueProvider);
        }
    }

    public class TestBuilder : FluentElmBuilder<TestElement, Root>
    {
        public new TestElement Result { get { return base.Result; } }

        public TestBuilder()
            : base("test_element", new Root())
        {

        }

        public ClaimValueProviderBuilder<TestBuilder> BeginClaimValueProvider()
        {
            return new ClaimValueProviderBuilder<TestBuilder>(parentBuilder: this);
        }
    }
}
