using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1
{
    [Serializable]
    public class ElmDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string ElmType { get; set; }
        public List<ElmPropertyDto> Properties { get; set; } = new List<ElmPropertyDto>();

        public ElmDto Clone()
        {
            var clone = new ElmDto
            {
                Id = this.Id,
                ParentId = this.ParentId,
                ElmType = this.ElmType
            };

            clone.Properties.AddRange(this.Properties.Select(x => x.Clone()));

            return clone;
        }

        public string GetPropertyValue(string propName)
        {
            return Properties?.FirstOrDefault(x => x.Key == propName)?.Value;
        }
    }
}
