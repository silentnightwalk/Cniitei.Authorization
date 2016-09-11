using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    internal interface ICombiningAlgorithm: IElement
    {
        Decision MakeDecision(CniiteiAuthorizationRequest request, IEnumerable<IPermissionDecider> permissionDeciders);
    }
}
