using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class RIS_SCHEDULEDTLDeleteData : DataAccessBase
    {
        public RIS_SCHEDULEDTL RIS_SCHEDULEDTL { get; set; }
        public RIS_SCHEDULEDTLDeleteData() {
            RIS_SCHEDULEDTL = new RIS_SCHEDULEDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULEDTL_Delete;
        }
        public bool Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
        }
        public bool DeleteCNMI()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery2();
            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@SCHEDULE_ID"  ,RIS_SCHEDULEDTL.SCHEDULE_ID) ,
                                           Parameter("@EXAM_ID"  ,RIS_SCHEDULEDTL.EXAM_ID) ,
                                           Parameter("@REASON"  ,RIS_SCHEDULEDTL.REASON) ,
                                           Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULEDTL.LAST_MODIFIED_BY)
                                       };
            return parameters;
        }
    }
}
