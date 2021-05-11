//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    26/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISInsurancetypeSelectData : DataAccessBase 
	{
		private RISInsurancetype	_risinsurancetype;
		private RISInsurancetypeInsertDataParameters	_risinsurancetypeinsertdataparameters;
		public  RISInsurancetypeSelectData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_INSURANCETYPE_SelectAll.ToString();
		}
		public  RISInsurancetype	RISInsurancetype
		{
			get{return _risinsurancetype;}
			set{_risinsurancetype=value;}
		}
		public DataSet GetData()
		{
            DataSet ds = null;
            //_risinsurancetypeinsertdataparameters = new RISInsurancetypeInsertDataParameters(RISInsurancetype);
            try
            {
                DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                ds = dbhelper.Run(base.ConnectionString);//,_risinsurancetypeinsertdataparameters.Parameters);
            }
            catch (Exception ex) { 
            
            }
			return ds;
		}
	}
	public class RISInsurancetypeInsertDataParameters 
	{
		private RISInsurancetype _risinsurancetype;
		private SqlParameter[] _parameters;
		public RISInsurancetypeInsertDataParameters(RISInsurancetype risinsurancetype)
		{
			RISInsurancetype=risinsurancetype;
			Build();
		}
		public  RISInsurancetype	RISInsurancetype
		{
			get{return _risinsurancetype;}
			set{_risinsurancetype=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={new SqlParameter("@INSURANCE_TYPE_ID",RISInsurancetype.INSURANCE_TYPE_ID),new SqlParameter("@INSURANCE_TYPE_UID",RISInsurancetype.INSURANCE_TYPE_UID),new SqlParameter("@INSURANCE_TYPE_DESC",RISInsurancetype.INSURANCE_TYPE_DESC),new SqlParameter("@ORG_ID",RISInsurancetype.ORG_ID),new SqlParameter("@CREATED_BY",RISInsurancetype.CREATED_BY)
			,new SqlParameter("@CREATED_ON",RISInsurancetype.CREATED_ON),new SqlParameter("@LAST_MODIFIED_BY",RISInsurancetype.LAST_MODIFIED_BY),new SqlParameter("@LAST_MODIFIED_ON",RISInsurancetype.LAST_MODIFIED_ON)};
			Parameters = parameters;
		}
	}
}

