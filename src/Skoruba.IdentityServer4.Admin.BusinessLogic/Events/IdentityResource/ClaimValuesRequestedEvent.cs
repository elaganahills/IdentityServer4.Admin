using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Events.IdentityResource
{
    public class ClaimValuesRequestedEvent : AuditEvent
    {
        public ClaimValuesDto ClaimValues { get; }

        public ClaimValuesRequestedEvent(ClaimValuesDto claimValues)
        {
            ClaimValues = claimValues;
        }
    }
}