using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class HREmpSelectData : DataAccessBase
    {
        public HR_EMP HR_EMP { get; set; }

        public HREmpSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_Select;
            HR_EMP = new HR_EMP();
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                Parameter("@MODE",HR_EMP.MODE)
                                                ,Parameter("@EMP_ID",HR_EMP.EMP_ID)
                                                ,Parameter("@USER_NAME",HR_EMP.USER_NAME)
                                                ,Parameter("@UNIT_ID",HR_EMP.UNIT_ID)
                                                ,Parameter("@AUTH_LEVEL_ID",HR_EMP.AUTH_LEVEL_ID)
                                       };
            return parameters;
        }
        public DataSet GetDateLite()
        {
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_SelectLite;

            ParameterList = new DbParameter[]
            {
                Parameter("@ORG_ID",HR_EMP.ORG_ID)
            };

            return ExecuteDataSet();
        }

        public DataSet checkData()
        {
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_ByEmpUID_PWD_Select;
            DataSet ds = new DataSet();
            ParameterList = buildParametercheckData();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParametercheckData()
        {
            DbParameter[] parameters = { 
                                                Parameter("@MODE",HR_EMP.MODE)
                                                ,Parameter("@EMP_UID",HR_EMP.EMP_UID)
                                                ,Parameter("@USER_NAME",HR_EMP.USER_NAME)
                                                ,Parameter("@PWD",HR_EMP.PWD)
                                       };
            return parameters;
        }
        
    }
}
