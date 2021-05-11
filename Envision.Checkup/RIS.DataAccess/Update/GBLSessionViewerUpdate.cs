using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;
using RIS.Common.Common;

namespace RIS.DataAccess.Update
{
    public class GBLSessionViewerUpdate : DataAccessBase
    {
        private string userLogin;
        private string sessionGUID;
        private string reason;
        public string UserLogin
        {
            get { return userLogin; }
            set { userLogin = value; }
        }
        public string SessionGUID
        {
            get { return sessionGUID; }
            set { sessionGUID = value; }
        }
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
        public GBLSessionViewerUpdate()
        {

        }
        public void Update()
        {
            SqlParameter[] _parameters = 
            {
                new SqlParameter("@GUID", sessionGUID)
                ,new SqlParameter("@USER", userLogin)
                ,new SqlParameter("@REASON", reason)
            };
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.GBL_SESSION_VIEWER_UPDATE.ToString());
            dbhelper.Run(base.ConnectionString, _parameters);
        }
    }
}
