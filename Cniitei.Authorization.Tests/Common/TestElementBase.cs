using Cniitei.Authorization.v1;
using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.Tests
{
    public class TestElementBase 
    {

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void FromDto(ElmDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ElmDto> ToDtoDeeply()
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            //all is ok
        }

        public void AddChild(IElement child)
        {
            throw new NotImplementedException();
        }
    }
}
