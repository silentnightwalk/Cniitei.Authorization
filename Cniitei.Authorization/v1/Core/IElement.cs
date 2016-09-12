using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Core
{
    /// <summary>
    /// interface of a decision tree element
    /// </summary>
    public interface IElement
    {
        void Validate();

        /// <summary>
        /// AddChild, FromDto, ToDtoDeeply are for converting Model tree <- -> dto  
        /// </summary>

        //TODO: hide members
        void AddChild(IElement child);
        void FromDto(ElmDto dto);
        IEnumerable<ElmDto> ToDtoDeeply();
    }
}
