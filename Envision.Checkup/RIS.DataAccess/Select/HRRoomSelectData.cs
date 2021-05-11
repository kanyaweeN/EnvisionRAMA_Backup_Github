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
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class HRRoomSelectData : DataAccessBase 
	{
        public HRRoomSelectData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_HR_ROOM_Select.ToString();
		}
		public DataSet GetData()
		{
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString);
			return ds;
		}
	}
}

