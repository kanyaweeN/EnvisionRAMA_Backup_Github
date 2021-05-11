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

namespace RIS.DataAccess.Delete
{
	public class GBLHospitalDeleteData : DataAccessBase 
	{
		private GBLHospital	_gblhospital;
		private GBLHospitalDeleteDataParameters param;
		public  GBLHospitalDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_GBL_HOSPITAL_Delete.ToString();
		}
		public  GBLHospital	GBLHospital
		{
			get{return _gblhospital;}
			set{_gblhospital=value;}
		}
		public bool Delete()
		{
			param= new GBLHospitalDeleteDataParameters(GBLHospital);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
        public bool DeleteMapping(int HosID) {

            StoredProcedureName = StoredProcedure.Name.Prc_GBL_HOSPITAL_DeleteMapping.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@HOSID", HosID) };
            object id = dbhelper.RunScalar(base.ConnectionString, param);
            return true;
        }
	}
	public class GBLHospitalDeleteDataParameters 
	{
		private GBLHospital _gblhospital;
		private SqlParameter[] _parameters;
		public GBLHospitalDeleteDataParameters(GBLHospital gblhospital)
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
                new SqlParameter("@HOS_ID",GBLHospital.HOS_ID)
			};
			_parameters = parameters;
		}
	}
}

