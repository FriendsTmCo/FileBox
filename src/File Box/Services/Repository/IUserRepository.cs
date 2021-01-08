using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Services.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get User From Request Header
        /// </summary>
        /// <param name="header">Headers</param>
        /// <returns></returns>
        Task<Users> GetUserFromTokenAsync(IHeaderDictionary header);

        /// <summary>
        /// Get User From Request Cookies
        /// </summary>
        /// <param name="cookies">Cookies</param>
        /// <returns></returns>
        Task<Users> GetUserFromTokenAsync(IRequestCookieCollection cookies);
    }
}
