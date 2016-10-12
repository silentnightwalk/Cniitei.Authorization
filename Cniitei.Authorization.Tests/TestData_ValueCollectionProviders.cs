using Cniitei.Authorization.v1;
using Cniitei.Authorization.v1.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.Tests
{
    public static partial class TestData
    {
        public static string type1 = "type1";
        public static string type2 = "type2";
        public static string type3 = "type3";

        public static string val1 = "val1";
        public static string val2 = "val2";
        public static string val3 = "val3";
        public static string val4 = "val4";
        public static string val5 = "val5";

        public static IEnumerable<CniiteiClaimValue> CreateSomeClaimValueCollection()
        {
            yield return new CniiteiClaimValue(val1, type1);
            yield return new CniiteiClaimValue(val3, type1);
            yield return new CniiteiClaimValue(val2, type2);
            yield return new CniiteiClaimValue(val4, type2);
        }

        public static IClaimValuesProvider CreateProviderOne()
        {
            var provider = new ClaimValueCollectionProvider();
            provider.SetClaimValues(
                new CniiteiClaimValue(val1, type1),
                new CniiteiClaimValue(val3, type1),
                new CniiteiClaimValue(val2, type2),
                new CniiteiClaimValue(val4, type2)
                );
            return provider;
        }

        public static IClaimValuesProvider CreateProviderOne_WithOtherValuesOrder()
        {
            var provider = new ClaimValueCollectionProvider();
            provider.SetClaimValues(
                new CniiteiClaimValue(val2, type2),
                new CniiteiClaimValue(val1, type1),
                new CniiteiClaimValue(val4, type2), 
                new CniiteiClaimValue(val3, type1)
                );
            return provider;
        }

        public static IClaimValuesProvider CreateProviderTwo()
        {
            var provider = new ClaimValueCollectionProvider();
            provider.SetClaimValues(
                new CniiteiClaimValue(val2, type1),
                new CniiteiClaimValue(val3, type1),
                new CniiteiClaimValue(val4, type2)
                );
            return provider;
        }

        public static IClaimValuesProvider CreateProviderThree()
        {
            var provider = new ClaimValueCollectionProvider();
            provider.SetClaimValues(
                new CniiteiClaimValue(val2, type1),
                new CniiteiClaimValue(val3, type1),
                new CniiteiClaimValue(val5, type2),
                new CniiteiClaimValue(val4, type2)
                );
            return provider;
        }

        public static IClaimValuesProvider CreateProviderFour()
        {
            var provider = new ClaimValueCollectionProvider();
            provider.SetClaimValues(
                new CniiteiClaimValue(val1, type1),
                new CniiteiClaimValue(val3, type1),
                new CniiteiClaimValue(val2, type3),
                new CniiteiClaimValue(val4, type2)
                );
            return provider;
        }

        public static IClaimValuesProvider CreateProviderFive()
        {
            var provider = new ClaimValueCollectionProvider();
            provider.SetClaimValues(
                new CniiteiClaimValue(val2, type1),
                new CniiteiClaimValue(val3, type1),
                new CniiteiClaimValue(val1, type2),
                new CniiteiClaimValue(val4, type2)
                );
            return provider;
        }

        public static IClaimValuesProvider CreateProviderWithNullCollection()
        {
            var provider = new ClaimValueCollectionProvider();
            provider.SetClaimValues(
                null
                );
            return provider;
        }

        public static IClaimValuesProvider CreateProviderWithEmptyCollection()
        {
            var provider = new ClaimValueCollectionProvider();
            provider.SetClaimValues(
                new CniiteiClaimValue[] { }
                );
            return provider;
        }
    }
}
