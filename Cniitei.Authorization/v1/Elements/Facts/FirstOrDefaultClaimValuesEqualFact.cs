using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    public class FirstOrDefaultClaimValuesEqualFact : TwoProvidersFact
    {
        public override bool CanSay(CniiteiAuthorizationRequest request)
        {
            //compare two claim values
 
            var left = TwoClaimValuesProviders[0].GetClaimValues(request)?.FirstOrDefault();
            var right = TwoClaimValuesProviders[1].GetClaimValues(request)?.FirstOrDefault();

            if (left == null & right == null)
            {
                return true;
            }

            if (left != null & right != null)
            {
                return left == right;
            }

            return false;
        }
    }
}
