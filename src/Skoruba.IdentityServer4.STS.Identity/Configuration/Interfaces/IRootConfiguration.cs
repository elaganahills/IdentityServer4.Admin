using Skoruba.IdentityServer4.Shared.Configuration.Configuration;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;

namespace Skoruba.IdentityServer4.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }

        ActiveDirectoryConfiguration ActiveDirectoryConfiguration { get; }

        OtherConfiguration OtherConfiguration { get; } 
    }
}