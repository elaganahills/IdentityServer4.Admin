using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity
{
    public class UserIdentityRoleConfiguration
    {
        public string Name { get; set; }
        public string ActiveDirectoryRole { get; set; }
    }
    public class IdentityDataConfiguration
    {
        public List<UserIdentityRoleConfiguration> Roles;
    }


}
