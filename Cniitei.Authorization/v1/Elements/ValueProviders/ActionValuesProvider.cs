using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    public class ActionValuesProvider : IClaimsProvider
    {
        public string ClaimType { get; internal set; } = ElmPropKeys.Name;

        //public ActionValuesProvider(string claimType = ElmPropKeys.Name)
        //{
        //    ClaimType = claimType;
        //}

        public IEnumerable<CniiteiClaimValue> GetClaims(CniiteiAuthorizationRequest request)
        {
            return request
                .ActionClaims
                .Where(x => x.ClaimType == ClaimType)
                .Select(x => x.GetValue());
        }

        public void Validate()
        {
            if (ClaimType == null)
            {
                throw new Exception($"{nameof(ActionValuesProvider)} has NULL claim type");
            }
        }

        public void AddChild(IElement child)
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }


    public class ActionValuesProviderBuilder<TParentBuilder> : FluentElmBuilder<ActionValuesProvider, TParentBuilder>
         where TParentBuilder : ElmBuilderBase
    {
        public ActionValuesProviderBuilder(TParentBuilder parentBuilder) 
            : base(ElmTypes.ActionValuesProvider, parentBuilder)
        {

        }

        public ActionValuesProviderBuilder<TParentBuilder> SetClaimType(string claimType = ElmPropKeys.Name)
        {
            Result.ClaimType = claimType;

            return this;
        }
    }
}
