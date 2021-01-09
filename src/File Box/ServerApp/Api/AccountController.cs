using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Repository;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        #region ::Dependency::

        /// <summary>
        /// Account Services
        /// </summary>
        private readonly IAccountRepository _account;

        public AccountController(AccountServices account)
        {
            _account = account;
        }

        #endregion

        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> SignUp(SignUpViewModel signUp)
        {
            SignUpResult result = await _account.SignUpAsync(signUp);

            switch (result)
            {
                case SignUpResult.Success:
                    return Ok(new
                    {
                        Id = 0,
                        Title = "Success",
                        Result = new { }
                    });

                case SignUpResult.UserExist:
                    return Ok(new
                    {
                        Id = -1,
                        Title = "UserExist",
                        Result = new { }
                    });

                case SignUpResult.Exception:
                    return Ok(new
                    {
                        Id = -2,
                        Title = "Exception",
                        Result = new { }
                    });

                default:
                    goto case SignUpResult.Exception;
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var result = await _account.LoginAsync(login, CreateInfo(HttpContext.Connection));

            switch (result.Status)
            {
                case LoginResulten.Success:
                    return Ok(new { Id = 0, Title = "Success", Result = result });

                case LoginResulten.UserNotFount:
                    return Ok(new { Id = -1, Title = "User Not Found", Result = new { } });

                case LoginResulten.Exception:
                    return Ok(new { Id = -2, Title = "Exception", Result = new { } });

                case LoginResulten.IsntActiveUser:
                    return Ok(new { Id = -3, Title = "IsntActiveUser", Result = new { } });

                default:
                    goto case LoginResulten.Exception;
            }
        }

        public async Task<IActionResult> ActiveUser(ActivationViewModell activation)
        {
            ActivationResult result = await _account.Activation(activation, CreateInfo(HttpContext.Connection));

            switch (result.Status)
            {
                case ActivationResultEn.Success:
                    return Ok(new { Id = 0, Title = "Success", Result = result });

                case ActivationResultEn.UserNotFound:
                    return Ok(new { Id = -1, Title = "User Not Found", Result = new { } });

                case ActivationResultEn.Exception:
                    return Ok(new { Id = -2, Title = "Exception", Result = new { } });

                case ActivationResultEn.WrongActiveCode:
                    return Ok(new { Id = -3, Title = "Wrong Active Code", Result = new { } });

                default:
                    goto case ActivationResultEn.Exception;
            }
        }

        private IpAddressInfos CreateInfo(ConnectionInfo connection)
        {
            return new IpAddressInfos
            {
                LocalIp = connection.LocalIpAddress.ToString(),
                LocalPort = connection.LocalPort.ToString(),
                RemoteIp = connection.RemoteIpAddress.ToString(),
                RemotePort = connection.RemotePort.ToString()
            };
        }
    }
}
