using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISReleasemediaSelectData : DataAccessBase 
	{
        public RIS_RELEASEMEDIA RIS_RELEASEMEDIA { get; set; }
		public  RISReleasemediaSelectData()
		{
            RIS_RELEASEMEDIA = new RIS_RELEASEMEDIA();
			StoredProcedureName = StoredProcedure.Prc_RIS_RELEASEMEDIA_Select;
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
            DbParameter datefrom = Parameter();
            datefrom.ParameterName = "@FromDate";
            if (RIS_RELEASEMEDIA.FROMDATE == DateTime.MinValue)
            {
                datefrom.Value = DBNull.Value;
            }
            else
            {
                datefrom.Value = RIS_RELEASEMEDIA.FROMDATE;
            }
            DbParameter todate = Parameter();
            todate.ParameterName = "@ToDate";
            if (RIS_RELEASEMEDIA.TODATE == DateTime.MinValue)
            {
                todate.Value = DBNull.Value;
            }
            else
            {
                todate.Value = RIS_RELEASEMEDIA.TODATE;
            }
            DbParameter[] parameters ={			
                Parameter("@RELEASE_ID",RIS_RELEASEMEDIA.RELEASE_ID)
                ,Parameter("@selectcase",RIS_RELEASEMEDIA.SELECTCASE)
                ,datefrom
                ,todate
                ,Parameter("@HN",RIS_RELEASEMEDIA.HN)
			};
            return parameters;
        }
	}
}

