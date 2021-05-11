using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace UtilityClass
{
    public  class Helper
    {
        public static bool HasRow(DataTable dtt) {
            if (dtt == null) return false;
            if (dtt.Rows.Count == 0) return false;
            return true;
        }
        public static bool HasRow(DataSet ds) {
            if (ds == null) return false;
            if (ds.Tables.Count == 0) return false;
            bool flag = false;
            foreach (DataTable dtt in ds.Tables) {
                if (HasRow(dtt)) {
                    flag = true;
                    break;
                }      
            }

            return flag;
        }

        
    }
}
