using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISCommentSystemSelectData : DataAccessBase
    {
        public RIS_COMMENTSYSTEM RIS_COMMENTSYSTEM { get; set; }

        public RISCommentSystemSelectData()
        {
            RIS_COMMENTSYSTEM = new RIS_COMMENTSYSTEM();
        }
        public DataSet GetPatientData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_Select_PatientDetail;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@ACCESSION_NO"	        , RIS_COMMENTSYSTEM.ACCESSION_NO ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetPatientDataBySchedulId()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_SelectPatientBySchedule;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@SCHEDULE_ID"	        , RIS_COMMENTSYSTEM.SCHEDULE_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetPatientDataByXrayreqId()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_SelectPatientByXrayreq;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@XRAYREQ_ID"	        , RIS_COMMENTSYSTEM.XRAYREQ_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_Select;
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataForSchedule()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_SelectForSchedule;
            DataSet ds = new DataSet();
            ParameterList = buildParameterForSchedule();
            ds = ExecuteDataSet();
            return ds;
        }
        public bool CheckDataForSchedule(int schedule_id, string listExam)
        {
            bool flag = false;
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_CheckForSchedule;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@SCHEDULE_ID"	        , schedule_id ),
                                             Parameter( "@LIST_EXAM"	        , listExam ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            if (ds.Tables[0].Rows[0][0].ToString() == ds.Tables[1].Rows[0][0].ToString())
                flag = true;
            return flag;
        }
        public DataSet GetDataByScheduleID()
        {
            //StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_SelectByScheduleID;
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_SelectByScheduleID2;
            DataSet ds = new DataSet();
            ParameterList = buildParameterByScheduleID();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataForXrayreq()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_SelectForXrayreq;
            DataSet ds = new DataSet();
            ParameterList = buildParameterForXrayreq();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataTemplate()
        { 
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_SelectDataTemplate;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                             Parameter( "@ACCESSION_NO"	        , RIS_COMMENTSYSTEM.ACCESSION_NO ),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterForSchedule()
        {
            DbParameter[] parameters = { 
                                             Parameter( "@SCHEDULE_ID"	        , RIS_COMMENTSYSTEM.SCHEDULE_ID ),
                                             Parameter( "@EXAM_ID"	        , RIS_COMMENTSYSTEM.EXAM_ID ),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterByScheduleID()
        {
            DbParameter[] parameters = { 
                                             Parameter( "@SCHEDULE_ID"	        , RIS_COMMENTSYSTEM.SCHEDULE_ID ),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterForXrayreq()
        {
            DbParameter[] parameters = { 
                                             Parameter( "@XRAYREQ_ID"	        , RIS_COMMENTSYSTEM.XRAYREQ_ID ),
                                             Parameter( "@EXAM_ID"	        , RIS_COMMENTSYSTEM.EXAM_ID ),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterByOrderId()
        {
            DbParameter[] parameters = { 
                                             Parameter( "@ORDER_ID"	        , RIS_COMMENTSYSTEM.ORDER_ID ),
                                       };
            return parameters;
        }

        private DbParameter[] buildParameterByScheduleId()
        {
            DbParameter[] parameters = { 
                                             Parameter( "@SCHEDULE_ID"	        , RIS_COMMENTSYSTEM.SCHEDULE_ID ),
                                       };
            return parameters;
        }
    }
}

