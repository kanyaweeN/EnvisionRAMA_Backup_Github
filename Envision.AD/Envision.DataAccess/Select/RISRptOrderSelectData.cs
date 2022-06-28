using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISRptOrderSelectData : DataAccessBase
    {
        private string fromDate;
        private string toDate;
        private string specialClinic;

        public RISRptOrderSelectData(String FromDate, String ToDate, String SpecialClinic)
        {
            fromDate = FromDate;
            toDate = ToDate;
            specialClinic = SpecialClinic;
            StoredProcedureName = StoredProcedure.Prc_RIS_RptOrder;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(fromDate, toDate, specialClinic);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(string FromDate, string ToDate, string SpecialClinic)
        {
            DbParameter[] parameters ={			
                                            Parameter( "@FromDate", fromDate ) ,
				                            Parameter( "@ToDate", toDate ),
                                            Parameter( "@SpecialClinic", specialClinic )
			};
            return parameters;
        }
    }
}
