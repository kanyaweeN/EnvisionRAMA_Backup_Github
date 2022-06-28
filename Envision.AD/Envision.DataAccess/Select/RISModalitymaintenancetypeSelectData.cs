//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    22/01/2553 11:25:39
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Envision.Common;

namespace Envision.DataAccess.Select
{
	public class RISModalitymaintenancetypeSelectData : DataAccessBase 
	{
        private RIS_MODALITYMAINTENANCETYPE _rismodalitymaintenancetype;
		public  RISModalitymaintenancetypeSelectData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCETYPE_Select;
		}
        public RIS_MODALITYMAINTENANCETYPE RIS_MODALITYMAINTENANCETYPE
		{
			get{return _rismodalitymaintenancetype;}
			set{_rismodalitymaintenancetype=value;}
		}
		public DataSet GetData()
		{
            //param = new RISModalitymaintenancetypeSelectDataParameters(RIS_MODALITYMAINTENANCETYPE);
            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
            //return ds;
            DataSet ds = new DataSet();
            //ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
	}
}

