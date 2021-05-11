//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:26
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISLoadmediaSelectData : DataAccessBase 
	{
		private RISLoadmedia	_risloadmedia;
		private RISLoadmediaSelectDataParameters param;
		public  RISLoadmediaSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_LOADMEDIA_Select.ToString();
		}
		public  RISLoadmedia	RISLoadmedia
		{
			get{return _risloadmedia;}
			set{_risloadmedia=value;}
		}
		public DataSet GetData()
		{
			param = new RISLoadmediaSelectDataParameters(RISLoadmedia);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISLoadmediaSelectDataParameters 
	{
		private RISLoadmedia _risloadmedia;
		private SqlParameter[] _parameters;
		public RISLoadmediaSelectDataParameters(RISLoadmedia risloadmedia)
		{
			RISLoadmedia=risloadmedia;
			Build();
		}
		public  RISLoadmedia	RISLoadmedia
		{
			get{return _risloadmedia;}
			set{_risloadmedia=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter From_date = new SqlParameter();
            From_date.ParameterName = "@FROM_DATE";
            if (RISLoadmedia.FROM_DATE == DateTime.MinValue)
            {
                From_date.Value = DBNull.Value;
            }
            else
            {
                From_date.Value = RISLoadmedia.FROM_DATE;
            }

            SqlParameter To_date = new SqlParameter();
            To_date.ParameterName = "@TO_DATE";
            if (RISLoadmedia.TO_DATE == DateTime.MinValue)
            {
                To_date.Value = DBNull.Value;
            }
            else
            {
                To_date.Value = RISLoadmedia.TO_DATE;
            }
			SqlParameter[] parameters ={			
new SqlParameter("@LOAD_ID",RISLoadmedia.LOAD_ID)
,From_date
,To_date
,new SqlParameter("@selectcase",RISLoadmedia.SELECTCASE)
,new SqlParameter("@empid",RISLoadmedia.EMP_ID)
,new SqlParameter("@accession",RISLoadmedia.ACCESSION_NO)
			};
			_parameters=parameters;
		}
	}
}

