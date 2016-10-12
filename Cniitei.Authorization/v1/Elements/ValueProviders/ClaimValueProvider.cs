using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    /// <summary>
    /// Most commonly, values will be taken from request by providers
    /// But here provider gives its defined value.
    /// Value is not taken from request in this provider.
    /// </summary>
    public class ClaimValueProvider : IClaimValuesProvider
    {
        public string Value { get; internal  set; }
        public string ValueType { get; internal set; }

        private CniiteiClaimValue _ClaimValue;
        private CniiteiClaimValue ClaimValue
        {
            get
            {
                return _ClaimValue ?? (_ClaimValue = new CniiteiClaimValue(Value, ValueType));
            }
        }

        public IEnumerable<CniiteiClaimValue> GetClaimValues(CniiteiAuthorizationRequest request)
        {
            yield return ClaimValue;
        }

        public void Validate()
        {
            if (Value == null || ValueType == null)
            {
                throw new Exception($"{nameof(ClaimValueProvider)} has NULL value or value type");
            }
        }
    }

    /// <summary>
    /// Builder for ClaimValueProvider
    /// </summary>
    public class ClaimValueProviderBuilder<TParentBuilder> : FluentElmBuilder<ClaimValueProvider, TParentBuilder>
        where TParentBuilder : ElmBuilderBase
    {
        public ClaimValueProviderBuilder(TParentBuilder parentBuilder) 
            : base(ElmTypes.ClaimValuesProvider, parentBuilder)
        {

        }

        public ClaimValueProviderBuilder<TParentBuilder> SetValue(string value, string valueType = CniiteiValueTypes.String)
        {
            Result.Value = value;
            Result.ValueType = valueType;

            return this;
        }
    }
}
