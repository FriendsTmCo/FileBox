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
    /// File Extention
    /// </summary>
    [Required]
    public string Extention { get; set; }

    /// <summary>
    /// File Size Fix In Server
    /// </summary>
    public float FileSize { get; set; }
}

/// <summary>
/// Download File Api View Model
/// </summary>
public record DownloadFileViewModel
{
    /// <summary>
    /// File Base 64
    /// </summary>
    [Required]
    public string Base64 { get; set; }

    /// <summary>
    /// File Extention
    /// </summary>
    [Required]
    public string Extention { get; set; }

    /// <summary>
    /// File Name
    /// </summary>
    [Required]
    public string FileName { get; set; }
}