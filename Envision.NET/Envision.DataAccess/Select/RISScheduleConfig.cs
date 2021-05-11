using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public  class RISScheduleConfig : DataAccessBase 
    {
        public RIS_SCHEDULECONFIG RIS_SCHEDULECONFIG { get; set; }

        public RISScheduleConfig() {
            RIS_SCHEDULECONFIG = new RIS_SCHEDULECONFIG();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULECONFIG_Select;
        }
        public DataTable GetData() {
            return ExecuteDataTable();
        }
    }
}
