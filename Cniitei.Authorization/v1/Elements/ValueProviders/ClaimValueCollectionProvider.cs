using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    /// <summary>
    /// Most commonly, values will be taken from request by providers
    /// But here provider gives its defined values.
    /// Values are not taken from request in this provider.
    /// </summary>
    public class ClaimValueCollectionProvider : IClaimValuesProvider
    {
        private CniiteiClaimValue[] m_ClaimValueCollection;

        public void SetClaimValues(params CniiteiClaimValue[] claimValues)
        {
            m_ClaimValueCollection = claimValues;
        }

        public IEnumerable<CniiteiClaimValue> GetClaimValues(CniiteiAuthorizationRequest request)
        {
            return m_ClaimValueCollection ?? Enumerable.Empty<CniiteiClaimValue>();
        }

        public void Validate()
        {
            //should be fine always
        }
    }

    /// <summary>
    /// Builder for ClaimValueProvider
    /// </summary>
    public class ClaimValueCollectionProviderBuilder<TParentBuilder> : FluentElmBuilder<ClaimValueCollectionProvider, TParentBuilder>
        where TParentBuilder : ElmBuilderBase
    {
        public ClaimValueCollectionProviderBuilder(TParentBuilder parentBuilder)
            : base(ElmTypes.ClaimValuesProvider, parentBuilder)
        {

        }

        public ClaimValueCollectionProviderBuilder<TParentBuilder> SetClaimValueCollection(params CniiteiClaimValue[] claimValues)
        {
            Result.SetClaimValues(claimValues);

            return this;
        }
    }
}
