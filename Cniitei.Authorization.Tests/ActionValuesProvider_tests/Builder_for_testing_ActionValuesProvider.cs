using Cniitei.Authorization.v1.Core;
using Cniitei.Authorization.v1.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.Tests.ActionValuesProvider_tests
{
    public class Builder_for_testing_ActionValuesProvider : FluentElmBuilder<ActionValuesProvider, Root>
    {
        public new TestElement<ActionValuesProvider> Result { get; set; }

        public Builder_for_testing_ActionValuesProvider()
            : base("test_element", new Root())
        {
            Result = new TestElement<ActionValuesProvider>();
        }

        public ActionValuesProviderBuilder<Builder_for_testing_ActionValuesProvider> BeginActionValuesProvider()
        {
            var builder = new ActionValuesProviderBuilder<Builder_for_testing_ActionValuesProvider>(parentBuilder: this);
            var earlyResult = builder.GetEarlyResult();

            Result.X.Add(earlyResult);

            return builder;
        }
    }
}
