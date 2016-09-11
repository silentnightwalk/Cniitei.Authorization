using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    public interface IAuthorizationModel: IElement
    {
        string ProjectName { get; }
        bool CheckAccess(CniiteiAuthorizationRequest request);
        void ThrowIfNoAccess(CniiteiAuthorizationRequest request);
        string GetReasonNoAccessOrNull(CniiteiAuthorizationRequest request);
    }
}
