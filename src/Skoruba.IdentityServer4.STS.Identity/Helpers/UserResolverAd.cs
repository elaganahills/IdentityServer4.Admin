using Microsoft.AspNetCore.Identity;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.DbContexts;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;
using Skoruba.IdentityServer4.STS.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.STS.Identity.Helpers
{
    public class UserResolverAd<TUser> : IUserResolver<TUser> where TUser : class
    {
        private readonly UserManager<TUser> _userManager;
        private readonly IActiveDirectoryService _adService;
        private readonly LoginResolutionPolicy _policy;
        private readonly AdminIdentityDbContext _adminDbContext;

        public UserResolverAd(UserManager<TUser> userManager, IActiveDirectoryService adService, LoginConfiguration configuration, AdminIdentityDbContext adminDbContext)
        {
            _userManager = userManager;
            _adService = adService;
            _policy = configuration.ResolutionPolicy;
            _adminDbContext = adminDbContext;
        }

        public async Task<TUser> GetUserAsync(string login)
        {
            TUser usr;
            ActiveDirectoryUser aduser;
            switch (_policy)
            {
                case LoginResolutionPolicy.Username:
                    aduser = await _adService.GetAdUserAsync(login, false);
                    if (aduser == null)
                        return null;
                    usr = await _userManager.FindByNameAsync(login);
                    if (usr == null)
                    {
                        //create user
                        CreateDbUser(aduser.SamAccountName, aduser.Email);
                        return await _userManager.FindByNameAsync(login);
                    }
                    else
                    {
                        return usr;
                    }
                case LoginResolutionPolicy.Email:
                    aduser = await _adService.GetAdUserAsync(login, false, ActiveDirectoryService.UserFilter.Email);
                    if (aduser == null)
                        return null;
                    usr = await _userManager.FindByEmailAsync(login);
                    if (usr == null)
                    {
                        //create user
                        CreateDbUser(aduser.SamAccountName, aduser.Email);
                        return await _userManager.FindByEmailAsync(login);
                    }
                    else
                    {
                        return usr;
                    }
                default:
                    return null;
            }


        }

        void CreateDbUser(string samAccountName, string email)
        {
            //create user
            var idu = _adminDbContext.Users.Add(new UserIdentity()).Entity;
            idu.Id = Guid.NewGuid().ToString();
            idu.UserName = samAccountName;
            idu.NormalizedUserName = samAccountName.ToUpper();
            idu.Email = email;
            idu.NormalizedEmail = email?.ToUpper();
            _adminDbContext.SaveChanges();
        }


    }
}
