using Hills.Extensions.Models;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.Shared.Configuration.Deploy
{
    public class DeployAppSettings
    {
        public ConnectionStringsConfiguration ConnectionStrings { get; set; }
        public AdminConfiguration AdminConfiguration { get; set; }
        public List<EndPointConfiguration> EndPoints { get; set; }

        public ActiveDirectoryConfiguration ActiveDirectoryConfiguration { get; set; }
    }
}
