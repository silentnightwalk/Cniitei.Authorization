using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    internal interface ITargetCriterion: IFact, IElement
    {
        IFact Fact { get; }
    }

    internal interface IConditionCriterion : IFact, IElement
    {
        IFact Fact { get; }
    }
}
