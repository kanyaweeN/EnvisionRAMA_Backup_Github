using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISScheduledtlSelectData : DataAccessBase
    {
        public RIS_SCHEDULEDTL RIS_SCHEDULEDTL { get; set; }
        private DateTime dtFrom, dtTo;
        private int scheduleID;
        private int Case;

        public RISScheduledtlSelectData(DateTime dtFrom, DateTime dtTo,int SCHEDULE_ID)
        {
            this.dtFrom = dtFrom;
            this.dtTo = dtTo;
            this.Case = 0;
            this.scheduleID = SCHEDULE_ID;
            StoredProcedureName = StoredProcedure.Prc_RIS_Scheduledtl_Select;
            RIS_SCHEDULEDTL = new RIS_SCHEDULEDTL();
        }
        public RISScheduledtlSelectData(int scheduleID)
        {
            RIS_SCHEDULEDTL = new RIS_SCHEDULEDTL();
            this.dtFrom = DateTime.MinValue;
            this.dtTo = DateTime.MinValue;
            this.Case = scheduleID;
            this.scheduleID = scheduleID;
            StoredProcedureName = StoredProcedure.Prc_RIS_Scheduledtl_SelectBySCHEDULE_ID;
            
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
           
            if (Case == 0)
                  ParameterList = buildParameter(dtFrom, dtTo);
            else
                   ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(DateTime dtFrom, DateTime dtTo)
        {
            DbParameter[] parameters ={			
                        Parameter("@DateFrom", dtFrom), 
                        Parameter("@DateTo", dtTo) ,
                        Parameter("@SCHEDULE_ID", scheduleID) 
			};
            return parameters;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                    Parameter("@SCHEDULE_ID", scheduleID)
			};
            return parameters;
        }
    }
}


