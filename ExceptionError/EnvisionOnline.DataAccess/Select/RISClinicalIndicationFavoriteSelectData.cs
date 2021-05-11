using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISClinicalIndicationFavoriteSelectData : DataAccessBase
    {
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }
        public RISClinicalIndicationFavoriteSelectData()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONFAVORITES_Select;
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
                                             Parameter( "@ORG_ID"	        , RIS_CLINICALINDICATION.ORG_ID ),
                                             Parameter( "@EMP_ID"		    , RIS_CLINICALINDICATION.EMP_ID ) ,
                                       };
            return parameters;
        }
    }
}
