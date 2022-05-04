using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;
using Skoruba.IdentityServer4.STS.Identity.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.STS.Identity.Services
{
    public class ActiveDirectorySignInManager<TUser> : ApplicationSignInManager<TUser> where TUser : class
    {
        private IActiveDirectoryService _activedirservice;
        private IUserResolver<TUser> _userResolver;

        public ActiveDirectorySignInManager(UserManager<TUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<TUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<TUser>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<TUser> confirmation, IActiveDirectoryService activedirservice, IUserResolver<TUser> userResolver) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
            _activedirservice = activedirservice;
            _userResolver = userResolver;
        }

        public override async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            try
            {
                if (await _activedirservice.ValidateCredentialsAsync(userName, password))
                {

                    var user = await _userResolver.GetUserAsync(userName);
                    await base.SignInAsync(user, isPersistent: lockoutOnFailure);
                    return SignInResult.Success;
                }

                return SignInResult.Failed;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("locked"))
                    return SignInResult.LockedOut;
                else
                    return SignInResult.Failed;
            }
                     
        }

    }
}
