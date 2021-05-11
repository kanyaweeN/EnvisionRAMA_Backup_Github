//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    02/06/2552 03:51:49
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
	public class HRUnitInsertData : DataAccessBase 
	{
		private HRUnit	_hrunit;
		private HRUnitInsertDataParameters	param;
		public  HRUnitInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_HR_UNIT_Insert.ToString();
		}
		public  HRUnit	HRUnit
		{
			get{return _hrunit;}
			set{_hrunit=value;}
		}
		public int Add()
		{
			param= new HRUnitInsertDataParameters(HRUnit);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds=dbhelper.Run(base.ConnectionString,param.Parameters);
            int id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return id;
		}
	}
	public class HRUnitInsertDataParameters 
	{
		private HRUnit _hrunit;
		private SqlParameter[] _parameters;
		public HRUnitInsertDataParameters(HRUnit hrunit)
		{
			HRUnit=hrunit;
			Build();
		}
		public  HRUnit	HRUnit
		{
			get{return _hrunit;}
			set{_hrunit=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter pUNIT_ID = new SqlParameter();
            pUNIT_ID.ParameterName = "@UNIT_ID";
            pUNIT_ID.Value = 0;
            pUNIT_ID.Direction = ParameterDirection.Output;

            SqlParameter pUNIT_ID_PARENT = new SqlParameter();
            pUNIT_ID_PARENT.ParameterName = "@UNIT_ID_PARENT";
            if (HRUnit.UNIT_ID_PARENT == 0)
                pUNIT_ID_PARENT.Value = 0;
            else
                pUNIT_ID_PARENT.Value = DBNull.Value;
         

            SqlParameter pUNIT_NAME_ALIAS = new SqlParameter();
            pUNIT_NAME_ALIAS.ParameterName = "@UNIT_NAME_ALIAS";
            if(string.IsNullOrEmpty(HRUnit.UNIT_NAME_ALIAS))
                pUNIT_NAME_ALIAS.Value = DBNull.Value ;
            else
                pUNIT_NAME_ALIAS.Value = HRUnit.UNIT_NAME_ALIAS;

            SqlParameter pUPHONE_NO = new SqlParameter();
            pUPHONE_NO.ParameterName = "@PHONE_NO";
            if (string.IsNullOrEmpty(HRUnit.PHONE_NO))
                pUPHONE_NO.Value = DBNull.Value;
            else
                pUPHONE_NO.Value = HRUnit.PHONE_NO;

           

			SqlParameter[] parameters ={			
                    pUNIT_ID
                    ,new SqlParameter("@UNIT_UID",HRUnit.UNIT_UID)
                    ,new SqlParameter("@UNIT_ID_PARENT",HRUnit.UNIT_ID_PARENT)
                    ,new SqlParameter("@UNIT_NAME",HRUnit.UNIT_NAME)
                    ,new SqlParameter("@UNIT_NAME_ALIAS",HRUnit.UNIT_NAME_ALIAS)
                    ,new SqlParameter("@PHONE_NO",HRUnit.PHONE_NO)
                    ,new SqlParameter("@DESCR",HRUnit.DESCR)
                    ,new SqlParameter("@UNIT_ALIAS",HRUnit.UNIT_ALIAS)
                    ,new SqlParameter("@UNIT_TYPE",HRUnit.UNIT_TYPE)
                    ,new SqlParameter("@UNIT_INS",HRUnit.UNIT_INS)
                    ,new SqlParameter("@IS_EXTERNAL",HRUnit.IS_EXTERNAL)
                    ,new SqlParameter("@LOC",HRUnit.LOC)
                    ,new SqlParameter("@CREATED_BY",HRUnit.CREATED_BY)
                    //,new SqlParameter("@CREATED_ON",HRUnit.CREATED_ON)
                    //,new SqlParameter("@LAST_MODIFIED_BY",HRUnit.LAST_MODIFIED_BY)
                    //,new SqlParameter("@LAST_MODIFIED_ON",HRUnit.LAST_MODIFIED_ON)
                    ,new SqlParameter("@ORG_ID",HRUnit.ORG_ID)
			};
			_parameters = parameters;
		}
	}
}

