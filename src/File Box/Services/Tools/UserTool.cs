using System;

/// <summary>
/// Users tools
/// </summary>
public class UserTool
{

    /// <summary>
    /// Create Active Code
    /// </summary>
    /// <returns>a 6 Length String For Active Code</returns>
   public static string CreateActiveCode() => Guid.NewGuid().GetHashCode().ToString().Replace("-", string.Empty).Substring(0, 6);
}