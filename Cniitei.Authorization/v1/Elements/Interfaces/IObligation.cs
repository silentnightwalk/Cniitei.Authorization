using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    public interface IObligation: IElement
    {
        void Fulfill(CniiteiAuthorizationRequest request, string policyId, DecisionValue policyDecision);
    }
}
