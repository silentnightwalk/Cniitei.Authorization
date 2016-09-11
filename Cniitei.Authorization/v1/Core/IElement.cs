using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Core
{
    public interface IElement: IDisposable
    {
        void Validate();
        void AddChild(IElement child);
        void FromDto(ElmDto dto);
        IEnumerable<ElmDto> ToDtoDeeply();
    }
}
