using Cniitei.Authorization.v1.Core;
using Cniitei.Authorization.v1.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.Tests.ClaimValueProvider_tests
{

    public class Builder_for_testing_ClaimValuesProvider : FluentElmBuilder<TestElement<ClaimValuesProvider>, Root>
    {
        public new TestElement<ClaimValuesProvider> Result { get; set; }

        public Builder_for_testing_ClaimValuesProvider()
            : base("test_element", new Root())
        {
            Result = new TestElement<ClaimValuesProvider>();
        }

        public ClaimValuesProviderBuilder<Builder_for_testing_ClaimValuesProvider> BeginClaimValueProvider()
        {
            var builder = new ClaimValuesProviderBuilder<Builder_for_testing_ClaimValuesProvider>(parentBuilder: this);
            var earlyResult = builder.GetEarlyResult();

            Result.X.Add(earlyResult);

            return builder;
        }
    }
}
