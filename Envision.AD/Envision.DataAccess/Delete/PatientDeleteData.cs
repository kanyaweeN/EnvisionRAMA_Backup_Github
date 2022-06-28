using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class PatientDeleteData : DataAccessBase
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }

        public PatientDeleteData()
        {
            RIS_PATSTATUS = new RIS_PATSTATUS();
            StoredProcedureName = StoredProcedure.PRC_RIS_SF04_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@STATUS_ID",RIS_PATSTATUS.STATUS_ID)
                                     };
            return parameters;
        }
    }
}
