using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISClinictypeSelectData : DataAccessBase 
	{
		private RISClinictype	_risclinictype;
		private RISClinictypeInsertDataParameters	_risclinictypeinsertdataparameters;
		public  RISClinictypeSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_CLINICTYPE_Select.ToString();
		}
		public  RISClinictype	RISClinictype
		{
			get{return _risclinictype;}
			set{_risclinictype=value;}
		}
		public DataSet GetData()
		{
            //_risclinictypeinsertdataparameters = new RISClinictypeInsertDataParameters(RISClinictype);
            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //DataSet ds = dbhelper.Run(base.ConnectionString,_risclinictypeinsertdataparameters.Parameters);
            //return ds;

            //_risclinictypeinsertdataparameters = new RISClinictypeInsertDataParameters(RISClinictype);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString);
            //DataSet ds = dbhelper.Run(base.ConnectionString, _risclinictypeinsertdataparameters.Parameters);
            return ds;
		}
	}
	public class RISClinictypeInsertDataParameters 
	{
		private RISClinictype _risclinictype;
		private SqlParameter[] _parameters;
		public RISClinictypeInsertDataParameters(RISClinictype risclinictype)
		{
			RISClinictype=risclinictype;
			Build();
		}
		public  RISClinictype	RISClinictype
		{
			get{return _risclinictype;}
			set{_risclinictype=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            //SqlParameter[] parameters ={new SqlParameter("@CLINIC_TYPE_ID",RISClinictype.CLINIC_TYPE_ID),new SqlParameter("@CLINIC_TYPE_UID",RISClinictype.CLINIC_TYPE_UID),new SqlParameter("@CLINIC_TYPE_TEXT",RISClinictype.CLINIC_TYPE_TEXT),new SqlParameter("@IS_DEFAULT",RISClinictype.IS_DEFAULT),new SqlParameter("@IS_ACTIVE",RISClinictype.IS_ACTIVE)
            //,new SqlParameter("@RATE_INCREASE",RISClinictype.RATE_INCREASE),new SqlParameter("@CREATED_BY",RISClinictype.CREATED_BY),new SqlParameter("@CREATED_ON",RISClinictype.CREATED_ON),new SqlParameter("@LAST_MODIFIED_BY",RISClinictype.LAST_MODIFIED_BY),new SqlParameter("@LAST_MODIFIED_ON",RISClinictype.LAST_MODIFIED_ON)
            //,new SqlParameter("@ORG_ID",RISClinictype.ORG_ID)};
            //Parameters = parameters;
		}
	}
}

