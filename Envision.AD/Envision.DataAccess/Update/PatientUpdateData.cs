/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class PatientUpdateData : DataAccessBase
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }

        public PatientUpdateData()
        {
            RIS_PATSTATUS = new RIS_PATSTATUS();
            StoredProcedureName = StoredProcedure.PRC_RIS_SF04_Update;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@STATUS_ID"	, RIS_PATSTATUS.STATUS_ID ) ,
				Parameter( "@STATUS_UID"	, RIS_PATSTATUS.STATUS_UID ) ,
				Parameter( "@STATUS_TEXT"        , RIS_PATSTATUS.STATUS_TEXT ) ,
				Parameter( "@IsActive"	, RIS_PATSTATUS.IS_ACTIVE  ) ,
				Parameter( "@OrgID"	    , RIS_PATSTATUS.ORG_ID ) ,
				Parameter( "@LAST_MODIFIED_BY"		, RIS_PATSTATUS.LAST_MODIFIED_BY ) ,
                                      };
            return parameters;
        }
    }
}
