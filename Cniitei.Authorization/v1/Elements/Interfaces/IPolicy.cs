using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    internal interface IPolicy: IPermissionDecider, IElement
    {
        IEnumerable<IObligation> Obligations { get; }
        ITargetCriterion Target { get; }
        IEnumerable<IPermissionDecider> PermissionDeciders { get; }
        ICombiningAlgorithm CombiningAlgorithm { get; }
    }
}
