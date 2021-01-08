using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Files Entity
/// </summary>
public record Files
{

    /// <summary>
    /// File Primary Key
    /// </summary>
    [Required]
    public Guid FileId { get; set; }

    /// <summary>
    /// file Name
    /// </summary>
    [Required]
    public string FileName { get; set; }

    /// <summary>
    /// File Download Link
    /// </summary>
    [Required]
    public string DownloadLink { get; set; }

    /// <summary>
    /// File Size
    /// </summary>
    [Required]
    public string Size { get; set; }

    /// <summary>
    /// Download Count 
    /// </summary>
    [Required]
    public string DownloadCount { get; set; }

    /// <summary>
    /// Upload File Date
    /// </summary>
    [Required]
    public DateTime UploadDate { get; set; }

    /// <summary>
    /// User foregen Key
    /// </summary>
    [Required]
    public Guid UserId { get; set; }

    //Realtionships

    /// <summary>
    /// Realtionships Users
    /// </summary>
    public virtual Users Users { get; set; }
}