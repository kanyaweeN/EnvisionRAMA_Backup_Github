/*
 * Project	: RIS
 *
 * Author   : Tossapol Anchaleechamaikorn
 * eMail    : yod.jim@gmail.com
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

namespace Envision.DataAccess.Insert
{
    public class PatientInsertData : DataAccessBase
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }
        public PatientInsertData()
        {
            RIS_PATSTATUS = new RIS_PATSTATUS();
            StoredProcedureName = StoredProcedure.PRC_RIS_SF04_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
				Parameter( "@STATUS_UID"	, RIS_PATSTATUS.STATUS_UID ) ,
				Parameter( "@STATUS_TEXT"        , RIS_PATSTATUS.STATUS_TEXT ) ,
				Parameter( "@IsActive"	, RIS_PATSTATUS.IS_ACTIVE ) ,
				Parameter( "@OrgID"	    , RIS_PATSTATUS.ORG_ID ) ,
				Parameter( "@CreatedBy"		, RIS_PATSTATUS.CREATED_BY ) 
			            };
            return parameters;
        }
    }
}
