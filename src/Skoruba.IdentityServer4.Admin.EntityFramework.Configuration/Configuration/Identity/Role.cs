using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;
using System.Collections.Generic;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.Identity
{
    public class Role : UserIdentityRoleConfiguration
    {
        //public string Name { get; set; }
        public List<Claim> Claims { get; set; } = new List<Claim>();
    }
}
