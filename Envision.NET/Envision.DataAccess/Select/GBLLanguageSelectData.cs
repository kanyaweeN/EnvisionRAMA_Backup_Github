using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class GBLLanguageSelectData : DataAccessBase
    {

        public GBLLanguageSelectData()
        {
            StoredProcedureName = StoredProcedure.GBLLanguage_Select;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet Get2()
        {
            StoredProcedureName = StoredProcedure.GBLLanguage_Select2;
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                 Parameter( "@p_orgid"	, new GBLEnvVariable().OrgID )
                                       };
            return parameters;
        }
    }
}
