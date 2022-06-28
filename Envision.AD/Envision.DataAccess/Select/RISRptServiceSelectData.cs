using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISRptServiceSelectData : DataAccessBase
    {
        private string roomID;
        private string fromDate;
        private string toDate;
        private string examType;

        public RISRptServiceSelectData(string RoomID, String FromDate, String ToDate, String ExamType)
        {
            roomID = RoomID;
            fromDate = FromDate;
            toDate = ToDate;
            examType = ExamType;
            StoredProcedureName = StoredProcedure.Prc_RIS_RptService;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(roomID, fromDate, toDate, examType);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(string RoomID, string FromDate, string ToDate, string ExamType)
        {
            DbParameter[] parameters ={			
                                            Parameter( "@FromDate", FromDate ) ,
				                            Parameter( "@ToDate", ToDate ),
                                            Parameter( "@RoomID", RoomID), 
                                            Parameter( "@examType", ExamType )
			};
            return parameters;
        }
    }
}
