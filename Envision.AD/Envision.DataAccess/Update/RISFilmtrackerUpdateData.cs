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

namespace Envision.DataAccess.Update
{
	public class RISFilmtrackerUpdateData : DataAccessBase 
	{
        private RIS_FILMTRACKER _risfilmtracker;
		public  RISFilmtrackerUpdateData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_FILMTRACKER_Update;
		}
        public RIS_FILMTRACKER RISFilmtracker
		{
			get{return _risfilmtracker;}
			set{_risfilmtracker=value;}
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@TRACKING_ID",RISFilmtracker.TRACKING_ID)
                //,new SqlParameter("@ACCESSION_NO",RISFilmtracker.ACCESSION_NO)
                //,new SqlParameter("@ISSUE_TYPE",RISFilmtracker.ISSUE_TYPE)
                //,new SqlParameter("@ISSUED_BY",RISFilmtracker.ISSUED_BY)
                //,new SqlParameter("@ISSUED_TO",RISFilmtracker.ISSUED_TO)
                //,new SqlParameter("@ISSUED_ON",RISFilmtracker.ISSUED_ON)
                ,Parameter("@RETURNED_ON",RISFilmtracker.RETURNED_ON)
                ,Parameter("@RETURNED_BY",RISFilmtracker.RETURNED_BY)
                ,Parameter("@RETURNED_TO",RISFilmtracker.RETURNED_TO)
                //,new SqlParameter("@ORG_ID",RISFilmtracker.ORG_ID)
                //,new SqlParameter("@CREATED_BY",RISFilmtracker.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISFilmtracker.CREATED_ON)
                ,Parameter("@LAST_MODIFIED_BY",RISFilmtracker.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",RISFilmtracker.LAST_MODIFIED_ON)
			};
            return parameters;
        }
	}
}

