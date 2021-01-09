using Services.Repository;
using System;
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

        /// <summary>
        /// User Crud Services
        /// </summary>
        private readonly ICrudRepository<Users> _cUser;

        /// <summary>
        /// Token Repository
        /// </summary>
        private readonly ICrudRepository<UserTokens> _token;

        public AccountServices(UserServices user, TokenServices token)
        {
            _token = token;
            _cUser = user;
            _user = user;
        }

        #endregion

        public async Task<ActivationResult> Activation(ActivationViewModell activation, IpAddressInfos ipAddressInfos)
        {
            return await Task.Run(async () =>
            {
                var user = await _user.GetUserByEmailAddress(activation.Email);

                if (user != null)
                {
                    int result = await ActiveUserAsync(user, activation.ActiveCode);
                    switch (result)
                    {
                        case -1:
                            return new ActivationResult
                            {
                                Status = ActivationResultEn.WrongActiveCode
                            };

                        case 0:
                            {
                                if (await CreateTokenAsync(user.UserId, ipAddressInfos))
                                {
                                    return SuccessActive();
                                }
                                return new ActivationResult
                                {
                                    Status = ActivationResultEn.Exception
                                };
                            }

                        case -2:
                            return new ActivationResult
                            {
                                Status = ActivationResultEn.Exception
                            };

                        default:
                            goto case -2;
                    }
                }

                return new ActivationResult
                {
                    Status = ActivationResultEn.UserNotFound
                };
            });
        }

        public async Task<LoginResult> LoginAsync(LoginViewModel login, IpAddressInfos ipAddressInfos)
        {
            return await Task.Run(async () =>
            {
                var user = await _user.GetUserByEmailAddress(login.Email);
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        return await CreateTokenForLoginAsync(user.UserId, ipAddressInfos);
                    }
                    return new LoginResult()
                    {
                        Status = LoginResulten.IsntActiveUser
                    };
                }
                return new LoginResult()
                {
                    Status = LoginResulten.UserNotFount
                };
            });
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
                ActiveCode = UserTool.CreateActiveCode(),
                ActiveDate = DateTime.Now,
                Email = sing.Email,
                IsActive = false,
                Password = sing.Password.CreateSHA256()
            };
        }

        private async Task<int> ActiveUserAsync(Users user, string activeCode)
        {
            return await Task.Run(async () =>
            {
                if (user.ActiveCode == activeCode)
                {
                    user.IsActive = true;
                    user.ActiveCode = UserTool.CreateActiveCode();
                    user.ActiveDate = DateTime.Now;
                    return (await _cUser.UpdateAsync(user) && await _cUser.SaveAsync()) ? 0 : -2;
                }
                return -1;
            });
        }

        private ActivationResult SuccessActive()
        {
            return new ActivationResult
            {
                Key = "Token",
                Value = Guid.NewGuid().ToString().CreateSHA256(),
                Status = ActivationResultEn.Success
            };
        }

        private bool CheckPassword(Users user, string password)
        {
            return user.Password == password.CreateSHA256();
        }

        private async Task<bool> CreateTokenAsync(Guid userId, IpAddressInfos ipinfo)
        {
            return await Task.Run(async () =>
            {
                UserTokens token = new()
                {
                    IpAddress = ipinfo.LocalIp,
                    Key = "Token",
                    Port = ipinfo.LocalIp,
                    UserId = userId,
                    Value = Guid.NewGuid().ToString().CreateSHA256()
                };

                return (await _token.InsertAsync(token) && await _token.SaveAsync());
            });
        }

        private async Task<LoginResult> CreateTokenForLoginAsync(Guid userId, IpAddressInfos ipinfo)
        {
            return await Task.Run(async () =>
            {
                UserTokens token = new()
                {
                    IpAddress = ipinfo.LocalIp,
                    Key = "Token",
                    Port = ipinfo.LocalIp,
                    UserId = userId,
                    Value = Guid.NewGuid().ToString().CreateSHA256()
                };

                return (await _token.InsertAsync(token) && await _token.SaveAsync()) ?
                new LoginResult
                {
                    Status = LoginResulten.Success,
                    Key = token.Key,
                    Value = token.Value
                } : new LoginResult
                {
                    Status = LoginResulten.Exception
                };
            });
        }
    }
}
