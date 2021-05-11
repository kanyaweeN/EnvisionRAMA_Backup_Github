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
            //StoredProcedureName = StoredProcedure.Prc_ONL_Worklist_Select;
            //StoredProcedureName = StoredProcedure.Prc_ONL_Worklist_Select_test;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable dtt = new DataTable();
            DataTable dttt = new DataTable();
            DataTable dtttt = new DataTable();

            StoredProcedureName = StoredProcedure.Prc_ONL_Worklist_Select_ORDER;
            ParameterList = buildParameter();
            dtt = ExecuteDataTable();//ExecuteDataSet();
            dt = dtt.Clone();
            //dt.Merge(dtt);
            dt.AcceptChanges();
            foreach (DataRow row in dtt.Rows)
                dt.ImportRow(row);
            dt.AcceptChanges();

            ParameterList = buildParameter();
            StoredProcedureName = StoredProcedure.Prc_ONL_Worklist_Select_SCHEUDLE;
            dttt = ExecuteDataTable();//ExecuteDataSet();

            dt.AcceptChanges();
            foreach (DataRow row in dttt.Rows)
                dt.ImportRow(row);
            dt.AcceptChanges();

            StoredProcedureName = StoredProcedure.Prc_ONL_Worklist_Select_XRAY;
            ParameterList = buildParameter();
            dtttt = ExecuteDataTable();//ExecuteDataSet();
            dt.AcceptChanges();
            foreach (DataRow row in dtttt.Rows)
                dt.ImportRow(row);
            dt.AcceptChanges();

            ds.Tables.Add(dt.Copy());
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

