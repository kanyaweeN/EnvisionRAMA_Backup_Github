using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class GBLSessionViewerSelect : DataAccessBase
    {
        private DataSet ds;
        private DateTime start;
        private DateTime end;

        private int mode;
        public GBLSessionViewerSelect(int mode)
        {
            this.mode = mode;
        }
        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }
        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }
        public DataSet GetSubMenu()
        {
            ds = new DataSet();
            SqlParameter[] _parameters = 
            {
                new SqlParameter("@SP_Types",mode)
                ,new SqlParameter("@SP_UID","")
                ,new SqlParameter("@ST_DATE",start)
                ,new SqlParameter("@FN_DATE",end)
            };
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.GBL_SESSION_VIEWER.ToString());
            ds = dbhelper.Run(base.ConnectionString, _parameters);
            return ds;
        }
    }
}
