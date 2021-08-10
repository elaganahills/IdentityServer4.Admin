using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.STS.Identity.Helpers
{
    public interface IUserResolver<TUser> where TUser : class
    {
        Task<TUser> GetUserAsync(string login);
    }
}