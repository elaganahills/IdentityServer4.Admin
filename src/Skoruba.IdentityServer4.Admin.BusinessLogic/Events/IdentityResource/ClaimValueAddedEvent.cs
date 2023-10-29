using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Events.IdentityResource
{
    public class ClaimValueAddedEvent : AuditEvent
    {
        public ClaimValueDto ClaimValue { get; set; }

        public ClaimValueAddedEvent(ClaimValueDto claimValue)
        {
            ClaimValue = claimValue;
        }
    }
}