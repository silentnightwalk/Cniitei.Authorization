using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cniitei.Authorization.v1.Core;

namespace Cniitei.Authorization.v1.Elements
{
    public class ResourceValuesProvider : IClaimsProvider
    {
        public string ClaimType { get; internal set; }

        //public ResourceValuesProvider(string claimType = ClaimTypes.Name)
        //{
        //    ClaimType = claimType;
        //}

        public IEnumerable<CniiteiClaimValue> GetClaims(CniiteiAuthorizationRequest request)
        {
            return request
                .ResourceClaims
                .Where(x => x.ClaimType == ClaimType)
                .Select(x => x.GetValue());
        }

        public void Validate()
        {
            if (ClaimType == null)
            {
                throw new Exception($"{nameof(ResourceValuesProvider)} has NULL claim type");
            }
        }

        public void AddChild(IElement child)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void FromDto(ElmDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ElmDto> ToDtoDeeply()
        {
            throw new NotImplementedException();
        }
    }

    public class ResourceValuesProviderBuilder<TParentBuilder> : FluentElmBuilder<ActionValuesProvider, TParentBuilder>
     where TParentBuilder : ElmBuilderBase
    {
        public ResourceValuesProviderBuilder(TParentBuilder parentBuilder)
            : base(ElmTypes.ResourceValuesProvider, parentBuilder)
        {

        }

        public ResourceValuesProviderBuilder<TParentBuilder> SetClaimType(string claimType = ElmPropKeys.Name)
        {
            Result.ClaimType = claimType;

            return this;
        }
    }
}
