using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Core
{
    [Serializable]
    public class CniiteiAuthorizationContextDto
    {
        public List<CniiteiClaimDto> SubjectClaims { get; set; } = new List<CniiteiClaimDto>();
        public List<CniiteiClaimDto> EnvironmentClaims { get; set; } = new List<CniiteiClaimDto>();
    }

    public class CniiteiAuthorizationContext
    {
        public List<CniiteiClaim> SubjectClaims { get; } = new List<CniiteiClaim>();
        public List<CniiteiClaim> EnvironmentClaims { get; } = new List<CniiteiClaim>();

        public CniiteiAuthorizationContext(CniiteiAuthorizationContextDto contextDto)
        {
            SubjectClaims = contextDto.SubjectClaims.Select(x => new CniiteiClaim(x)).ToList();
            EnvironmentClaims = contextDto.EnvironmentClaims.Select(x => new CniiteiClaim(x)).ToList();
        }
    }   
}
