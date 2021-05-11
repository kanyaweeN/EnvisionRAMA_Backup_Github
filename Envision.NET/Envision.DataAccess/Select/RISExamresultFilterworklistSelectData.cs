using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RISExamresultFilterworklistSelectData: DataAccessBase
    {
        public RIS_EXAMRESULT_FILTERWORKLIST RIS_EXAMRESULT_FILTERWORKLIST { get; set; }
        public RISExamresultFilterworklistSelectData()
        {
            RIS_EXAMRESULT_FILTERWORKLIST = new RIS_EXAMRESULT_FILTERWORKLIST(); 
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_FILTERWORKLIST_Select;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          //Parameter("@ORG_ID"	, new GBLEnvVariable().OrgID  )
                                       };
            return parameters;
        }

        public DataSet GetDataByRadId()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_FILTERRAD_Select;

            ParameterList = buildParameterDataByRadId();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterDataByRadId()
        {
            DbParameter[] parameters = { 
                                          Parameter("@EMP_ID"	, RIS_EXAMRESULT_FILTERWORKLIST.EMP_ID )
                                       };
            return parameters;
        }
    
    }
}
