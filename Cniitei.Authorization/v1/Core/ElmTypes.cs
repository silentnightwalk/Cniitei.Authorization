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

        public const string ClaimValuesProvider = nameof(Elements.ClaimValuesProvider);
        public const string ActionValuesProvider = nameof(Elements.ActionValuesProvider);
        public const string ResourceValuesProvider = nameof(Elements.ResourceValuesProvider);
    }
}
