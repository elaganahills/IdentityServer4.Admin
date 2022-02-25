using Skoruba.IdentityServer4.Shared.Configuration.Configuration;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;
using Skoruba.IdentityServer4.STS.Identity.Configuration.Interfaces;

namespace Skoruba.IdentityServer4.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();

        public ActiveDirectoryConfiguration ActiveDirectoryConfiguration { get; } = new ActiveDirectoryConfiguration();

        public OtherConfiguration OtherConfiguration { get; set; } = new OtherConfiguration();

    }

    public class RootConfigurationTest : IRootConfiguration
    {
        public AdminConfiguration AdminConfiguration { get; set;  } 
        public RegisterConfiguration RegisterConfiguration { get; set; }

        public ActiveDirectoryConfiguration ActiveDirectoryConfiguration { get; set; }

        public OtherConfiguration OtherConfiguration { get; set; }

    }
}