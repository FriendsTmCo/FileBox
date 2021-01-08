using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// File Create Result
/// </summary>
public enum FileResult
{
    /// <summary>
    /// Not Found Any User
    /// </summary>
    UserNotFound = -1,

    /// <summary>
    /// Success
    /// </summary>
    Success = 0,

    /// <summary>
    /// Null Base 64 
    /// </summary>
    NullRefrenceBase64 = -3,

    /// <summary>
    /// any Wrong
    /// </summary>
    Exceptions = -2
}
