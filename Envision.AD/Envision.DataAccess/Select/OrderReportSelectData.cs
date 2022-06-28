using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class OrderReportSelectData : DataAccessBase
    {
        public ReportParameters ReportParameters { get; set; }

        public OrderReportSelectData()
		{
            ReportParameters = new ReportParameters();
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_OrderReportAll;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                      Parameter("@FromDate",ReportParameters.FromDate)
                                                    , Parameter("@ToDate",ReportParameters.ToDate)
                                                    , Parameter("@MODALITY_ID",ReportParameters.ModalityId)
                                                    , Parameter("@UNIT_ID",ReportParameters.Unit_ID)
                                       };
            return parameters;
        }
	}
}
