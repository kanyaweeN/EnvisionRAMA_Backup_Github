using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class RISOrderClinicalindicationInsert: DataAccessBase
    {
        
        public RIS_ORDERCLINICALINDICATION RIS_ORDERCLINICALINDICATION { get; set; }

        public RISOrderClinicalindicationInsert()
        {
            RIS_ORDERCLINICALINDICATION = new RIS_ORDERCLINICALINDICATION();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERCLINICALINDICATION_Insert;
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
            if (RIS_ORDERCLINICALINDICATION.SCHEDULE_ID == null)
                paramSchedule.Value = DBNull.Value;
            else if(RIS_ORDERCLINICALINDICATION.SCHEDULE_ID == 0)
                paramSchedule.Value = DBNull.Value;
            else
                paramSchedule.Value = RIS_ORDERCLINICALINDICATION.SCHEDULE_ID;

            DbParameter[] parameters =
		    {
				Parameter( "@ORDER_ID"	                , RIS_ORDERCLINICALINDICATION.ORDER_ID ) ,
                 paramSchedule,
                Parameter( "@CI_ID"	                , RIS_ORDERCLINICALINDICATION.CI_ID ) ,
                Parameter( "@ORG_ID"	                , RIS_ORDERCLINICALINDICATION.ORG_ID ) ,
                Parameter( "@CREATED_BY"	                , RIS_ORDERCLINICALINDICATION.CREATED_BY ) ,
                Parameter( "@IS_REQONLINE"	                , RIS_ORDERCLINICALINDICATION.IS_REQONLINE ) ,
			};
            return parameters;
        }
    }
}
