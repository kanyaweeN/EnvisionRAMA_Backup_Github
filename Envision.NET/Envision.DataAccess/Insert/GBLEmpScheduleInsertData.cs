using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class GBLEmpScheduleInsertData : DataAccessBase 
    {
        public GBL_EMPSCHEDULE GBL_EMPSCHEDULE { get; set; }

        public GBLEmpScheduleInsertData()
        {
            GBL_EMPSCHEDULE = new GBL_EMPSCHEDULE();
            StoredProcedureName = StoredProcedure.GBLEmpSchedule_Insert;
        }
        public bool Add()
        {
            ParameterList = buildParameter();
            //ExecuteNonQuery();
            DataTable dtt = ExecuteDataTable();
            if (dtt != null)
                if (dtt.Rows.Count > 0)
                    GBL_EMPSCHEDULE.SCHEDULE_ID = Convert.ToInt32(dtt.Rows[0][0].ToString());

            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@EMP_ID",GBL_EMPSCHEDULE.EMP_ID)
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
                ,Parameter("@CREATED_BY",new GBLEnvVariable().UserID)
                ,Parameter("@SCHEDULE_ID_PARENT",GBL_EMPSCHEDULE.SCHEDULE_ID_PARENT)
            };
            return parameters;
        }
    }
}
