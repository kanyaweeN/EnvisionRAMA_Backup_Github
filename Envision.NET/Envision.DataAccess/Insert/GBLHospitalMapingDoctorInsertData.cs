using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLHospitalMapingDoctorInsertData : DataAccessBase
    {
        public RIS_HOSPITAL_MAP_DOCTOR RIS_HOSPITAL_MAP_DOCTOR { get; set; }
        public GBLHospitalMapingDoctorInsertData()
		{
            RIS_HOSPITAL_MAP_DOCTOR = new RIS_HOSPITAL_MAP_DOCTOR();
			StoredProcedureName = StoredProcedure.Prc_GBL_HOSPITAL_Insert;
		}
        public bool Mapping() {

            ParameterList = buildParameterMapping();
            ExecuteNonQuery();
            return true;
        }
        private DbParameter[] buildParameterMapping()
        {
            DbParameter[] parameters ={
                Parameter("@HOS_ID",RIS_HOSPITAL_MAP_DOCTOR.HOS_ID)
                ,Parameter("@EMP_ID",RIS_HOSPITAL_MAP_DOCTOR.EMP_ID)
                ,Parameter("@ORG_ID",RIS_HOSPITAL_MAP_DOCTOR.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_HOSPITAL_MAP_DOCTOR.CREATED_BY)
            };
            return parameters;
        }
    }
}
