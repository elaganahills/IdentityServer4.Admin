using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.DbContexts;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.STS.Identity.Services
{
    public class ProfileService : IProfileService
    {
        protected UserManager<UserIdentity> _userManager;
        protected IEventService _events;
        protected IActiveDirectoryService _activedirservice;
        protected AdminIdentityDbContext _identityService;

        public ProfileService(UserManager<UserIdentity> userManager, IEventService events, IActiveDirectoryService activedirservice,
            AdminIdentityDbContext identityService)
        {
            _userManager = userManager;
            _events = events;
            _activedirservice = activedirservice;
            _identityService = identityService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //>Processing

            //var claims = await _userManager.GetClaimsAsync(user);
            //var roles = await _userManager.GetRolesAsync(user);
            ////_userManager.cla
            //_userManager.claim
            //var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);
            //List<string> list = context.RequestedClaimTypes.ToList();
            //context.IssuedClaims.AddRange(roleClaims);

            if (context.RequestedClaimTypes.Any())
            {
                var user = await _userManager.GetUserAsync(context.Subject);

                //process the active directory rquest only if required

                List<Claim> claims = new List<Claim>();
                //var cpu = context.Subject.Claims.FirstOrDefault(c => c.Type == "preferred_username");
                //var username = cpu.Value;

                claims.AddRange(_identityService.UserClaims.Where(uc => uc.UserId == user.Id).Select(uc => new Claim(uc.ClaimType, uc.ClaimValue)));

                var adusr = await _activedirservice.GetAdUserAsync(user.UserName, true);

                claims.AddRange(adusr.Claims);
                claims.Add(new Claim("name", adusr.Name));

                foreach (var g in adusr.Groups)
                {
                    var is4role = _identityService.Roles.FirstOrDefault(r => r.ActiveDirectoryRole == g.Name);
                    if (is4role != null)
                        //add group role
                        claims.Add(new Claim("role", is4role.Name));
                    else
                        claims.Add(new Claim("role", g.Name));

                    claims.AddRange(g.Claims);
                    //check if a group exist in the db and load roles
                    var dbrole = _identityService.Roles.FirstOrDefault(r => r.Name == g.Name);
                    if (dbrole != null)
                    {
                        //role exist in db
                        var dbroleclaims = _identityService.RoleClaims.Where(rc => rc.RoleId == dbrole.Id);
                        foreach (var rc in dbroleclaims)
                            claims.Add(new Claim(rc.ClaimType, rc.ClaimValue));
                    }
                }

                //do not filter anything...
                context.IssuedClaims.AddRange(claims.Where(cl => context.RequestedClaimTypes.Contains(cl.Type, StringComparer.InvariantCultureIgnoreCase)));
                //context.IssuedClaims.AddRange(context.Subject.Claims);

            }

        }

        public async Task IsActiveAsync(IsActiveContext context)
        {



            //>Processing
            var user = await _userManager.GetUserAsync(context.Subject);
            
            context.IsActive = (user != null) && true; // user.IsActive;
        }
    }
}
