using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RISReleasemediaSelectDataNew : DataAccessBase
    {
        public RIS_RELEASEMEDIA RIS_RELEASEMEDIA { get; set; }
        public RISReleasemediaSelectDataNew()
		{
            RIS_RELEASEMEDIA = new RIS_RELEASEMEDIA();
            StoredProcedureName = StoredProcedure.Prc_RIS_RELEASEMEDIA_SelectNew;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataSet GetData_History()
        {
            DataSet ds = new DataSet();
            ParameterList = new DbParameter[] {
                Parameter("@HN",RIS_RELEASEMEDIA.HN)
            };
            StoredProcedureName = StoredProcedure.Prc_RIS_RELEASEMEDIA_Select_History;
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
                 Parameter("@selectcase",RIS_RELEASEMEDIA.SELECTCASE)
                ,Parameter("@ReleaseID",RIS_RELEASEMEDIA.RELEASE_ID)
                ,Parameter("@HN",RIS_RELEASEMEDIA.HN)
                ,Parameter("@ACCESSION",RIS_RELEASEMEDIA.ACCESSION_NO)
			};
            return parameters;
        }
	}
}
