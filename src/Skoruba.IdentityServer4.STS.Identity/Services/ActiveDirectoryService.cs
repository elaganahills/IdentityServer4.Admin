
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

        string[] groupProperties = new string[] { "hhsIsAttribute1","hhsIsAttribute2" };
        string DistinguishedDomainName;

        bool LoadAtributes { get => _rootConfiguration.ActiveDirectoryConfiguration.LoadAtributes; }

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
            if (_rootConfiguration.ActiveDirectoryConfiguration.WindowsAutentiction)
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

            if (_rootConfiguration.ActiveDirectoryConfiguration.WindowsAutentiction)
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
    
            using (var searcher = new DirectorySearcher(GetDirectoryEntry()))
            {
     
                searcher.Filter = string.Format("(&(objectClass=user)({0}={1}))", (filterby == UserFilter.Name)? "anr" : "mail", name);
                searcher.SearchScope = SearchScope.Subtree;
                searcher.PropertiesToLoad.Add("cn");
                searcher.PropertiesToLoad.Add("samaccountname");
                if (LoadAtributes)
                    searcher.PropertiesToLoad.AddRange(groupProperties);

                foreach (SearchResult entry in searcher.FindAll())
                {
                    aduser.Name = entry.Properties["cn"][0].ToString();
                    aduser.SamAccountName = entry.Properties["samaccountname"][0].ToString();
                    if (entry.Properties["mail"] != null && entry.Properties["mail"].Count > 0)
                        aduser.Email = entry.Properties["mail"][0].ToString();
                    if (LoadAtributes)
                    {
                        foreach (string pname in entry.Properties.PropertyNames)
                        {
                            if (pname.StartsWith(_rootConfiguration.ActiveDirectoryConfiguration.AtributesStartFilter))
                            {
                                aduser.Claims.Add(new Claim(pname, entry.Properties[pname][0].ToString()));
                            }
                        }
                    }
                }

                searcher.Filter = String.Format("(&(objectCategory=group)(member=cn={0},cn=Users{1}))", aduser.Name,DistinguishedDomainName);

                foreach (SearchResult entry in searcher.FindAll())
                {
                    if (entry.Properties.Contains("cn"))
                    {
                        var adgroup = new ActiveDirectoryGroup();
                        adgroup.Name = entry.Properties["cn"][0].ToString();
                        aduser.Groups.Add(adgroup);

                        if (LoadAtributes)
                        {
                            foreach (string pname in entry.Properties.PropertyNames)
                            {
                                if (pname.StartsWith(_rootConfiguration.ActiveDirectoryConfiguration.AtributesStartFilter))
                                {
                                    adgroup.Claims.Add(new Claim(pname, entry.Properties[pname][0].ToString()));
                                }
                            }
                        }
                    }
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



