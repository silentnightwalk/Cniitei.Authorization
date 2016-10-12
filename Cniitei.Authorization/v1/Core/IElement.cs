using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Core
{
    /// <summary>
    /// interface of a decision tree element
    /// </summary>
    public interface IElement:
        IValidatableElement
        //,ISerializableElement
        //,IBreedingElement
    {

    }

    public interface IValidatableElement
    {
        void Validate();  
    }

    public interface ISerializableElement
    {
        void FromDto(ElmDto dto);
        IEnumerable<ElmDto> ToDtoDeeply();
    }

    public interface IBreedingElement
    {
        void AddChild(IBreedingElement child);
    }
}
