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
    public class GBLAlertUpdateData : DataAccessBase
    {
        public GBL_ALERT_ALERTDTL GBL_ALERT_ALERTDTL { get; set; }
        public GBLAlertUpdateData()
        {
            GBL_ALERT_ALERTDTL = new GBL_ALERT_ALERTDTL();
            StoredProcedureName = StoredProcedure.GBLAlert_Update;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@AlertUID"	, GBL_ALERT_ALERTDTL.ALT_UID ) ,
				Parameter( "@OrgID"        , GBL_ALERT_ALERTDTL.ORG_ID ) ,
				Parameter( "@CreatedBy"	, GBL_ALERT_ALERTDTL.CREATED_BY ) ,
				Parameter( "@CreatedOn"	    , GBL_ALERT_ALERTDTL.CREATED_ON ) ,
				Parameter( "@ModifiedBy"		, GBL_ALERT_ALERTDTL.LAST_MODIFIED_BY ) ,
				Parameter( "@ModifiedOn"	    , GBL_ALERT_ALERTDTL.LAST_MODIFIED_ON ),
                Parameter( "@LangID"		    , GBL_ALERT_ALERTDTL.LANG_ID ) ,
				Parameter( "@AlertText"        , GBL_ALERT_ALERTDTL.ALT_TEXT ) ,
				Parameter( "@AlertType"	, GBL_ALERT_ALERTDTL.ALT_TYPE ) ,
				Parameter( "@IsActive"	    , GBL_ALERT_ALERTDTL.IS_ACTIVE ) ,
				Parameter( "@AlertTitle"		, GBL_ALERT_ALERTDTL.ALT_TITLE ) ,
				Parameter( "@AlertButton"	    , GBL_ALERT_ALERTDTL.ALT_BUTTON ),
                Parameter( "@CaptionButton1"	, GBL_ALERT_ALERTDTL.CAPTION_BTN1 ) ,
				Parameter( "@CaptionButton2"	    , GBL_ALERT_ALERTDTL.CAPTION_BTN2 ) ,
				Parameter( "@CaptionButton3"		, GBL_ALERT_ALERTDTL.CAPTION_BTN3 ) ,
                Parameter( "@AlertID"		,  GBL_ALERT_ALERTDTL.ALT_ID),
                Parameter( "@DefaultBtn"		,  GBL_ALERT_ALERTDTL.DEFAULT_BTN),
                Parameter( "@TimeSec"		,  GBL_ALERT_ALERTDTL.TIME_SEC),
                                      };
            return parameters;
        }
    }
}
