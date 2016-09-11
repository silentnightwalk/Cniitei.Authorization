using Cniitei.Authorization.v1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1
{
    /// <summary>
    /// Authorization request contains claims describing request.
    /// All context claims are copied 
    /// </summary>

    [Serializable]
    public class AuthorizationRequestDto
    {
        public List<CniiteiClaimDto> ActionClaims { get; set; }
        public List<CniiteiClaimDto> ResourceClaims { get; set; }
        public List<CniiteiClaimDto> SubjectClaims { get; set; }
        public List<CniiteiClaimDto> EnvironmentClaims { get; set; }
        public CniiteiAuthorizationContextDto ContextDto { get; set; }
    }

    public class CniiteiAuthorizationRequest
    {
        public IEnumerable<CniiteiClaim> ActionClaims { get; }
        public IEnumerable<CniiteiClaim> ResourceClaims { get; }
        public IEnumerable<CniiteiClaim> SubjectClaims { get; }
        public IEnumerable<CniiteiClaim> EnvironmentClaims { get; }
        public CniiteiAuthorizationContext Context { get; }

        public CniiteiAuthorizationRequest(
            IEnumerable<CniiteiClaim> actionClaims,
            IEnumerable<CniiteiClaim> resourceClaims,
            IEnumerable<CniiteiClaim> subjectClaims,
            IEnumerable<CniiteiClaim> environmentClaims,
            CniiteiAuthorizationContext context
            )
        {
            ActionClaims = actionClaims;
            ResourceClaims = resourceClaims;
            SubjectClaims = subjectClaims;
            EnvironmentClaims = environmentClaims;
            Context = context;
        }


        public CniiteiAuthorizationRequest(AuthorizationRequestDto requestDto)
            : this(
                requestDto.ActionClaims.Select(x => new CniiteiClaim(x)),
                requestDto.ResourceClaims.Select(x => new CniiteiClaim(x)),
                requestDto.SubjectClaims.Select(x => new CniiteiClaim(x)),
                requestDto.EnvironmentClaims.Select(x => new CniiteiClaim(x)),
                new CniiteiAuthorizationContext(requestDto.ContextDto)
                )
        {

        }
    }

}
