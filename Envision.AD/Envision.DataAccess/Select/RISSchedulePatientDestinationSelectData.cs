using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISSchedulePatientDestinationSelectData : DataAccessBase
    {
        public RIS_SCHEDULEDEFAULTDESTINATION RIS_SCHEDULEDEFAULTDESTINATION { get; set; }
        public RISSchedulePatientDestinationSelectData() {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULEDEFAULTDESTINATION_SelectByEmpId;
            RIS_SCHEDULEDEFAULTDESTINATION = new RIS_SCHEDULEDEFAULTDESTINATION();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@EMP_ID",RIS_SCHEDULEDEFAULTDESTINATION.EMP_ID)

                                       };
            return parameters;
        }
        public DataSet GetDestinationData(){
            ParameterList = buildParameter();
            DataSet dtt = ExecuteDataSet();
            return dtt;
        }
    }
}
