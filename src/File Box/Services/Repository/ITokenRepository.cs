using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repository
{
    /// <summary>
    /// Token Repository
    /// </summary>
    public interface ITokenRepository
    {
        /// <summary>
        /// Find And Return Token By Value
        /// </summary>
        /// <param name="value">Token Value</param>
        /// <returns></returns>
        Task<UserTokens> GetTokenByValueAsync(string value);

        /// <summary>
        /// Return Tokens By Token Key
        /// </summary>
        /// <param name="key">Token Key</param>
        /// <returns></returns>
        Task<IEnumerable<UserTokens>> GetTokensByKeyAsync(string key);
    }
}
