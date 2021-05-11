//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    30/01/2552 03:44:19
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
	public class GBLHospitalSelectData : DataAccessBase 
	{
		private GBLHospital	_gblhospital;
		private GBLHospitalSelectDataParameters param;
		public  GBLHospitalSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_GBL_HOSPITAL_SelectAll.ToString();
		}
		public  GBLHospital	GBLHospital
		{
			get{return _gblhospital;}
			set{_gblhospital=value;}
		}
		public DataSet GetData()
		{
			param = new GBLHospitalSelectDataParameters(GBLHospital);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
        public DataSet GetDataAll() {
            StoredProcedureName = StoredProcedure.Name.Prc_GBL_HOSPITAL_SelectAll.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString);
            return ds;
        }
        public DataSet GetMappingHosID() {
            StoredProcedureName = StoredProcedure.Name.Prc_HR_EMP_SelectDoctorMapping.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@HOS_ID", GBLHospital.HOS_ID) };
            DataSet ds = dbhelper.Run(base.ConnectionString,param);
            return ds;
        }
	}
	public class GBLHospitalSelectDataParameters 
	{
		private GBLHospital _gblhospital;
		private SqlParameter[] _parameters;
		public GBLHospitalSelectDataParameters(GBLHospital gblhospital)
		{
			GBLHospital=gblhospital;
			Build();
		}
		public  GBLHospital	GBLHospital
		{
			get{return _gblhospital;}
			set{_gblhospital=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@HOS_ID",GBLHospital.HOS_ID)
//,new SqlParameter("@HOS_UID",GBLHospital.HOS_UID)
//,new SqlParameter("@HOS_NAME",GBLHospital.HOS_NAME)
//,new SqlParameter("@HOS_NAME_ALIAS",GBLHospital.HOS_NAME_ALIAS)
//,new SqlParameter("@PHONE_NO",GBLHospital.PHONE_NO)
			
//,new SqlParameter("@DESCR",GBLHospital.DESCR)
//,new SqlParameter("@CREATED_BY",GBLHospital.CREATED_BY)
//,new SqlParameter("@CREATED_ON",GBLHospital.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",GBLHospital.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",GBLHospital.LAST_MODIFIED_ON)
			
//,new SqlParameter("@ORG_ID",GBLHospital.ORG_ID)
			};
			_parameters=parameters;
		}
	}
}

