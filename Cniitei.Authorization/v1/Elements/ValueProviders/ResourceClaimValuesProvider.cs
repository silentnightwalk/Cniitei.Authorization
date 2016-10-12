using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cniitei.Authorization.v1.Core;

namespace Cniitei.Authorization.v1.Elements
{
    public class ResourceClaimValuesProvider : IClaimValuesProvider
    {
        public string ClaimType { get; internal set; }

        public IEnumerable<CniiteiClaimValue> GetClaimValues(CniiteiAuthorizationRequest request)
        {
            return request
                .ResourceClaims
                .Where(x => x.ClaimType == ClaimType)
                .Select(x => x.GetValue())
                .ToArray();
        }

        public void Validate()
        {
            if (ClaimType == null)
            {
                throw new Exception($"{nameof(ResourceClaimValuesProvider)} has NULL claim type");
            }
        }
    }

    public class ResourceClaimValuesProviderBuilder<TParentBuilder> : FluentElmBuilder<ResourceClaimValuesProvider, TParentBuilder>
     where TParentBuilder : ElmBuilderBase
    {
        public ResourceClaimValuesProviderBuilder(TParentBuilder parentBuilder)
            : base(ElmTypes.ResourceClaimValuesProvider, parentBuilder)
        {

        }

        public ResourceClaimValuesProviderBuilder<TParentBuilder> SetClaimType(string claimType = ElmPropKeys.Name)
        {
            Result.ClaimType = claimType;

            return this;
        }
    }
}
