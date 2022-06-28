//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2553 01:30:46
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
	public class RISFilmtrackerDeleteData : DataAccessBase 
	{
        private RIS_FILMTRACKER _risfilmtracker;
		public  RISFilmtrackerDeleteData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_FILMTRACKER_Delete;
		}
        public RIS_FILMTRACKER RISFilmtracker
		{
			get{return _risfilmtracker;}
			set{_risfilmtracker=value;}
		}
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={ 			
                Parameter("@TRACKING_ID",RISFilmtracker.TRACKING_ID)
			};
            return parameters;
        }
	}
}

