using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISCommentSystemDtlSelectData : DataAccessBase
    {
        public RIS_COMMENTSYSTEMDTL RIS_COMMENTSYSTEMDTL { get; set; }
        public RISCommentSystemDtlSelectData()
        {
            RIS_COMMENTSYSTEMDTL = new RIS_COMMENTSYSTEMDTL();
        }
        
        public DataSet getEmpCommentedAllByOrder(string accession_no)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_SelectForCheckGroupByOrder;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@ACCESSION_NO"	        , accession_no ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet getEmpCommentedAllBySchedule(int schedule_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_SelectForCheckGroupBySchedule;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@SCHEDULE_ID"	        , schedule_id ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet getEmpCommentedAllByXrayreq(int xrayreq_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_SelectForCheckGroupXrayReq;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@XRAYREQ_ID"	        , xrayreq_id ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
