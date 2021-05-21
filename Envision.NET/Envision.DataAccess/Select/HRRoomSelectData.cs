//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    16/06/2009 04:23:18
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Envision.DataAccess;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
	public class HRRoomSelectData : DataAccessBase 
	{
        public HRRoomSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_HR_ROOM_Select;
		}
		public DataSet GetData()
		{
            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //DataSet ds = dbhelper.Run(base.ConnectionString);
            //return ds;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataTable selectByModality(int modality_id)
		{
            StoredProcedureName = StoredProcedure.Prc_HR_ROOM_SelectBYModality;
            DataTable ds = new DataTable();
            DbParameter[] parameters = {
                Parameter("@MODALITY_ID",modality_id)
            };
            ParameterList = parameters;
            ds = ExecuteDataTable();
            return ds;
		}
        
	}
}

