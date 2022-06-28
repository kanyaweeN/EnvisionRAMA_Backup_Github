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

namespace Envision.DataAccess.Insert
{
    public class MyMenuInsertData : DataAccessBase
    {

        int submenu;
        string active;
        public GBL_MYMENU GBL_MYMENU { get; set; }
        public MyMenuInsertData(int uid,string status)
        {
            GBL_MYMENU = new GBL_MYMENU();
            submenu = uid;
            active = status;
            StoredProcedureName = StoredProcedure.Prc_MyMenu_Insert;
        }

        public void Add()
        {

            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
				Parameter( "@EMP_ID"	, new GBLEnvVariable().UserID),
				Parameter( "@SUBMENU_ID"        , submenu ) ,
				Parameter( "@OrgID"	, new GBLEnvVariable().OrgID ) ,
				Parameter( "@IsActive"	    , active ) ,
				Parameter( "@CreatedBy"		, new GBLEnvVariable().UserID )
			            };
            return parameters;
        }

        
    }
}
