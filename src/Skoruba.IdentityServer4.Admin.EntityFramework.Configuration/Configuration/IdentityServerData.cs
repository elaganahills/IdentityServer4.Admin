﻿using System.Collections.Generic;
using IdentityServer4.Models;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;
using Client = Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.IdentityServer.Client;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration
{

    public class IdentityServerDataContainer
    {
        public IdentityServerData IdentityServerData { get; set; }
        public IdentityDataConfiguration IdentityData { get; set; }
    }

    public class IdentityServerData
    {
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<IdentityResource> IdentityResources { get; set; } = new List<IdentityResource>();
        public List<ApiResource> ApiResources { get; set; } = new List<ApiResource>();
        public List<ApiScope> ApiScopes { get; set; } = new List<ApiScope>();
        
    }
}
