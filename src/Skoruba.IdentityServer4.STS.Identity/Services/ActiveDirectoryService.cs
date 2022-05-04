
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
using Hills.Extensions;
using System.DirectoryServices.Protocols;
using System.Net;

namespace Skoruba.IdentityServer4.STS.Identity.Services
{


    public interface IActiveDirectoryService
    {
        //Task<UserPrincipal> GetUserAsync(string name);
        Task<ActiveDirectoryUser> GetAdUserAsync(string name, bool loadproperties, ActiveDirectoryService.UserFilter filterby = ActiveDirectoryService.UserFilter.Name);
        Task<bool> ValidateCredentialsAsync(string userName, string password);
        Task<List<ActiveDirectoryGroup>> GetUserGroupsAsync(string name);
        Task<ActiveDirectoryUser> GetAdUserAsync(string name);

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

            AuthenticationTypes conopz = 0;
            if (_adConf.UseSecure)
                conopz |= AuthenticationTypes.Secure;
            if (_adConf.UseSecureSocketLayer)
                conopz |= AuthenticationTypes.SecureSocketsLayer;
            if (_adConf.UseReadonlyServer)
                conopz |= AuthenticationTypes.ReadonlyServer;
            if (_adConf.UseAnonymous)
                conopz |= AuthenticationTypes.Anonymous;
            if (_adConf.UseSimpleBind)
                conopz |= AuthenticationTypes.FastBind;
            if (_adConf.UseSigning)
                conopz |= AuthenticationTypes.Signing;
            if (_adConf.UseSealing)
                conopz |= AuthenticationTypes.Sealing;
            if (_adConf.UseDelegation)
                conopz |= AuthenticationTypes.Delegation;
            if (_adConf.UseServerBind)
                conopz |= AuthenticationTypes.ServerBind;

            string server = "LDAP://" + _adConf.Server + ":" + _adConf.Port;

            if (!DistinguishedDomainName.IsNullOrEmpty())
                server += "/" + DistinguishedDomainName;

            if (conopz != 0)
            {                
                    return new DirectoryEntry(server,
                    _adConf.Username,
                    _adConf.Password, conopz);
            } else
            {
                if (_adConf.WindowsAutentication)
                    return new DirectoryEntry(server);
                else
                    return new DirectoryEntry(server,
                    _adConf.Username,
                    _adConf.Password);
            }

 
        }
        public async Task<ActiveDirectoryUser> GetAdUserAsync(string name)
        {
            return await GetAdUserAsync(name, false);
        }

        public enum UserFilter { Name,Email }
        public async Task<ActiveDirectoryUser> GetAdUserAsync(string name, bool loadproperties, UserFilter filterby = UserFilter.Name )
        {
            var aduser = new ActiveDirectoryUser();


            using (var entry = GetDirectoryEntry())
            {
                DirectorySearcher mySearcher = new DirectorySearcher(entry);

                mySearcher.Filter = "(&(objectClass=user)(|(cn=" + name + ")(sAMAccountName=" + name + ")))";
                mySearcher.PropertiesToLoad.Add("name");
                mySearcher.PropertiesToLoad.Add("displayName");
                mySearcher.PropertiesToLoad.Add("sAMAccountName");
                mySearcher.PropertiesToLoad.Add("mail");
                mySearcher.PropertiesToLoad.Add("memberOf");

                SearchResult result = mySearcher.FindOne();

                if (result == null)
                {
                    throw new Exception("User not found");
                }

                DirectoryEntry directoryObject = result.GetDirectoryEntry();
                aduser.Name = (string)directoryObject.Properties["name"].Value;
                aduser.SamAccountName = (string)directoryObject.Properties["sAMAccountName"].Value;
                aduser.Email = (string)directoryObject.Properties["mail"].Value;

                var groups = (PropertyValueCollection) directoryObject.Properties["memberOf"];
                foreach (var group in groups)
                {
                    var id = (string)group;
                    var g = id.Split(',').First().TrimStart("CN=");
                    aduser.Groups.Add(new ActiveDirectoryGroup() { Name = g });
                }
            }

            return aduser;
        }

        //public async Task<UserPrincipal> GetUserAsync(string name)
        //{
        //    using (var context = GetContext())
        //    {
        //        UserPrincipal u = UserPrincipal.FindByIdentity(context, name);
        //        return u;
        //    }
        //}
        //public async Task<List<GroupPrincipal>> GetUserGroupsAsync(string name)
        //{
        //    using (var context = GetContext()) 
        //    { 
        //        UserPrincipal u = UserPrincipal.FindByIdentity(context, name);
        //        if (u == null)
        //            return null;
        //        var gs = u.GetAuthorizationGroups().ToList().Where(o => o is GroupPrincipal).Select(o => (GroupPrincipal)o).ToList();
        //        return gs;
        //    }
        //}

        public async Task<bool> ValidateCredentialsAsync(string userName, string password)
        {
            try
            {
                LdapConnection connection = new LdapConnection(_adConf.Server + ":" + _adConf.Port.ToString());
                NetworkCredential credential = new NetworkCredential(userName, password);
                connection.Credential = credential;
                connection.Bind();

                return true;
            }
            catch (LdapException lexc)
            {
                string error = lexc.ServerErrorMessage;
                var errorcode = lexc.ServerErrorMessage.Split(',').FirstOrDefault(e => e.Trim().ToLower().StartsWith("data"))
                    .Split(' ').Last();
                if (errorcode == "525")
                    error = "525​ user not found ​(1317)";
                if (errorcode == "52e")
                    error = "52e​ invalid credentials ​(1326)";
                if (errorcode == "530")
                    error = "530​ not permitted to logon at this time​ (1328)";
                if (errorcode == "531")
                    error = "531​ not permitted to logon at this workstation​ (1329)";
                if (errorcode == "532")
                    error = "532​ password expired ​(1330)";
                if (errorcode == "533")
                    error = "533​ account disabled ​(1331)";
                if (errorcode == "701")
                    error = "701​ account expired ​(1793)";
                if (errorcode == "773")
                    error = "773​ user must reset password (1907)";
                if (errorcode == "775")
                    error = "775​ user account locked (1909)";

                throw new Exception(error);

            }
           
        }

       
        public async Task<List<ActiveDirectoryGroup>> GetUserGroupsAsync(string name)
        {
            var adu = await GetAdUserAsync(name, false);
            return adu.Groups.ToList();
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



