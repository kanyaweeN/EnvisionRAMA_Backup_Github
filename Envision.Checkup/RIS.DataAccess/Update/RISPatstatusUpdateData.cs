using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class RISPatstatusUpdateData : DataAccessBase
    {
        private RISPatstatus _rispatstatus;
        private RISPatstatusUpdateDataParameters param;
        public RISPatstatusUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_PATSTATUS_Update.ToString();
        }
        public RISPatstatus RISPatstatus
        {
            get { return _rispatstatus; }
            set { _rispatstatus = value; }
        }
        public bool Update()
        {
            param = new RISPatstatusUpdateDataParameters(RISPatstatus);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, param.Parameters);
            return true;
        }
    }
    public class RISPatstatusUpdateDataParameters
    {
        private RISPatstatus _rispatstatus;
        private SqlParameter[] _parameters;
        public RISPatstatusUpdateDataParameters(RISPatstatus rispatstatus)
        {
            RISPatstatus = rispatstatus;
            Build();
        }
        public RISPatstatus RISPatstatus
        {
            get { return _rispatstatus; }
            set { _rispatstatus = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        public void Build()
		{

            SqlParameter[] parameters ={
                new SqlParameter("@STATUS_ID",RISPatstatus.STATUS_ID)
                ,new SqlParameter("@STATUS_UID",RISPatstatus.STATUS_UID)
                ,new SqlParameter("@STATUS_TEXT",RISPatstatus.STATUS_TEXT)
                ,new SqlParameter("@IS_ACTIVE",RISPatstatus.IsActive)
                ,new SqlParameter("@ORG_ID",RISPatstatus.ORG_ID)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISPatstatus.LAST_MODIFIED_BY)
                ,new SqlParameter("@IS_DEFAULT",RISPatstatus.IS_DEFAULT)
			};
			_parameters = parameters;
    }
    }
}
