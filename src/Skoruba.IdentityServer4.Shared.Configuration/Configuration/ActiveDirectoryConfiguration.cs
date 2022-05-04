using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.Shared.Configuration.Configuration
{
    public class ActiveDirectoryConfiguration
    {
        public bool Enabled { get; set; }
        public string Server { get; set; }
        public string SearchBaseDN { get; set; }
        public bool WindowsAutentication { get; set; }
        public bool UseSecureSocketLayer { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int Port { get; set; }
        public string IdentityServerAdminRole { get; set; }
        public bool LoadAttributes { get; set; }

        public List<string> UserAttributes { get; set; }
        public List<string> GroupAttributes { get; set; }
        public bool UseSimpleBind { get; set; }
        public bool UseNegotiate { get; set; }
        public bool UseSigning { get; set; }
        public bool UseSealing { get; set; }
        public bool UseServerBind { get; set; }
        public bool UseSecure { get; set; }
        public bool UseReadonlyServer { get; set; }
        public bool UseAnonymous { get; set; }
        public bool UseDelegation { get; set; }
    }
}
