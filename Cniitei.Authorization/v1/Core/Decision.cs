using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Core
{
    public class Decision
    {
        internal DecisionValue Value { get; }
        internal string DeciderName { get; }
        internal string RequirementDescription { get; }
        internal Decision InnerDecision { get; }

        internal Decision(
            DecisionValue decisionValue, 
            string deciderName,
            string requirementDescriptionIfNonPermit = "", 
            Decision innerNonPermitDecision = null
            )
        {
            Value = decisionValue;
            RequirementDescription = requirementDescriptionIfNonPermit;
            InnerDecision = innerNonPermitDecision;
        }
    }
}
