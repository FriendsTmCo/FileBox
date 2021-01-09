using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class UserTool
{
   public static string CreateActiveCode() => Guid.NewGuid().GetHashCode().ToString().Replace("-", string.Empty).Substring(0, 6);
}