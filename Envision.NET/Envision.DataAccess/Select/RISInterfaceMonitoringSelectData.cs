using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISInterfaceMonitoringSelectData: DataAccessBase
	{
		public RIS_HL7IELOG RIS_HL7IELOG { get; set; }

        public RISInterfaceMonitoringSelectData() { RIS_HL7IELOG = new RIS_HL7IELOG(); }

		public DataSet GetData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_INTERFACEMONITORING_Select;
            ParameterList = buildParameter();
			return ExecuteDataSet();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter pDateFrom = Parameter();
            pDateFrom.ParameterName = "@DATE_FROM";
            if (RIS_HL7IELOG.DATE_FROM == null)
                pDateFrom.Value = DBNull.Value;
            else
                pDateFrom.Value = RIS_HL7IELOG.DATE_FROM == DateTime.MinValue ? (object)DBNull.Value : RIS_HL7IELOG.DATE_FROM;
            DbParameter pDateTo = Parameter();
            pDateTo.ParameterName = "@DATE_TO";
            if (RIS_HL7IELOG.DATE_TO == null)
                pDateTo.Value = DBNull.Value;
            else
                pDateTo.Value = RIS_HL7IELOG.DATE_TO == DateTime.MinValue ? (object)DBNull.Value : RIS_HL7IELOG.DATE_TO;


            DbParameter[] parameters ={ 
                                                Parameter("@MODE"     ,   RIS_HL7IELOG.MODE),
                                                Parameter("@ACCESSION_NO"     ,   RIS_HL7IELOG.ACCESSION_NO),
                                                Parameter("@HN"     ,   RIS_HL7IELOG.HN),
                                                pDateFrom,
                                                pDateTo,
                                       };
            return parameters;
        }
	}
}
