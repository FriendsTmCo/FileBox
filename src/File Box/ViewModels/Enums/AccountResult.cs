using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record LoginResult
{
    public LoginResulten Status { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}

public enum LoginResulten
{
    Success = 0,
    UserNotFount = -1,
    Exception = -2,
    IsntActiveUser = -3
}

public enum SignUpResult
{
    Success = 0,
    UserExist = -1,
    Exception = -2,
}

public record ActivationResult
{
    public ActivationResultEn Status { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}

public enum ActivationResultEn
{
    Success = 0,
    UserNotFounr = -1,
    Exception = -2,
    WrongActiveCode = -3
}