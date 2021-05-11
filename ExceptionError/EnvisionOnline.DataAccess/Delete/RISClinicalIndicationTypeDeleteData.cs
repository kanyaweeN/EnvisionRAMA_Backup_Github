﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class RISClinicalIndicationTypeDeleteData: DataAccessBase
    {
        public RIS_CLINICALINDICATIONTYPE RIS_CLINICALINDICATIONTYPE { get; set; }

        public RISClinicalIndicationTypeDeleteData()
        {
            RIS_CLINICALINDICATIONTYPE = new RIS_CLINICALINDICATIONTYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONTYPE_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@CI_TYPE_ID",RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID),
                                        Parameter("@EMP_ID",RIS_CLINICALINDICATIONTYPE.EMP_ID),
                                        Parameter("@ORG_ID",RIS_CLINICALINDICATIONTYPE.ORG_ID)
                                     };
            return parameters;
        }
    }
}

