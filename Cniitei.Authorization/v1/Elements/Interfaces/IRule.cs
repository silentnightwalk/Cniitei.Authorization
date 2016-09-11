using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    internal interface IRule: IPermissionDecider, IElement
    {
        bool Effect { get; }
        IConditionCriterion Condition { get; }
        ITargetCriterion Target { get; }
    }
}
