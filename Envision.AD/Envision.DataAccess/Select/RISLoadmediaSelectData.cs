using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISLoadmediaSelectData : DataAccessBase 
	{
        public RIS_LOADMEDIA RIS_LOADMEDIA;
		public  RISLoadmediaSelectData()
		{
            RIS_LOADMEDIA = new RIS_LOADMEDIA();
			StoredProcedureName = StoredProcedure.Prc_RIS_LOADMEDIA_Select;
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
            DbParameter From_date = Parameter();
            From_date.ParameterName = "@FROM_DATE";
            if (RIS_LOADMEDIA.FROM_DATE == DateTime.MinValue)
            {
                From_date.Value = DBNull.Value;
            }
            else
            {
                From_date.Value = RIS_LOADMEDIA.FROM_DATE;
            }

            DbParameter To_date = Parameter();
            To_date.ParameterName = "@TO_DATE";
            if (RIS_LOADMEDIA.TO_DATE == DateTime.MinValue)
            {
                To_date.Value = DBNull.Value;
            }
            else
            {
                To_date.Value = RIS_LOADMEDIA.TO_DATE;
            }

            DbParameter[] parameters ={			
                Parameter("@LOAD_ID",RIS_LOADMEDIA.LOAD_ID)
                ,From_date
                ,To_date
                ,Parameter("@selectcase",RIS_LOADMEDIA.SELECTCASE)
                ,Parameter("@empid",RIS_LOADMEDIA.EMP_ID)
                ,Parameter("@accession",RIS_LOADMEDIA.ACCESSION_NO)
			};
            return parameters;
        }
	}
}

