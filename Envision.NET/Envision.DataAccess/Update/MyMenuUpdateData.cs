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
    public class MymenuUpdateData : DataAccessBase
    {

        int submenu;
        string active;

        public MymenuUpdateData(int uid, string status)
        {
            submenu = uid;
            active = status;
            StoredProcedureName = StoredProcedure.Prc_MyMenu_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@EMP_ID"	, new GBLEnvVariable().UserID),
				Parameter( "@SUBMENU_ID"        , submenu ) ,
				Parameter( "@IsActive"	    , active ) ,
				Parameter( "@ModifiedBy"		, new GBLEnvVariable().UserID )	
                                      };
            return parameters;
        }
        
    }
}
