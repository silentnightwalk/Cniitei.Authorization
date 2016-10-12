using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.Tests
{
    public class TestBuilder<TElement, TElementBuiler>
        where TElement : class, IElement, new()
        where TElementBuiler : FluentElmBuilder<TElement, Root>
    {
        public TElement Result;

        public TElementBuiler BeginTestElement()
        {
            var builder = Activator.CreateInstance(typeof(TElementBuiler), new Root()) as TElementBuiler;
            var earlyResult = builder.GetEarlyResult();

            Result = earlyResult;

            return builder;
        }
    }
}
