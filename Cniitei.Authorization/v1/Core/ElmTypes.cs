using Cniitei.Authorization.v1.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1
{
    public static class ElmTypes
    {
        public const string Undefined = "Undefined";

        public const string ClaimValuesProvider = nameof(Elements.ClaimValueProvider);
        public const string ActionClaimValuesProvider = nameof(Elements.ActionClaimValuesProvider);
        public const string ResourceClaimValuesProvider = nameof(Elements.ResourceClaimValuesProvider);
        public const string AllClaimValuesProvider = nameof(Elements.AllClaimValuesProvider);

        public const string ClaimsEqualFact = nameof(Elements.ClaimValueCollectionsEqualFact);
    }
}
