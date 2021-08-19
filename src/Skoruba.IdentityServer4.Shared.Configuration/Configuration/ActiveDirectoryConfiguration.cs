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
        public bool WindowsAutentiction { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string HHSOID { get; set; }
        public bool LoadAtributes { get; set; }
        public string AtributesStartFilter { get; set; }
        public int Port { get; set; }
        public string IdentityServerAdminRole { get; set; }
    }
}
