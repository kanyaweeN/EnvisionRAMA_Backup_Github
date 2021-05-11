using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionInterface.DataAccess.Select
{
    public class RISRamaAppointmentSelectData : DataAccessBase
    {
        public RISRamaAppointmentSelectData()
        {
        }
        public DataSet GetData(string hn)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.SCB_Appointment_Select_ByHN;

            DbParameter[] parameters = { Parameter("@HN", hn) };
            ParameterList = parameters;
            ds = ExecuteDataSet();

            return ds;
        }
        public DataSet GetDataByScheduleID(int schedule_id)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.SCB_Appointment_Select_ByAppointID;
            DbParameter[] parameters = { Parameter("@SCHEDULE_ID", schedule_id) };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet getDataByXrayreqID(int xrayreq_id)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.SCB_Appointment_Select_ByXrayReqID;
            DbParameter[] parameters = { Parameter("@ORDER_ID", xrayreq_id) };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
    }
}