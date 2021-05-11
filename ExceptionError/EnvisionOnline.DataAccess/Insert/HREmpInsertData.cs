using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class HREmpInsertData: DataAccessBase
    {
        public HR_EMP HR_EMP { get; set; }
        public HREmpInsertData()
        {
            HR_EMP = new HR_EMP();
        }
        public DataSet GetData(string query)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSetByString(query);
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={		
	             Parameter("@EMP_UID",HR_EMP.EMP_UID)
                ,Parameter("@USER_NAME",HR_EMP.USER_NAME)
                ,Parameter("@FNAME",HR_EMP.FNAME)
                ,Parameter("@LNAME",HR_EMP.LNAME)
                ,Parameter("@FNAME_ENG",HR_EMP.FNAME_ENG)
                ,Parameter("@LNAME_ENG",HR_EMP.LNAME_ENG)
			};
            return parameters;
        }

        public int AddFromHIS()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_InsertFromHIS;
            ParameterList = buildParameterFromHIS();
            ds = ExecuteDataSet();
            int id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id;
        }
        private DbParameter[] buildParameterFromHIS()
        {
            DbParameter[] parameters ={
                Parameter("@EMP_UID",HR_EMP.EMP_UID)
                ,Parameter("@USER_NAME",HR_EMP.USER_NAME)
                ,Parameter("@FNAME",HR_EMP.FNAME)
                ,Parameter("@LNAME",HR_EMP.LNAME)
                ,Parameter("@ORG_ID",HR_EMP.ORG_ID)
                ,Parameter("@CREATED_BY",HR_EMP.CREATED_BY)
            };
            return parameters;
        }
    }
}
