using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace RIS.Common.Common.Utility
{
    public static class EnvisionHelper
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
            foreach(DataTable dt in ds.Tables)
                if (HasRow(dt)) {
                    flag = true;
                    break;
                }

            return flag;
        }

    }
}
