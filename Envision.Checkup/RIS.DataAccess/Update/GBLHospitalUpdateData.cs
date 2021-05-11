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

namespace RIS.DataAccess.Update
{
	public class GBLHospitalUpdateData : DataAccessBase 
	{
		private GBLHospital	_gblhospital;
		private GBLHospitalUpdateDataParameters param;
		public  GBLHospitalUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_GBL_HOSPITAL_Update.ToString();
		}
		public  GBLHospital	GBLHospital
		{
			get{return _gblhospital;}
			set{_gblhospital=value;}
		}
		public bool Update()
		{
			param= new GBLHospitalUpdateDataParameters(GBLHospital);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
        //public bool Update(bool flag,bool autocommit) 
        //{
        //    if (flag)
        //    {
        //        DataAccess.DataAccessBase.BeginTransaction();
        //        SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
        //        param= new GBLHospitalUpdateDataParameters(GBLHospital);
        //        DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
        //        dbhelper.Run(tran,param.Parameters);
        //        if(autocommit) DataAccess.DataAccessBase.Commit();
        //    }
        //    else Update();
        //    return true;
        //}
	}
	public class GBLHospitalUpdateDataParameters 
	{
		private GBLHospital _gblhospital;
		private SqlParameter[] _parameters;
		public GBLHospitalUpdateDataParameters(GBLHospital gblhospital)
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
                ,new SqlParameter("@HOS_UID",GBLHospital.HOS_UID)
                ,new SqlParameter("@HOS_NAME",GBLHospital.HOS_NAME)
                ,new SqlParameter("@HOS_NAME_ALIAS",GBLHospital.HOS_NAME_ALIAS)
                ,new SqlParameter("@PHONE_NO",GBLHospital.PHONE_NO)
                ,new SqlParameter("@DESCR",GBLHospital.DESCR)
                ,new SqlParameter("@ORG_ID",GBLHospital.ORG_ID)
                ,new SqlParameter("@PERCENT_DISCOUNT",GBLHospital.PERCENT_DISCOUNT)
                ,new SqlParameter("@LAST_MODIFIED_BY",GBLHospital.LAST_MODIFIED_BY)
			};
			_parameters = parameters;
		}
	}
}

