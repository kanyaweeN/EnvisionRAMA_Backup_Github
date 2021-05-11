//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    09/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISScheduledtlSelectData : DataAccessBase
    {
        private RISScheduledtl _risscheduledtl;
        private RISScheduledtlInsertDataParameters _risscheduledtlinsertdataparameters;
        private DateTime dtFrom, dtTo;
        private int scheduleID;

        public RISScheduledtlSelectData(DateTime dtFrom, DateTime dtTo)
        {
            this.dtFrom = dtFrom;
            this.dtTo = dtTo;
            this.scheduleID = 0;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_Scheduledtl_Select.ToString();
            _risscheduledtl = new RISScheduledtl();
            ;
        }
        public RISScheduledtlSelectData(int scheduleID)
        {
            this.dtFrom = DateTime.MinValue;
            this.dtTo = DateTime.MinValue;
            this.scheduleID = scheduleID;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_Scheduledtl_SelectBySCHEDULE_ID.ToString();
            _risscheduledtl = new RISScheduledtl();
        }

        public RISScheduledtl RISScheduledtl
        {
            get { return _risscheduledtl; }
            set { _risscheduledtl = value; }
        }

        public DataSet GetData()
        {
            _risscheduledtlinsertdataparameters = null;// new RISScheduledtlInsertDataParameters(RISScheduledtl, dtFrom, dtTo);
            if (scheduleID == 0)
                _risscheduledtlinsertdataparameters = new RISScheduledtlInsertDataParameters(RISScheduledtl, dtFrom, dtTo);
            else
                _risscheduledtlinsertdataparameters = new RISScheduledtlInsertDataParameters(scheduleID);

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, _risscheduledtlinsertdataparameters.Parameters);
            return ds;
        }

    }
    public class RISScheduledtlInsertDataParameters
    {
        private RISScheduledtl _risscheduledtl;
        private SqlParameter[] _parameters;
        private DateTime dtFrom, dtTo;
        private int scheduleID;

        public RISScheduledtlInsertDataParameters(RISScheduledtl risscheduledtl, DateTime dtFrom, DateTime dtTo)
        {
            RISScheduledtl = risscheduledtl;
            this.dtFrom = dtFrom;
            this.dtTo = dtTo;
            this.scheduleID = 0;
            Build();
        }
        public RISScheduledtlInsertDataParameters(int scheduleID)
        {
            _risscheduledtl = new RISScheduledtl();
            this.scheduleID = scheduleID;
            Build_ScheduleID();
        }

        public RISScheduledtl RISScheduledtl
        {
            get { return _risscheduledtl; }
            set { _risscheduledtl = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build()
        {
            //SqlParameter[] parameters ={new SqlParameter("@SCHEDULE_ID",RISScheduledtl.SCHEDULE_ID),new SqlParameter("@EXAM_ID",RISScheduledtl.EXAM_ID),new SqlParameter("@MODALITY_ID",RISScheduledtl.MODALITY_ID),new SqlParameter("@APPOINT_DT",RISScheduledtl.APPOINT_DT),new SqlParameter("@QTY",RISScheduledtl.QTY)
            //,new SqlParameter("@COMMENTS",RISScheduledtl.COMMENTS),new SqlParameter("@SPECIAL_CLINIC",RISScheduledtl.SPECIAL_CLINIC),new SqlParameter("@ORG_ID",RISScheduledtl.ORG_ID),new SqlParameter("@CREATED_BY",RISScheduledtl.CREATED_BY),new SqlParameter("@CREATED_ON",RISScheduledtl.CREATED_ON)
            //,new SqlParameter("@LAST_MODIFIED_BY",RISScheduledtl.LAST_MODIFIED_BY),new SqlParameter("@LAST_MODIFIED_ON",RISScheduledtl.LAST_MODIFIED_ON)};
            SqlParameter[] parameters ={ new SqlParameter("@DateFrom", dtFrom), new SqlParameter("@DateTo", dtTo) };
            Parameters = parameters;
        }
        public void Build_ScheduleID()
        {
            SqlParameter[] parameters ={ new SqlParameter("@SCHEDULE_ID", scheduleID) };
            Parameters = parameters;
        }
    }
}


