using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Core
{
    /// <summary>
    /// Value of a CniiteiClaim
    /// </summary>
    public class CniiteiClaimValue
    {
        public string Value { get; }
        public string ValueType { get; }
        //TODO: add another property to be more specific?

        public CniiteiClaimValue(string value, string valueType = CniiteiValueTypes.String)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            Value = value;
            ValueType = valueType;
        }

        public override bool Equals(object obj)
        {
            var target = obj as CniiteiClaimValue;
            if (target == null) return false;

            return this == target;
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 37 + Value.GetHashCode();
            hash = hash * 37 + ValueType.GetHashCode();

            return hash;
        }

        public static bool operator ==(CniiteiClaimValue left, CniiteiClaimValue right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return false;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return string.Equals(left.Value, right.Value, StringComparison.OrdinalIgnoreCase)
                && string.Equals(left.ValueType, right.ValueType, StringComparison.OrdinalIgnoreCase);
        }

        public static bool operator !=(CniiteiClaimValue left, CniiteiClaimValue right)
        {
            return !(left == right);
        }

    }

    public static class ClaimValueHelper
    {
        public static CniiteiClaimValue GetValue(this CniiteiClaim claim)
        {
            return new CniiteiClaimValue(claim.Value, claim.ValueType);
        }

    }
}
