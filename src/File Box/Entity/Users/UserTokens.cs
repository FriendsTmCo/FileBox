using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Users Tokens 
/// </summary>
public record UserTokens
{
    /// <summary>
    /// Token Primary Key
    /// </summary>
    [Key]
    public int TokenId { get; set; }

    /// <summary>
    /// Forgen Key
    /// </summary>
    [Required]
    public Guid UserId { get; set; }

    /// <summary>
    /// Session Key
    /// </summary>
    [Required]
    public string Key { get; set; }

    /// <summary>
    /// Session Value
    /// </summary>
    [Required]
    public string Value { get; set; }

    /// <summary>
    /// Local Ip Address
    /// </summary>
    [Required]
    public string IpAddress { get; set; }

    /// <summary>
    /// Local Connection Port
    /// </summary>
    [Required]
    public string Port { get; set; }

    //Relationships

    /// <summary>
    /// Users Realtionships
    /// </summary>
    public virtual Users Users { get; set; }
}