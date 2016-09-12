﻿using Cniitei.Authorization.v1.Core;
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
    public class ClaimValuesProvider : IClaimsProvider
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

        public IEnumerable<CniiteiClaimValue> GetClaims(CniiteiAuthorizationRequest request)
        {
            yield return ClaimValue;
        }

        public void Validate()
        {
            if (Value == null || ValueType == null)
            {
                throw new Exception($"{nameof(ClaimValuesProvider)} has NULL value or value type");
            }
        }

        public void AddChild(IElement child)
        {
            throw new NotSupportedException($"{nameof(ClaimValuesProvider)} has no children");
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

    /// <summary>
    /// Builder for ClaimValueProvider
    /// </summary>
    public class ClaimValuesProviderBuilder<TParentBuilder> : FluentElmBuilder<ClaimValuesProvider, TParentBuilder>
        where TParentBuilder : ElmBuilderBase
    {
        public ClaimValuesProviderBuilder(TParentBuilder parentBuilder) 
            : base(ElmTypes.ClaimValuesProvider, parentBuilder)
        {

        }

        public ClaimValuesProviderBuilder<TParentBuilder> SetValue(string value, string valueType = CniiteiValueTypes.String)
        {
            Result.Value = value;
            Result.ValueType = valueType;

            return this;
        }
    }
}
