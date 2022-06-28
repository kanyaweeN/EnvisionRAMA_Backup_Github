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
    public class ResultStatusChangeInsertData : DataAccessBase
    {
        public HL7Monitoring HL7Monitoring { get; set; }

        public ResultStatusChangeInsertData()
        {
            HL7Monitoring = new HL7Monitoring();
            StoredProcedureName = StoredProcedure.Prc_ResultStatusChangeLog2;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();

        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
				Parameter( "@HN"	, HL7Monitoring.PatientID ) ,
                Parameter( "@ORDER_ID"	, HL7Monitoring.OrderID ) ,
				Parameter( "@ACCESSION_NO"        , HL7Monitoring.AccessionNo ) ,
				Parameter( "@EXAM_ID"	, HL7Monitoring.ExamID ) ,
				Parameter( "@ORGINAL_STATUS"	    , HL7Monitoring.OriginalStatus) ,
				Parameter( "@CHANGED_STATUS"		, HL7Monitoring.ChangeStatus ) ,
				Parameter( "@REQUEST_BY"	    , HL7Monitoring.RequestBy ), 
                Parameter( "@CHNAGE_PC"	    , HL7Monitoring.ChangePC ), 
                Parameter( "@ORG_ID"	    , HL7Monitoring.OrgID ),
                Parameter( "@CREATED_BY"	    , HL7Monitoring.CreatedBy ),
                Parameter( "@HL7_TEXT"	    , HL7Monitoring.Hl7Text ),
                Parameter( "@REASON"	    , HL7Monitoring.Reason ),
			            };
            return parameters;
        }
    }
}
