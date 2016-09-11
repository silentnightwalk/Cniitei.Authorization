using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    internal interface IPolicySet: IElement
    {
        IEnumerable<IPolicy> Policies { get; }
        ICombiningAlgorithm PolicyCombiningAlgorithm { get; }
        Decision MakeDecision(CniiteiAuthorizationRequest request);
    }
}
