using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    internal interface IPermissionDecider: IElement
    {
        string UniqueName { get; }
        Decision MakeDecision(CniiteiAuthorizationRequest request);
    }
}
