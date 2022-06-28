using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class FormAccessSelectData : DataAccessBase
    {
        public FormAccessSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_SetFormAccess;
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
                                               
                                                  Parameter("@FormID"	, new GBLEnvVariable().CurrentFormID),
                                                  Parameter("@EmpID"	, new GBLEnvVariable().CurrentFormID),
                                                  Parameter("@OrgID"	, new GBLEnvVariable().CurrentFormID),
                                            
                                       };
            return parameters;
        }
    }
}
