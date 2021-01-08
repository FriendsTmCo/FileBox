using Microsoft.EntityFrameworkCore;

/// <summary>
/// Data Base Context 
/// </summary>
public class FileContext : DbContext
{

    /// <summary>
    /// Constractor
    /// </summary>
    /// <param name="options">Db Context Option</param>
    public FileContext(DbContextOptions<FileContext> options):base(options)
    {

    }

    /// <summary>
    /// Users Table (DB Set)
    /// </summary>
    public virtual DbSet<Users> Users { get; set; }

    /// <summary>
    /// Tokens Table (DB Set)
    /// </summary>
    public virtual DbSet<UserTokens> UserTokens { get; set; }

    /// <summary>
    /// Files Table (DB Set)
    /// </summary>
    public virtual DbSet<Files> Files { get; set; }
}