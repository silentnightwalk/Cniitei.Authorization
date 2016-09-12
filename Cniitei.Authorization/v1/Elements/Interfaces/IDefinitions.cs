using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    internal interface IDefinitions: IElement
    {
        IEnumerable<IFact> DefinedFacts { get; }
        IEnumerable<IRule> DefinedRules { get; }
        IEnumerable<IPolicy> DefinedPolicies { get; }
    }
}
