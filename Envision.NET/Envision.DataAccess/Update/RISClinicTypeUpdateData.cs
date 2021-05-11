using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RISClinicTypeUpdateData: DataAccessBase
    {
        public RIS_CLINICTYPE RIS_CLINICTYPE { get; set; }
        public RISClinicTypeUpdateData()
        {
            RIS_CLINICTYPE = new RIS_CLINICTYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICTYPE_UpdateByAccession;
        }

        public void UpdateByAccession(string accession, int clinic_type, int last_modified_by)
        {
            ParameterList = buildParameterByAccession(accession, clinic_type, last_modified_by);
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterByAccession(string accession,int clinic_type,int last_modified_by)
        {
            DbParameter[] parameters ={
				Parameter( "@ACCESSION_NO"	, accession ) ,
				Parameter( "@CLINIC_TYPE"        , clinic_type ) ,
                Parameter( "@LAST_MODIFIED_BY"        , last_modified_by ) ,
                                      };
            return parameters;
        }
    }
}