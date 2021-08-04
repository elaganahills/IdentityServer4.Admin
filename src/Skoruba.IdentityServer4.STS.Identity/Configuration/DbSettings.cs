using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.STS.Identity.Configuration
{
    public class DbSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string ConfigurationDbConnection { get; set; }
        public string PersistedGrantDbConnection { get; set; }
        public string IdentityDbConnection { get; set; }
        public string DataProtectionDbConnection { get; set; }

    }
}
