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
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISFilmtrackerInsertData : DataAccessBase 
	{
        private RIS_FILMTRACKER _risfilmtracker;
		public  RISFilmtrackerInsertData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_FILMTRACKER_Insert;
		}
        public RIS_FILMTRACKER RISFilmtracker
		{
			get{return _risfilmtracker;}
			set{_risfilmtracker=value;}
		}
		public bool Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
		}
        public DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@ACCESSION_NO",RISFilmtracker.ACCESSION_NO)
                ,Parameter("@ISSUE_TYPE",RISFilmtracker.ISSUE_TYPE)
                ,Parameter("@ISSUED_BY",RISFilmtracker.ISSUED_BY)
                ,Parameter("@ISSUED_TO",RISFilmtracker.ISSUED_TO)
                ,Parameter("@ISSUED_ON",RISFilmtracker.ISSUED_ON)
                //,new SqlParameter("@RETURNED_ON",RISFilmtracker.RETURNED_ON)
                //,new SqlParameter("@RETURNED_BY",RISFilmtracker.RETURNED_BY)
                //,new SqlParameter("@RETURNED_TO",RISFilmtracker.RETURNED_TO)
                ,Parameter("@ORG_ID",RISFilmtracker.ORG_ID)
                ,Parameter("@CREATED_BY",RISFilmtracker.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISFilmtracker.CREATED_ON)
                //,new SqlParameter("@LAST_MODIFIED_BY",RISFilmtracker.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",RISFilmtracker.LAST_MODIFIED_ON)
			};
            return parameters;
        }
	}
}

