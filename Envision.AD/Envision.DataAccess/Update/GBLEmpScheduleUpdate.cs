using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Update
{
    public class GBLEmpScheduleUpdate : DataAccessBase
    {
        public GBL_EMPSCHEDULE GBL_EMPSCHEDULE { get; set; }

        public GBLEmpScheduleUpdate() {
            StoredProcedureName = StoredProcedure.GBLEmpSchedule_Update;
            GBL_EMPSCHEDULE = new GBL_EMPSCHEDULE();
        }

        public void Update() {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                 Parameter("@SCHEDULE_ID",GBL_EMPSCHEDULE.SCHEDULE_ID)
                ,Parameter("@EMP_ID",GBL_EMPSCHEDULE.EMP_ID)
                ,Parameter("@ALLDAY",GBL_EMPSCHEDULE.ALLDAY)
                ,Parameter("@SUBJECT",GBL_EMPSCHEDULE.SUBJECT)
                ,Parameter("@STARTDATETIME",GBL_EMPSCHEDULE.STARTDATETIME)
                ,Parameter("@ENDDATETIME",GBL_EMPSCHEDULE.ENDDATETIME)
                ,Parameter("@STATUS",GBL_EMPSCHEDULE.STATUS)
                ,Parameter("@LABEL",GBL_EMPSCHEDULE.LABEL)
                ,Parameter("@LOCATION",GBL_EMPSCHEDULE.LOCATION)
                ,Parameter("@TYPE",GBL_EMPSCHEDULE.EVENTTYPE)
                ,Parameter("@DESCRIPTION",GBL_EMPSCHEDULE.DESCRIPTION)
                ,Parameter("@RECURRENCEINFO",GBL_EMPSCHEDULE.RECURRENCEINFO)
                ,Parameter("@REMINDERINFO",GBL_EMPSCHEDULE.REMINDERINFO)
                ,Parameter("@ORG_ID",GBL_EMPSCHEDULE.ORG_ID)
                ,Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID)
            };
            return parameters;
        }
    }
}
