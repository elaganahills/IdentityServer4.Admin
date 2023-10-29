using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Events.IdentityResource
{
    public class ClaimValueRequestedEvent : AuditEvent
    {
        public ClaimValueDto ClaimValue { get; set; }

        public ClaimValueRequestedEvent(ClaimValueDto claimValue)
        {
            ClaimValue = claimValue;
        }
    }
}