using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Select
{
        public class ONLWorklistSelectData : DataAccessBase
    {
        public ONL_WORKLIST ONL_WORKLIST { get; set; }
        public ONLWorklistSelectData()
        {
            ONL_WORKLIST = new ONL_WORKLIST();
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            DataTable dtData = new DataTable();
            DataTable dtOrder = new DataTable();
            DataTable dtSchedule = new DataTable();
            DataTable dtXrayreq = new DataTable();

            StoredProcedureName = StoredProcedure.Prc_ONL_Worklist_Select_ORDER;
            //StoredProcedureName = StoredProcedure.Prc_ONL_Worklist_Select_ORDER2;
            ParameterList = buildParameter();
            dtOrder = ExecuteDataTable();//ExecuteDataSet();
            dtData = dtOrder.Clone();
            dtData.AcceptChanges();
            foreach (DataRow row in dtOrder.Rows)
                dtData.ImportRow(row);
            dtData.AcceptChanges();

            ParameterList = buildParameter();
            StoredProcedureName = StoredProcedure.Prc_ONL_Worklist_Select_SCHEUDLE; 
            //StoredProcedureName = StoredProcedure.Prc_ONL_Worklist_Select_SCHEUDLE2;
            dtSchedule = ExecuteDataTable();//ExecuteDataSet();

            dtData.AcceptChanges();
            foreach (DataRow row in dtSchedule.Rows)
                dtData.ImportRow(row);
            dtData.AcceptChanges();

            StoredProcedureName = StoredProcedure.Prc_ONL_Worklist_Select_XRAY;
            //StoredProcedureName = StoredProcedure.Prc_ONL_Worklist_Select_XRAY2;
            ParameterList = buildParameter();
            dtXrayreq = ExecuteDataTable();//ExecuteDataSet();
            dtData.AcceptChanges();
            foreach (DataRow row in dtXrayreq.Rows)
                dtData.ImportRow(row);
            dtData.AcceptChanges();

            ds.Tables.Add(dtData.Copy());
            return ds;
        }

        private DbParameter[] buildParameter()
        {
            DbParameter param1 = Parameter("@FROM_DATE", ONL_WORKLIST.FromDate);
            param1.Value = ONL_WORKLIST.FromDate == DateTime.MinValue ? (object)DBNull.Value : ONL_WORKLIST.FromDate;
            DbParameter param2 = Parameter("@TO_DATE", ONL_WORKLIST.ToDate);
            param2.Value = ONL_WORKLIST.ToDate == DateTime.MinValue ? (object)DBNull.Value : ONL_WORKLIST.ToDate;

            DbParameter[] parameters ={		
                                            Parameter( "@MODE", ONL_WORKLIST.MODE ) ,
                                            Parameter( "@HN", ONL_WORKLIST.HN ) ,
				                            Parameter( "@UNIT_ID", ONL_WORKLIST.UNIT_ID ) ,
                                            param1,
                                            param2,
                                            Parameter( "@UNIT_ALIAS", ONL_WORKLIST.UNIT_ALIAS ) 

			};
            return parameters;
        }
    }
}

