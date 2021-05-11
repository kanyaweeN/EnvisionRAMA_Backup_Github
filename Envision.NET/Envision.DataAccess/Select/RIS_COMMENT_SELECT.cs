using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RIS_COMMENT_SELECT : DataAccessBase
    {
        public RIS_COMMENTSONPATIENT CParameter { get; set; }
        public RIS_COMMENT_SELECT()
        {
            
        }

        public DataSet GetCommentData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTONPATIENT_SELECT;
            DataSet ds = new DataSet();
            ParameterList = BuildCommentDataParameters();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetContactListData(int OrgId)
        {
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_GetContactList;
            DataSet ds = new DataSet();
            ParameterList = BuildContactListDataParameters(OrgId);
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetOrderByPatientData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_GetOrderByPatient;
            DataSet ds = new DataSet();
            ParameterList = BuildOrderByPatientDataParameters();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataTable GetCommentDetail()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTONPATIENTDTL_SELECT;
            ParameterList = BuildCommentDetailsParameters();
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
        }

        public DbParameter[] BuildCommentDataParameters()
        {
            DbParameter[] parameters = { 
                                        Parameter("@HN", CParameter.HN),
                                        Parameter("@EMP_ID", CParameter.EMP_ID),
                                        Parameter("@MODE", CParameter.MODE),
                                        Parameter("@COMMENT_ID", CParameter.COMMENT_ID),
                                        Parameter("@ORDER_ID", CParameter.ORDER_ID),
                                        Parameter("@SCHEDULE_ID", CParameter.SCHEDULE_ID),
                                        Parameter("@EXAM_ID", CParameter.EXAM_ID)
                                       };
            return parameters;
        }

        public DbParameter[] BuildContactListDataParameters(int OrgId)
        {
            DbParameter[] parameters = { 
                                        Parameter("@ORG_ID", OrgId),
                                       };
            return parameters;
        }

        public DbParameter[] BuildOrderByPatientDataParameters()
        {
            DbParameter[] parameters = { 
                                        Parameter("@HN", CParameter.HN),
                                       };
            return parameters;
        }
         public DbParameter[] BuildCommentDetailsParameters()
        {
            DbParameter[] parameters = { 
                                        Parameter("@COMMENT_ID", CParameter.COMMENT_ID),
                                       };
            return parameters;
        }
    
    }
}
