using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Events.IdentityResource
{
    public class ClaimValueUpdatedEvent : AuditEvent
    {
        public ClaimValueDto OriginalClaimValue { get; set; }
        public ClaimValueDto ClaimValue { get; set; }

        public ClaimValueUpdatedEvent(ClaimValueDto originalClaimValue, ClaimValueDto claimValue)
        {
            OriginalClaimValue = originalClaimValue;
            ClaimValue = claimValue;
        }
    }
}