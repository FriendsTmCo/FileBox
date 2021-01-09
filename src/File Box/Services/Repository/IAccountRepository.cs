using System.Threading.Tasks;

namespace Services.Repository
{
    /// <summary>
    /// Account Repository
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="login">Login View Model</param>
        /// <param name="ipAddressInfos">Connection Info</param>
        /// <returns></returns>
        Task<LoginResult> LoginAsync(LoginViewModel login, IpAddressInfos ipAddressInfos);

        /// <summary>
        /// SignUp User
        /// </summary>
        /// <param name="SignUp">SignUp View Model</param>
        /// <returns></returns>
        Task<SignUpResult> SignUpAsync(SignUpViewModel SignUp);

        /// <summary>
        /// Active User
        /// </summary>
        /// <param name="activation">Activation View Model</param>
        /// <param name="ipAddressInfos">connection Info</param>
        /// <returns>Activation Result</returns>
        Task<ActivationResult> Activation(ActivationViewModell activation,IpAddressInfos ipAddressInfos);
    }
}
