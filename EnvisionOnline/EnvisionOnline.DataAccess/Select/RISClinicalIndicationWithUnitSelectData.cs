using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISClinicalIndicationWithUnitSelectData: DataAccessBase
    {
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }
        public RISClinicalIndicationWithUnitSelectData()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONWITHUNIT_Select;
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
                                             Parameter( "@UNIT_ID"		    , RIS_CLINICALINDICATION.UNIT_ID ) ,
                                             Parameter( "@ORG_ID"	        , RIS_CLINICALINDICATION.ORG_ID ),
                                       };
            return parameters;
        }
    }
}

