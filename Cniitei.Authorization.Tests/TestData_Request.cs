using Cniitei.Authorization.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.Tests
{
    public static partial class TestData
    {
        public static CniiteiAuthorizationContext Create_EmptyAuthorizationContext()
        {
            return new CniiteiAuthorizationContext();
        }

        public static CniiteiAuthorizationRequest Create_EmptyAuthorizationRequest()
        {
            return new CniiteiAuthorizationRequest(
                Enumerable.Empty<CniiteiClaim>(),
                Enumerable.Empty<CniiteiClaim>(),
                Enumerable.Empty<CniiteiClaim>(),
                Enumerable.Empty<CniiteiClaim>(),
                Create_EmptyAuthorizationContext()
                );
        }
    }

    
}
