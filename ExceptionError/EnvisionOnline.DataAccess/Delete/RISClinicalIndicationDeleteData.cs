using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class RISClinicalIndicationDeleteData : DataAccessBase
    {
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public RISClinicalIndicationDeleteData()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATION_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@CI_ID",RIS_CLINICALINDICATION.CI_ID),
                                        Parameter("@EMP_ID",RIS_CLINICALINDICATION.EMP_ID),
                                        Parameter("@ORG_ID",RIS_CLINICALINDICATION.ORG_ID)
                                     };
            return parameters;
        }
    }
}

