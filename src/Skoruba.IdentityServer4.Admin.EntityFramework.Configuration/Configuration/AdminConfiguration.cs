using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration
{
    public class AdminConfigurationDeploy
    {
        public string IdentityAdminRedirectUri { get; set; }

        public string IdentityServerBaseUrl { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string AdministrationRole { get; set; }

    }
}
