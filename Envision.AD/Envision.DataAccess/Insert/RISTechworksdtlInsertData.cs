//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/10/2552 04:17:37
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISTechworksdtlInsertData : DataAccessBase 
	{
        private RIS_TECHWORKSDTL _ristechworksdtl;
        //private RISTechworksdtlInsertDataParameters	param;
		public  RISTechworksdtlInsertData()
		{
		}
        public RIS_TECHWORKSDTL RIS_TECHWORKSDTL
		{
			get{return _ristechworksdtl;}
			set{_ristechworksdtl=value;}
		}
		public bool Add()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_TECHWORKSDTL_Insert;
            DbParameter[] parameters ={
                Parameter("@ACCESSION_NO",RIS_TECHWORKSDTL.ACCESSION_NO)
                //,new SqlParameter("@TAKE",RISTechworksdtl.TAKE)
                ,Parameter("@TECHNOLOGIST_ID",RIS_TECHWORKSDTL.TECHNOLOGIST_ID)
                ,Parameter("@CREATED_BY",RIS_TECHWORKSDTL.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISTechworksdtl.CREATED_ON)
                //,new SqlParameter("@LAST_MODIFIED_BY",RISTechworksdtl.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",RISTechworksdtl.LAST_MODIFIED_ON)
            };
            ParameterList = parameters;
            ExecuteNonQuery();
			return true;
		}
        public bool AddRadGroup()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_TECHWORKSDTLRAD_Insert;
            DbParameter[] parameters ={
                Parameter("@ACCESSION_NO",RIS_TECHWORKSDTL.ACCESSION_NO)
                ,Parameter("@RAD_ID",RIS_TECHWORKSDTL.TECHNOLOGIST_ID)
                ,Parameter("@CREATED_BY",RIS_TECHWORKSDTL.CREATED_BY)
                ,Parameter("@RAD_SLNO",RIS_TECHWORKSDTL.RAD_SLNO)
            };
            ParameterList = parameters;
            ExecuteNonQuery();
            return true;
        }
        //public bool Add(bool flag,bool autocommit) 
        //{
        //    if (flag)
        //    {
        //        DataAccess.DataAccessBase.BeginTransaction();
        //        SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
        //        param= new RISTechworksdtlInsertDataParameters(RISTechworksdtl);
        //        DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
        //        dbhelper.Run(tran,param.Parameters);
        //        if(autocommit) DataAccess.DataAccessBase.Commit();
        //    }
        //    else Add();
        //    return true;
        //}
	}
    //public class RISTechworksdtlInsertDataParameters 
    //{
    //    private RISTechworksdtl _ristechworksdtl;
    //    private SqlParameter[] _parameters;
    //    public RISTechworksdtlInsertDataParameters(RISTechworksdtl ristechworksdtl)
    //    {
    //        RISTechworksdtl=ristechworksdtl;
    //        Build();
    //    }
    //    public  RISTechworksdtl	RISTechworksdtl
    //    {
    //        get{return _ristechworksdtl;}
    //        set{_ristechworksdtl=value;}
    //    }
    //    public  SqlParameter[] Parameters
    //    {
    //        get{return _parameters;}
    //        set{_parameters=value;}
    //    }
    //    public void Build()
    //    {
    //        SqlParameter[] parameters ={			
    //            new SqlParameter("@ACCESSION_NO",RISTechworksdtl.ACCESSION_NO)
    //            //,new SqlParameter("@TAKE",RISTechworksdtl.TAKE)
    //            ,new SqlParameter("@TECHNOLOGIST_ID",RISTechworksdtl.TECHNOLOGIST_ID)
    //            ,new SqlParameter("@CREATED_BY",RISTechworksdtl.CREATED_BY)
    //            //,new SqlParameter("@CREATED_ON",RISTechworksdtl.CREATED_ON)
    //            //,new SqlParameter("@LAST_MODIFIED_BY",RISTechworksdtl.LAST_MODIFIED_BY)
    //            //,new SqlParameter("@LAST_MODIFIED_ON",RISTechworksdtl.LAST_MODIFIED_ON)
    //        };
    //        _parameters = parameters;
    //    }
    //}
}

