using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1
{
    [Serializable]
    public class ElmPropertyDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }

        public ElmPropertyDto Clone()
        {
            return new ElmPropertyDto()
            {
                Key = this.Key,
                Value = this.Value,
                ValueType = this.ValueType
            };
        }
    }
}
