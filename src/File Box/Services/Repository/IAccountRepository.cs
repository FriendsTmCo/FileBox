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
        /// <returns></returns>
        Task<LoginResult> LoginAsync(LoginViewModel login);

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
        /// <returns></returns>
        Task<ActivationResult> Activation(ActivationViewModell activation);
    }
}
