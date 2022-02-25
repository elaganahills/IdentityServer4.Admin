
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

            //DistinguishedDomainName = _adConf.SearchBaseDN;
            //if (string.IsNullOrEmpty(DistinguishedDomainName))
            //{
            //    var sb = new StringBuilder();
            //    foreach (var dnp in _adConf.Server.Split(".", StringSplitOptions.RemoveEmptyEntries))
            //        sb.Append("dc=" + dnp + ",");

            //    DistinguishedDomainName = sb.ToString().TrimEnd(',');
            //}
            //DistinguishedDomainName = null;
            if (!string.IsNullOrEmpty(_adConf.SearchBaseDN))
                DistinguishedDomainName = _adConf.SearchBaseDN;
            else
                DistinguishedDomainName = null;
        }

        PrincipalContext GetContext()
        {

            ContextOptions conopz = 0;

            if (_adConf.UseSimpleBind)
                conopz |= ContextOptions.SimpleBind;
            if (_adConf.UseNegotiate)
                conopz |= ContextOptions.Negotiate;
            if (_adConf.UseSecureSocketLayer)
                conopz |= ContextOptions.SecureSocketLayer;
            if (_adConf.UseSigning)
                conopz |= ContextOptions.Signing;
            if (_adConf.UseSealing)
                conopz |= ContextOptions.Sealing;
            if (_adConf.UseServerBind)
                conopz |= ContextOptions.ServerBind;

            if (conopz != 0)
            {
                if (_adConf.WindowsAutentication)
                    return new PrincipalContext(ContextType.Domain,
                     _adConf.Server + ":" + _adConf.Port.ToString(),
                     DistinguishedDomainName,
                     conopz);
                else
                    return new PrincipalContext(ContextType.Domain,
                    _adConf.Server + ":" + _adConf.Port.ToString(),
                    DistinguishedDomainName,
                     conopz,
                    _adConf.Username,
                    _adConf.Password);
            } else
            {
                if (_adConf.WindowsAutentication)
                    return new PrincipalContext(ContextType.Domain,
                     _adConf.Server + ":" + _adConf.Port.ToString(),
                     DistinguishedDomainName
                     );
                else
                    return new PrincipalContext(ContextType.Domain,
                    _adConf.Server + ":" + _adConf.Port.ToString(),
                    DistinguishedDomainName,
                    _adConf.Username,
                    _adConf.Password);
            }
         
        }

        DirectoryEntry GetDirectoryEntry()
        {

            if (_adConf.WindowsAutentication)
                return new DirectoryEntry("LDAP://" + _adConf.Server);
            else
                return new DirectoryEntry("LDAP://" + _adConf.Server,
                _adConf.Username,
                _adConf.Password);
        }

        public string TestPrincipalSearcher(string account)
        {
            using (var context = GetContext())
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {

                    UserPrincipal userSearch = new UserPrincipal(context);
                    userSearch.SamAccountName = account;
                    searcher.QueryFilter = userSearch;
                    var searchResults = searcher.FindAll();

                    List<UserPrincipal> results = new List<UserPrincipal>();
                    var sb = new StringBuilder();
                    foreach (Principal p in searchResults)
                    {
                        sb.Append(p.SamAccountName + ", ");
                        results.Add(p as UserPrincipal);
                    }

                    return results.Count.ToString() + " objects found " + sb.ToString();
                }
            }
        }

        public string TestFindBy(string name)
        {
            using (var context = GetContext())
            {
                UserPrincipal u = UserPrincipal.FindByIdentity(context, name);
                return "Information retrived: " + Newtonsoft.Json.JsonConvert.SerializeObject(u, new Newtonsoft.Json.JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore}) ;

            }
        }

        public String TestFindAllGroups()
        {
            var sb = new StringBuilder();

            using (var context = GetContext()) {
                GroupPrincipal findAllGroups = new GroupPrincipal(context, "*");
                PrincipalSearcher ps = new PrincipalSearcher(findAllGroups);
                foreach (Principal group in ps.FindAll())
                {
                    sb.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(group, new Newtonsoft.Json.JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore }));
                }

            }

            return sb.ToString();
        }

        public enum UserFilter { Name,Email }
        public async Task<ActiveDirectoryUser> GetAdUserAsync(string name, bool loadproperties, UserFilter filterby = UserFilter.Name )
        {
            var aduser = new ActiveDirectoryUser();

            using (var context = GetContext())
            {

                UserPrincipal user = UserPrincipal.FindByIdentity(context, name);
                aduser.Name = user.DisplayName;
                aduser.SamAccountName = user.SamAccountName;
                aduser.Email = user.EmailAddress;

                if (_adConf.LoadAttributes && _adConf.UserAttributes != null)
                {
                    var a = user.GetUnderlyingObject() as DirectoryEntry;
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


                //var groups = GroupPrincipal.FindByIdentity(context, IdentityType.SamAccountName, user.SamAccountName);
                //groups.lis
                //using (var searcher = new PrincipalSearcher(user))
                //{
                //    searcher.QueryFilter


                //    UserPrincipal userSearch = new UserPrincipal(context);
                //    var g = GroupPrincipal();

                //    userSearch.SamAccountName = account;
                //    searcher.QueryFilter = ;
                //    var searchResults = searcher.FindAll();

                //    List<UserPrincipal> results = new List<UserPrincipal>();
                //    var sb = new StringBuilder();
                //    foreach (Principal p in searchResults)
                //    {
                //        sb.Append(p.SamAccountName + ", ");
                //        results.Add(p as UserPrincipal);
                //    }

                //    return results.Count.ToString() + " objects found " + sb.ToString();
                //}

                //using (var searcher = new DirectorySearcher(new DirectoryEntry("LDAP://" + domainContext.Name)))
                //{
                //    searcher.Filter = String.Format("(&(objectCategory=group)(member={0}))", user.DistinguishedName);
                //    searcher.SearchScope = SearchScope.Subtree;
                //    searcher.PropertiesToLoad.Add("cn");

                //    foreach (SearchResult entry in searcher.FindAll())
                //        if (entry.Properties.Contains("cn"))
                //            result.Add(entry.Properties["cn"][0].ToString());
                //}

                try
                {
                    //try to attach groups
                    foreach (var g in user.GetGroups(GetContext()))
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
                catch (Exception ex)
                {
                    aduser.ErrorRetringGroups = ex.Message;
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
        public string ErrorRetringGroups { get; set; }
    }

    public class ActiveDirectoryGroup
    {
        public string Name { get; set; }
        public List<Claim> Claims { get; set; } = new List<Claim>();

    }
}



