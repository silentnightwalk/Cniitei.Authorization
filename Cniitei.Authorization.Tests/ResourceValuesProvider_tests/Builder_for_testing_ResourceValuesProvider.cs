using Cniitei.Authorization.v1.Core;
using Cniitei.Authorization.v1.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.Tests.ResourceValuesProvider_tests
{
    public class Builder_for_testing_ResourceValuesProvider : FluentElmBuilder<ResourceValuesProvider, Root>
    {
        public new TestElement<ActionValuesProvider> Result { get; set; }

        public Builder_for_testing_ResourceValuesProvider()
            : base("test_element", new Root())
        {
            Result = new TestElement<ActionValuesProvider>();
        }

        public ResourceValuesProviderBuilder<Builder_for_testing_ResourceValuesProvider> BeginResourceValuesProvider()
        {
            var builder = new ResourceValuesProviderBuilder<Builder_for_testing_ResourceValuesProvider>(parentBuilder: this);
            var earlyResult = builder.GetEarlyResult();

            Result.X.Add(earlyResult);

            return builder;
        }
    }
}
