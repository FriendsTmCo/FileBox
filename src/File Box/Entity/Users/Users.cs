using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Users Table 
/// </summary>
public record Users
{

    /// <summary>
    /// Users Primary Key
    /// </summary>
    [Key]
    public Guid UserId { get; set; }

    /// <summary>
    /// User Name
    /// </summary>
    [Required]
    public string UserName { get; set; }

    /// <summary>
    /// Email
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
    /// Is Actived User
    /// </summary>
    [Required]
    public bool IsActive { get; set; }

    /// <summary>
    /// Active Code
    /// </summary>
    [Required]
    public string ActiveCode { get; set; }

    /// <summary>
    /// Profile Photo
    /// </summary>
    public string ProfilePhotoName { get; set; }

    /// <summary>
    /// Regester Date 
    /// </summary>
    [Required]
    public DateTime ActiveDate { get; set; }

    //Realtionships 

    /// <summary>
    /// Tokens Realtionships 
    /// </summary>
    public virtual List<UserTokens> UserTokens { get; set; }

    /// <summary>
    /// Files Realtionships
    /// </summary>
    public virtual List<Files> Files { get; set; }

}