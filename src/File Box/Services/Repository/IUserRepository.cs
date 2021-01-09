using Microsoft.AspNetCore.Http;
using System;
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

        /// <summary>
        /// Find User By Email Address
        /// </summary>
        /// <param name="email">User Email</param>
        /// <returns>User</returns>
        Task<Users> GetUserByEmailAddress(string email);

        /// <summary>
        /// Check Exist User With User Id
        /// </summary>
        /// <param name="Id">User Id</param>
        /// <returns></returns>
        Task<bool> IsExistAsync(Guid Id);

        /// <summary>
        /// Check Exist User With Emai Address
        /// </summary>
        /// <param name="EmailAddress">Email Address Or</param>
        /// <returns></returns>
        Task<bool> IsExistAsync(string EmailAddress);

        /// <summary>
        /// Check Exist User With User Name
        /// </summary>
        /// <param name="UserName">User Name</param>
        /// <returns></returns>
        bool IsExist(string UserName);
    }
}
