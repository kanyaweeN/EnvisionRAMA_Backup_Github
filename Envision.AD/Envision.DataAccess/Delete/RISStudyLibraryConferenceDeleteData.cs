using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RISStudyLibraryConferenceDeleteData: DataAccessBase 
    {
          public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }

          public RISStudyLibraryConferenceDeleteData()
		{
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARYCONFERENCE_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@LIBRARY_CONFERENCE_ID",RIS_STUDYLIBRARY.LIBRARY_CONFERENCE_ID),
                                     };
            return parameters;
        }
    }
}
