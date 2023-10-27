using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Data.OleDb;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hills.IdentityServer4.STS.Identity.Services
{
    public class CustomRedirectUriValidator //: IRedirectUriValidator
    {
        public CustomRedirectUriValidator() { 
        }

        public Task<bool> IsPostLogoutRedirectUriValidAsync(string requestedUri, Client client)
        {
            if (client.PostLogoutRedirectUris.Contains(requestedUri))
            {
                return Task.FromResult(true);
            }
            else
            {
                foreach (var uri in client.PostLogoutRedirectUris.Where(pl => pl.Contains(":*")))
                {
                    string pattern = string.Concat(@"^", uri.Replace(":*", ":(\\d*)"));
                    Match m = Regex.Match(requestedUri, pattern, RegexOptions.IgnoreCase);
                    if (m.Success)
                    {
                        return Task.FromResult(true);
                    }
                }
            }
            return Task.FromResult(false);            
        }

        public Task<bool> IsRedirectUriValidAsync(string requestedUri, Client client)
        {
            if (client.RedirectUris.Contains(requestedUri))
            {
                return Task.FromResult(true);
            }
            else
            {
                foreach (var uri in client.RedirectUris.Where(pl => pl.Contains(":*")))
                {
                    string pattern = string.Concat(@"^", uri.Replace(":*", ":(\\d*)"));
                    Match m = Regex.Match(requestedUri, pattern, RegexOptions.IgnoreCase);
                    if (m.Success)
                    {
                        return Task.FromResult(true);
                    }
                }
            }
            return Task.FromResult(false);
        }
    }
}
