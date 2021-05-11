using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISClinicalIndicationTypeFavoriteSelectData : DataAccessBase
    {
        public RIS_CLINICALINDICATIONTYPE RIS_CLINICALINDICATIONTYPE { get; set; }
        public RISClinicalIndicationTypeFavoriteSelectData()
        {
            RIS_CLINICALINDICATIONTYPE = new RIS_CLINICALINDICATIONTYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONTYPEFAVORITES_Select;
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
                                             Parameter( "@ORG_ID"	        , RIS_CLINICALINDICATIONTYPE.ORG_ID ),
                                             Parameter( "@EMP_ID"		    , RIS_CLINICALINDICATIONTYPE.EMP_ID ) ,
                                       };
            return parameters;
        }
    }
}

