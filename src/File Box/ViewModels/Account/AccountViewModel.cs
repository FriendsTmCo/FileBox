using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Login View Model
/// </summary>
public record LoginViewModel
{
    /// <summary>
    /// Email Address
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Password
    /// </summary>
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }
}

/// <summary>
/// SignUp View Model
/// </summary>
public record SignUpViewModel
{
    /// <summary>
    /// User Name
    /// </summary>
    [Required]
    public string UserName { get; set; }

    /// <summary>
    /// Email Address
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Password
    /// </summary>
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }

    /// <summary>
    /// Confirm Password
    /// </summary>
    [Required]
    [PasswordPropertyText]
    [Compare("Password", ErrorMessage = "Wrong Password")]
    public string ConfirmPassword { get; set; }
}

/// <summary>
/// Active User View Model
/// </summary>
public record ActivationViewModell
{
    /// <summary>
    /// Email Address
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Active Code
    /// </summary>
    [Required]
    public string ActiveCode { get; set; }
}

/// <summary>
/// Connection View Model
/// </summary>
public record IpAddressInfos
{
    /// <summary>
    /// Remote connection Ip Address
    /// </summary>
    [Required]
    public string RemoteIp { get; set; }

    /// <summary>
    /// Local Connection Ip Address
    /// </summary>
    [Required]
    public string LocalIp { get; set; }

    /// <summary>
    /// Local Connection Port
    /// </summary>
    [Required]
    public string LocalPort { get; set; }

    /// <summary>
    /// Remote Connection Port
    /// </summary>
    [Required]
    public string RemotePort { get; set; }
}