//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    11/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class HISDoctorSelectData : DataAccessBase 
	{
		private HISDoctor	_hisdoctor;
		private HISDoctorInsertDataParameters	_hisdoctorinsertdataparameters;
		public  HISDoctorSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_HR_EMP_SelectDoctor.ToString();
		}
		public  HISDoctor	HISDoctor
		{
			get{return _hisdoctor;}
			set{_hisdoctor=value;}
		}
		public DataSet GetData()
		{
            //_hisdoctorinsertdataparameters = new HISDoctorInsertDataParameters(HISDoctor);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //DataSet ds = dbhelper.Run(base.ConnectionString,_hisdoctorinsertdataparameters.Parameters);
            DataSet ds = dbhelper.Run(base.ConnectionString);//, _hisdoctorinsertdataparameters.Parameters);
			return ds;
		}
	}
	public class HISDoctorInsertDataParameters 
	{
		private HISDoctor _hisdoctor;
		private SqlParameter[] _parameters;
		public HISDoctorInsertDataParameters(HISDoctor hisdoctor)
		{
			HISDoctor=hisdoctor;
			Build();
		}
		public  HISDoctor	HISDoctor
		{
			get{return _hisdoctor;}
			set{_hisdoctor=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={new SqlParameter("@DOC_ID",HISDoctor.DOC_ID),new SqlParameter("@FNAME",HISDoctor.FNAME),new SqlParameter("@MNAME",HISDoctor.MNAME),new SqlParameter("@LNAME",HISDoctor.LNAME)};
			Parameters = parameters;
		}
	}
}

