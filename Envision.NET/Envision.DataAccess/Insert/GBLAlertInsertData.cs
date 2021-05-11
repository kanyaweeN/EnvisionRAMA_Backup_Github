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
    public class GBLAlertInsertData : DataAccessBase
    {
        public GBL_ALERT GBL_ALERT { get; set; }
        public GBL_ALERTDTL GBL_ALERTDTL { get; set; }
        public GBLAlertInsertData()
        {
            GBL_ALERT = new GBL_ALERT();
            GBL_ALERTDTL = new GBL_ALERTDTL();
            StoredProcedureName = StoredProcedure.GBLAlert_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@AlertUID"	, GBL_ALERT.ALT_UID ) ,
				Parameter( "@OrgID"        , GBL_ALERT.ORG_ID ) ,
				Parameter( "@CreatedBy"	, GBL_ALERT.CREATED_BY ) ,
				Parameter( "@CreatedOn"	    , GBL_ALERT.CREATED_ON ) ,
				Parameter( "@ModifiedBy"		, GBL_ALERT.LAST_MODIFIED_BY ) ,
				Parameter( "@ModifiedOn"	    , GBL_ALERT.LAST_MODIFIED_ON ),
                Parameter( "@LangID"		    , GBL_ALERTDTL.LANG_ID ) ,
				Parameter( "@AlertText"        , GBL_ALERTDTL.ALT_TEXT ) ,
				Parameter( "@AlertType"	, GBL_ALERTDTL.ALT_TYPE ) ,
				Parameter( "@IsActive"	    , GBL_ALERTDTL.IS_ACTIVE ) ,
				Parameter( "@AlertTitle"		, GBL_ALERTDTL.ALT_TITLE ) ,
				Parameter( "@AlertButton"	    , GBL_ALERTDTL.ALT_BUTTON ),
                Parameter( "@CaptionButton1"	, GBL_ALERTDTL.CAPTION_BTN1 ) ,
				Parameter( "@CaptionButton2"	    , GBL_ALERTDTL.CAPTION_BTN2 ) ,
				Parameter( "@CaptionButton3"		, GBL_ALERTDTL.CAPTION_BTN3 ) ,
                Parameter( "@AlertID"		,  GBL_ALERT.ALT_ID),
                Parameter( "@DefaultBtn"		,  GBL_ALERTDTL.DEFAULT_BTN),
                Parameter( "@TimeSec"		,  GBL_ALERTDTL.TIME_SEC),
            };
            return parameters;
        }

    }
}
