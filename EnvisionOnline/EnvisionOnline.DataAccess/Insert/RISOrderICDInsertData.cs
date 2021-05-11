using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class RISOrderICDInsertData: DataAccessBase
    {
        public RIS_ORDERICD RIS_ORDERICD { get; set; }

        public RISOrderICDInsertData()
        {
            RIS_ORDERICD = new RIS_ORDERICD();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERICD_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter paramSchedule = Parameter();
            paramSchedule.ParameterName = "@SCHEDULE_ID";
            if (RIS_ORDERICD.SCHEDULE_ID == null)
                paramSchedule.Value = DBNull.Value;
            else if (RIS_ORDERICD.SCHEDULE_ID == 0)
                paramSchedule.Value = DBNull.Value;
            else
                paramSchedule.Value = RIS_ORDERICD.SCHEDULE_ID;

            
            DbParameter[] parameters =
		    {
				Parameter( "@ORDER_ID"	                , RIS_ORDERICD.ORDER_ID ) ,
                paramSchedule  ,
                Parameter( "@ICD_ID"	                , RIS_ORDERICD.ICD_ID ) ,
                Parameter( "@ORG_ID"	                , RIS_ORDERICD.ORG_ID ) ,
                Parameter( "@CREATED_BY"	                , RIS_ORDERICD.CREATED_BY ) ,
                Parameter( "@IS_REQONLINE"	                , RIS_ORDERICD.IS_REQONLINE ) ,
			};
            return parameters;
        }
    }
}
