using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1
{
    [Serializable]
    public class CniiteiClaimPropertyDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class CniiteiClaimProperty
    {
        public string Key { get; }
        public string Value { get; }

        public CniiteiClaimProperty(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
