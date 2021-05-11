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

namespace RIS.DataAccess.Insert
{
	public class GBLHospitalInsertData : DataAccessBase 
	{
		private GBLHospital	_gblhospital;
		private GBLHospitalInsertDataParameters	param;
		public  GBLHospitalInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_GBL_HOSPITAL_Insert.ToString();
		}
		public  GBLHospital	GBLHospital
		{
			get{return _gblhospital;}
			set{_gblhospital=value;}
		}
		public bool Add()
		{
			param= new GBLHospitalInsertDataParameters(GBLHospital);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
        public bool Mapping() {
            GBLHospitalMappingInsertDataParameters param = new GBLHospitalMappingInsertDataParameters(GBLHospital);
            StoredProcedureName = StoredProcedure.Name.Prc_GBL_HOSPITAL_InsertMapping.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, param.Parameters);
            return true;
        }
	}
	public class GBLHospitalInsertDataParameters 
	{
		private GBLHospital _gblhospital;
		private SqlParameter[] _parameters;
		public GBLHospitalInsertDataParameters(GBLHospital gblhospital)
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
                new SqlParameter("@HOS_UID",GBLHospital.HOS_UID)
                ,new SqlParameter("@HOS_NAME",GBLHospital.HOS_NAME)
                ,new SqlParameter("@HOS_NAME_ALIAS",GBLHospital.HOS_NAME_ALIAS)
                ,new SqlParameter("@PHONE_NO",GBLHospital.PHONE_NO)
                ,new SqlParameter("@DESCR",GBLHospital.DESCR)
                ,new SqlParameter("@ORG_ID",GBLHospital.ORG_ID)
                ,new SqlParameter("@PERCENT_DISCOUNT",GBLHospital.PERCENT_DISCOUNT)
                ,new SqlParameter("@CREATED_BY",GBLHospital.CREATED_BY)
			};
			_parameters = parameters;
		}
	}
    public class GBLHospitalMappingInsertDataParameters { 
        private GBLHospital _gblhospital;
		private SqlParameter[] _parameters;
        public GBLHospitalMappingInsertDataParameters(GBLHospital gblhospital)
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
                ,new SqlParameter("@EMP_ID",GBLHospital.EMP_ID)
                ,new SqlParameter("@ORG_ID",GBLHospital.ORG_ID)
                ,new SqlParameter("@CREATED_BY",GBLHospital.CREATED_BY)
			};
			_parameters = parameters;
		}
    }
}

