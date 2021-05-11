using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class RISClinicalIndicationWithUnitDeleteData: DataAccessBase
    {
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public RISClinicalIndicationWithUnitDeleteData()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONWITHUNIT_Delete;
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
                                        Parameter("@UNIT_ID",RIS_CLINICALINDICATION.UNIT_ID),
                                        Parameter("@ORG_ID",RIS_CLINICALINDICATION.ORG_ID)
                                     };
            return parameters;
        }
        public void DeleteAll()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONWITHUNIT_DeleteAll;
            ParameterList = buildParameterDeleteAll();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterDeleteAll()
        {
            DbParameter[] parameters ={
                                        Parameter("@UNIT_ID",RIS_CLINICALINDICATION.UNIT_ID),
                                        Parameter("@ORG_ID",RIS_CLINICALINDICATION.ORG_ID)
                                     };
            return parameters;
        }

    }
}