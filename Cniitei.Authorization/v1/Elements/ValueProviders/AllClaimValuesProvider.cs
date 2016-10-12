using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    public class AllClaimValuesProvider : IClaimValuesProvider
    {
        public Func<CniiteiClaimValue, bool> Filter { get; internal set; } = (cv) => true;

        public IEnumerable<CniiteiClaimValue> GetClaimValues(CniiteiAuthorizationRequest request)
        {
            foreach (var actionClaimValue in request.ActionClaims.Select(x => x.GetValue()))
            {
                yield return actionClaimValue;
            }
            foreach (var resourceClaimValue in request.ResourceClaims.Select(x => x.GetValue()))
            {
                yield return resourceClaimValue;
            }
            foreach (var subjectClaimValue in request.SubjectClaims.Select(x => x.GetValue()))
            {
                yield return subjectClaimValue;
            }
            foreach (var environmentClaimValue in request.EnvironmentClaims.Select(x => x.GetValue()))
            {
                yield return environmentClaimValue;
            }
        }

        public void Validate()
        {
            if (Filter == null)
            {
                throw new Exception($"{nameof(Filter)} Func is null");
            }
        }
    }


    public class AllClaimValuesProviderBuilder<TParentBuilder> : FluentElmBuilder<AllClaimValuesProvider, TParentBuilder>
         where TParentBuilder : ElmBuilderBase
    {
        public AllClaimValuesProviderBuilder(TParentBuilder parentBuilder)
            : base(ElmTypes.AllClaimValuesProvider, parentBuilder)
        {

        }

        public AllClaimValuesProviderBuilder<TParentBuilder> SetFilter(Func<CniiteiClaimValue, bool> filter)
        {
            Result.Filter = filter;

            return this;
        }

        public AllClaimValuesProviderBuilder<TParentBuilder> LeaveExistingFilter()
        {
            return this;
        }
    }
}
