using Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AccountServices : IAccountRepository
    {
        #region ::Dependency::

        /// <summary>
        /// User Services
        /// </summary>
        private readonly IUserRepository _user;

        private readonly ICrudRepository<Users> _cUser;

        public AccountServices(UserServices user)
        {
            _cUser = user;
            _user = user;
        }

        #endregion

        public Task<ActivationResult> Activation(ActivationViewModell activation)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResult> LoginAsync(LoginViewModel login)
        {
            throw new NotImplementedException();
        }

        public async Task<SignUpResult> SignUpAsync(SignUpViewModel SignUp)
        {
            return await Task.Run(async () =>
            {
                if (!await _user.IsExistAsync(SignUp.Email) && !_user.IsExist(SignUp.UserName))
                {
                    if (SignUp.Password == SignUp.ConfirmPassword)
                    {
                        Users newUser = CreateUser(SignUp);
                        return (await _cUser.InsertAsync(newUser) && await _cUser.SaveAsync()) ?
                        SignUpResult.Success : SignUpResult.Exception;
                    }
                }
                return SignUpResult.UserExist;
            });
        }

        private Users CreateUser(SignUpViewModel sing)
        {
            return new Users
            {
                UserName = sing.UserName.Trim().ToLower(),
                ActiveCode = Guid.NewGuid().GetHashCode().ToString().Replace("-", string.Empty).Substring(0, 6),
                ActiveDate = DateTime.Now,
                Email = sing.Email,
                IsActive = false,
                Password = sing.Password.CreateSHA256()
            };
        }
    }
}
