using System.ComponentModel.DataAnnotations;

/// <summary>
/// Upload File Client (API) View Model
/// </summary>
public record FileviewModel
{

    /// <summary>
    /// Base 64 File
    /// </summary>
    [Required]
    public string Base64 { get; set; }

    /// <summary>
    /// File Size Fix In Server
    /// </summary>
    public float FileSize { get; set; }
}