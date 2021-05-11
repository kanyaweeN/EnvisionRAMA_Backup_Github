using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class RISClinicalIndicationFavoriteDeleteData : DataAccessBase
    {
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public RISClinicalIndicationFavoriteDeleteData()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONFAVORITES_Delete;
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

