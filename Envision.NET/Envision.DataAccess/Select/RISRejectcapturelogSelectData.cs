using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RISRejectcapturelogSelectData : DataAccessBase
    {
         DataSet ds;
         public RIS_REJECTCAPTURELOG RIS_REJECTCAPTURELOG { get; set; }
         public RISRejectcapturelogSelectData()
        {
            RIS_REJECTCAPTURELOG = new RIS_REJECTCAPTURELOG();
        }
        public DataTable SelectByAccessionNo()
        {
            ParameterList = buildParameteSelectByAccession();
            StoredProcedureName = StoredProcedure.Prc_RIS_REJECTCAPTURELOG_SelectByAccession;
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }
        private DbParameter[] buildParameteSelectByAccession()
        {
            DbParameter[] parameters = { 
                                          Parameter("@ACCESSION_NO",RIS_REJECTCAPTURELOG.ACCESSION_NO),
                                       };
            return parameters;
        }
        
    }
}
