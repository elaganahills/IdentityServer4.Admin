﻿using Microsoft.AspNetCore.Identity;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity
{
    public class UserIdentityRole : IdentityRole
    {
        public string ActiveDirectoryRole { get; set; }
    }
}