using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.DataAccess
{
   public static class DataAccessHelper
    {
       public static bool? TryToBoolean(this string data)
       {
           bool? flag = null;
           if (!string.IsNullOrEmpty(data))
           {
               if (data == "Y" || data == "1")
                   flag = true;
               else
                   flag = false;
           }
           return flag;
       }
       public static string TryToString(this bool? data)
       {
           string flag = string.Empty;
           if(data != null)
           {
               if (data == true)
                   flag = "Y";
               else
                   flag = "F";
           }
           return flag;
       }
    }
}
