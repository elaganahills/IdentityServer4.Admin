
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Text;
using Skoruba.IdentityServer4.STS.Identity.Configuration.Interfaces;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration;

namespace Skoruba.IdentityServer4.STS.Identity.Services
{


    public interface IActiveDirectoryService
    {
        Task<UserPrincipal> GetUserAsync(string name);
        Task<ActiveDirectoryUser> GetAdUserAsync(string name, bool loadproperties, ActiveDirectoryService.UserFilter filterby = ActiveDirectoryService.UserFilter.Name);
        Task<bool> ValidateCredentialsAsync(string userName, string password);
        Task<List<GroupPrincipal>> GetUserGroupsAsync(string name);

    }

    public class ActiveDirectoryService : IActiveDirectoryService
    {

        //PrincipalContext _principalContext;
        IRootConfiguration _rootConfiguration;
        
        string DistinguishedDomainName;

        ActiveDirectoryConfiguration _adConf { get => _rootConfiguration.ActiveDirectoryConfiguration; }

        public ActiveDirectoryService(IRootConfiguration rootConfiguration)
        {
            _rootConfiguration = rootConfiguration;
            //_principalContext = GetContext();

            DistinguishedDomainName = _rootConfiguration.ActiveDirectoryConfiguration.SearchBaseDN;
            if (string.IsNullOrEmpty(DistinguishedDomainName))
            {
                var sb = new StringBuilder();
                foreach (var dnp in _rootConfiguration.ActiveDirectoryConfiguration.Server.Split(".", StringSplitOptions.RemoveEmptyEntries))
                    sb.Append(",dc=" + dnp);

                DistinguishedDomainName = sb.ToString();
            }
        }

        PrincipalContext GetContext()
        {
            if (_rootConfiguration.ActiveDirectoryConfiguration.WindowsAutentication)
                return new PrincipalContext(ContextType.Domain,
                 _rootConfiguration.ActiveDirectoryConfiguration.Server);
            else
                return new PrincipalContext(ContextType.Domain,
                _rootConfiguration.ActiveDirectoryConfiguration.Server,
                _rootConfiguration.ActiveDirectoryConfiguration.Username,
                _rootConfiguration.ActiveDirectoryConfiguration.Password);
        }

        DirectoryEntry GetDirectoryEntry()
        {

            if (_rootConfiguration.ActiveDirectoryConfiguration.WindowsAutentication)
                return new DirectoryEntry("LDAP://" + _rootConfiguration.ActiveDirectoryConfiguration.Server);
            else
                return new DirectoryEntry("LDAP://" + _rootConfiguration.ActiveDirectoryConfiguration.Server,
                _rootConfiguration.ActiveDirectoryConfiguration.Username,
                _rootConfiguration.ActiveDirectoryConfiguration.Password);
        }

        public enum UserFilter { Name,Email }
        public async Task<ActiveDirectoryUser> GetAdUserAsync(string name, bool loadproperties, UserFilter filterby = UserFilter.Name )
        {
            var aduser = new ActiveDirectoryUser();

            using (var context = GetContext())
            {
                UserPrincipal u = UserPrincipal.FindByIdentity(context, name);
                aduser.Name = u.DisplayName;
                aduser.SamAccountName = u.SamAccountName;
                aduser.Email = u.EmailAddress;

                if (_adConf.LoadAttributes && _adConf.UserAttributes != null)
                {
                    var a = u.GetUnderlyingObject() as DirectoryEntry;
                    foreach (var ua in _adConf.UserAttributes)
                    {
                        var po = a.Properties[ua];
                        if (po != null && po.Value != null)
                        {
                            aduser.Claims.Add(new Claim(ua, po.Value.ToString()));
                            Console.WriteLine(ua + ":" + po.Value.ToString());
                        }
                    }
                }


                foreach (var g in u.GetAuthorizationGroups())
                {
                    var adgroup = new ActiveDirectoryGroup();
                    adgroup.Name = g.Name;

                    if (_adConf.LoadAttributes && _adConf.GroupAttributes != null)
                    {
                        var a = g.GetUnderlyingObject() as DirectoryEntry;
                        foreach (var ua in _adConf.GroupAttributes)
                        {
                            var po = a.Properties[ua];
                            if (po != null && po.Value != null)
                            {
                                adgroup.Claims.Add(new Claim(ua, po.Value.ToString()));
                                Console.WriteLine(ua + "(group):" + po.Value.ToString());
                            }
                        }
                    }

                    aduser.Groups.Add(adgroup);
                }

            }

            return aduser;
        }

        public async Task<UserPrincipal> GetUserAsync(string name)
        {
            using (var context = GetContext())
            {
                UserPrincipal u = UserPrincipal.FindByIdentity(context, name);
                return u;
            }
        }
        public async Task<List<GroupPrincipal>> GetUserGroupsAsync(string name)
        {
            using (var context = GetContext()) 
            { 
                UserPrincipal u = UserPrincipal.FindByIdentity(context, name);
                if (u == null)
                    return null;
                var gs = u.GetAuthorizationGroups().ToList().Where(o => o is GroupPrincipal).Select(o => (GroupPrincipal)o).ToList();
                return gs;
            }
        }

        public async Task<bool> ValidateCredentialsAsync(string userName, string password)
        {
            using (var context = GetContext())
                return context.ValidateCredentials(userName,password);
        }
    }


    public class ActiveDirectoryUser
    {

        public string Name { get; set; }
        public List<ActiveDirectoryGroup> Groups { get; set; } = new List<ActiveDirectoryGroup>();
        public List<Claim> Claims { get; set; } = new List<Claim>();

        public string SamAccountName { get; set; }
        public string Email { get; set; }
    }

    public class ActiveDirectoryGroup
    {
        public string Name { get; set; }
        public List<Claim> Claims { get; set; } = new List<Claim>();

    }
}



