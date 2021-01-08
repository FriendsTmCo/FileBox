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