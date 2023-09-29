using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISClinicsessionSelectData : DataAccessBase
    {
        public RIS_CLINICSESSION RIS_CLINICSESSION { get; set; }

        public RISClinicsessionSelectData()
        {
            RIS_CLINICSESSION = new RIS_CLINICSESSION();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICSESSION_Select;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataCNMI()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSetCNMI();
            return ds;
        }
        public DataSet getSessionTime(bool IsSetOnline)
        {
            if (IsSetOnline)
                StoredProcedureName = StoredProcedure.Prc_RIS_SESSIONTIMEONLINE_Select;
            else
                StoredProcedureName = StoredProcedure.Prc_RIS_SESSIONTIME_Select;
            DataSet ds = new DataSet();
            ParameterList = buildParameterSessionTime();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet getSessionTimeAll()
        {
                StoredProcedureName = StoredProcedure.Prc_RIS_SESSIONTIMEONLINE_SelectAll;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterSessionTime()
        {
            DbParameter[] parameters = { 
                                          Parameter("@SESSION_ID",RIS_CLINICSESSION.SESSION_ID),
                                       };
            return parameters;
        }
        public DataSet getSessionTimeChildren(int unit_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SESSIONTIMEUNIT_SelectChildren;
            DataSet ds = new DataSet();
            ParameterList = buildParameterSessionTimeChildren(unit_id);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterSessionTimeChildren(int unit_id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@UNIT_ID",unit_id),
                                       };
            return parameters;
        }
        public DataSet getScheduleCountInSession()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_COUNTINSESSIONTIME_Select;
            DataSet ds = new DataSet();
            ParameterList = buildParameterScheduleCountInSession();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterScheduleCountInSession()
        {
            DbParameter[] parameters = { 
                                          Parameter("@DATE_START",RIS_CLINICSESSION.START_TIME),
                                          Parameter("@DATE_END",RIS_CLINICSESSION.END_TIME),
                                          Parameter("@MODALITY_ID",RIS_CLINICSESSION.MODALITY_ID),
                                       };
            return parameters;
        }
        public DataSet GetScheduleSession()
        {

            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Session;
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@MODALITY_ID",RIS_CLINICSESSION.MODALITY_ID),
                                          Parameter("@WEEKDAY",RIS_CLINICSESSION.WEEKDAYS),
                                          Parameter("@ORG_ID",RIS_CLINICSESSION.ORG_ID),
                                       };
            return parameters;
        }
        public int getSessionIDByAppointDate(DateTime appointdate)
        {
            int _id = 0;
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICSESSION_SelectByAppointDate;
            DataSet ds = new DataSet();
            ParameterList = buildParameterSessionID(appointdate);
            ds = ExecuteDataSet();
            if(ds.Tables.Count>0)
                if(ds.Tables[0].Rows.Count>0)
                    _id = Convert.ToInt32(ds.Tables[0].Rows[0]["SESSION_ID"]);

            return _id;
        }
        private DbParameter[] buildParameterSessionID(DateTime appointDate)
        {
            DbParameter paramAppointDate = Parameter();
            paramAppointDate.ParameterName = "@AppointDate";
            if (appointDate == null)
                paramAppointDate.Value = DBNull.Value;
            else if (appointDate == DateTime.MinValue)
                paramAppointDate.Value = DBNull.Value;
            else
                paramAppointDate.Value = appointDate;

            DbParameter[] parameters = { 
                                          paramAppointDate
                                       };
            return parameters;
        }
        public int getSessionIDByAppointDate2(DateTime appointdate,int clinic_type_id)
        {
            int _id = 0;
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICSESSION_SelectByAppointDate2;
            DataSet ds = new DataSet();
            ParameterList = buildParameterSessionID2(appointdate,clinic_type_id);
            ds = ExecuteDataSet();
            if (ds.Tables.Count > 0)
                if (ds.Tables[0].Rows.Count > 0)
                    _id = Convert.ToInt32(ds.Tables[0].Rows[0]["SESSION_ID"]);

            return _id;
        }
        private DbParameter[] buildParameterSessionID2(DateTime appointDate, int clinic_type_id)
        {
            DbParameter paramAppointDate = Parameter();
            paramAppointDate.ParameterName = "@AppointDate";
            if (appointDate == null)
                paramAppointDate.Value = DBNull.Value;
            else if (appointDate == DateTime.MinValue)
                paramAppointDate.Value = DBNull.Value;
            else
                paramAppointDate.Value = appointDate;

            DbParameter[] parameters = { 
                                          paramAppointDate,
                                          Parameter("@CLINIC_TYPE_ID",clinic_type_id)
                                       };
            return parameters;
        }

        public DataSet getSessionWithUnit(int unit_id, int exam_id, char is_children)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SESSIONTIMEUNIT_Select2;
            DataSet ds = new DataSet();
            ParameterList = buildParameterSessionWithUnit(unit_id,exam_id,is_children);
            return ExecuteDataSet();
        }
        private DbParameter[] buildParameterSessionWithUnit(int unit_id, int exam_id, char is_children)
        {
            DbParameter[] parameters = { 
                                          Parameter("@UNIT_ID",unit_id),
                                          Parameter("@EXAM_ID",exam_id),
                                          Parameter("@IS_CHILDREN",is_children),
                                       };
            return parameters;
        }
        public DataSet getSessionByModality()
        {

            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICSESSION_SelectByModality;
            DataSet ds = new DataSet();
            ParameterList = buildParameterSessionByModality();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterSessionByModality()
        {
            DbParameter[] parameters = { 
                                          Parameter("@MODALITY_ID",RIS_CLINICSESSION.MODALITY_ID)
                                       };
            return parameters;
        }
    }
}
