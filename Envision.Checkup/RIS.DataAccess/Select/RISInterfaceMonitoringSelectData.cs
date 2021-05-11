using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Select
{
    public class RISInterfaceMonitoringSelectData : DataAccessBase
    {
        public RIS_HL7IELOG RIS_HL7IELOG { get; set; }

        public RISInterfaceMonitoringSelectData() { RIS_HL7IELOG = new RIS_HL7IELOG(); }

        public DataSet GetData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_INTERFACEMONITORING_Select.ToString();
            SqlParameter pDateFrom = new SqlParameter();
            pDateFrom.ParameterName = "@DATE_FROM";
            if (RIS_HL7IELOG.DATE_FROM == null)
                pDateFrom.Value = DBNull.Value;
            else
                pDateFrom.Value = RIS_HL7IELOG.DATE_FROM == DateTime.MinValue ? (object)DBNull.Value : RIS_HL7IELOG.DATE_FROM;
            SqlParameter pDateTo = new SqlParameter();
            pDateTo.ParameterName = "@DATE_TO";
            if (RIS_HL7IELOG.DATE_TO == null)
                pDateTo.Value = DBNull.Value;
            else
                pDateTo.Value = RIS_HL7IELOG.DATE_TO == DateTime.MinValue ? (object)DBNull.Value : RIS_HL7IELOG.DATE_TO;

            SqlParameter[] param = { 
                                   new SqlParameter("@MODE"     ,   RIS_HL7IELOG.MODE),
                                                new SqlParameter("@ACCESSION_NO"     ,   RIS_HL7IELOG.ACCESSION_NO),
                                                new SqlParameter("@HN"     ,   RIS_HL7IELOG.HN),
                                                pDateFrom,
                                                pDateTo,
                                   };
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            return dbhelper.Run(base.ConnectionString, param);
        }
    }
}
