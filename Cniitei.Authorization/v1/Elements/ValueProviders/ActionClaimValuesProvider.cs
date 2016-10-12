using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    public class ActionClaimValuesProvider : IClaimValuesProvider
    {
        public string ClaimType { get; internal set; } = ElmPropKeys.Name;

        public IEnumerable<CniiteiClaimValue> GetClaimValues(CniiteiAuthorizationRequest request)
        {
            return request
                .ActionClaims
                .Where(x => x.ClaimType == ClaimType)
                .Select(x => x.GetValue())
                .ToArray();
        }

        public void Validate()
        {
            if (ClaimType == null)
            {
                throw new Exception($"{nameof(ActionClaimValuesProvider)} has NULL claim type");
            }
        }
    }


    public class ActionClaimValuesProviderBuilder<TParentBuilder> : FluentElmBuilder<ActionClaimValuesProvider, TParentBuilder>
         where TParentBuilder : ElmBuilderBase
    {
        public ActionClaimValuesProviderBuilder(TParentBuilder parentBuilder) 
            : base(ElmTypes.ActionClaimValuesProvider, parentBuilder)
        {

        }

        public ActionClaimValuesProviderBuilder<TParentBuilder> SetClaimType(string claimType = ElmPropKeys.Name)
        {
            Result.ClaimType = claimType;

            return this;
        }
    }
}
