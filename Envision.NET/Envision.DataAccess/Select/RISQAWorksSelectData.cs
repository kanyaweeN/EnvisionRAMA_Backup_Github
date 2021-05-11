using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISQAWorksSelectData : DataAccessBase 
    {
        public RIS_QAWORK RIS_QAWORK { get; set; }
        public RISQAWorksSelectData()
        {
            RIS_QAWORK = new RIS_QAWORK();
        }
        public DataSet GetReport_QAWorks(DateTime FromDate, DateTime ToDate, int UserID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_QAWORKS_Select_rptQAWorks;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_Report(FromDate, ToDate, UserID);
            ds = ExecuteDataSet();
            return ds;
        }
         private DbParameter[] buildParameter_Report(DateTime FromDate, DateTime ToDate, int UserID)
         {
             DbParameter[] parameters ={			
                Parameter("@FromDate",FromDate),
                Parameter("@ToDate",ToDate),
                Parameter("@USER_ID",UserID)
			};
             return parameters;
         }
        public DataSet GetData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_QAWORKS_Select;
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                    Parameter("@MODE",RIS_QAWORK.MODE),
                    Parameter("@FROM_DATE",RIS_QAWORK.FROM_DATE),
                    Parameter("@TO_DATE",RIS_QAWORK.TO_DATE),
			};
            return parameters;
        }
    }
}
