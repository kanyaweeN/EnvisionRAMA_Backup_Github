//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    23/03/2553 05:48:15
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

namespace Envision.DataAccess.Insert
{
	public class RISBillingtransactionlogdtlInsertData : DataAccessBase 
	{
		private RISBillingtransactionlogdtl	_risbillingtransactionlogdtl;
		public  RISBillingtransactionlogdtlInsertData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_BILLINGTRANSACTIONLOGDTL_Insert;
		}
		public  RISBillingtransactionlogdtl	RISBillingtransactionlogdtl
		{
			get{return _risbillingtransactionlogdtl;}
			set{_risbillingtransactionlogdtl=value;}
		}
		public bool Add()
		{
            //param= new RISBillingtransactionlogdtlInsertDataParameters(RISBillingtransactionlogdtl);
            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
            //return true;

            ParameterList = buildParameter();
            DataSet ds = ExecuteDataSet();
            return true;
		}
        public DbParameter[] buildParameter()
        {
            DbParameter[] parameters = {	
                Parameter("@ACCESSION_NO",RISBillingtransactionlogdtl.ACCESSION_NO)
                ,Parameter("@BILLING_MSG",RISBillingtransactionlogdtl.BILLING_MSG)
                ,Parameter("@BILLING_ACK_MSG",RISBillingtransactionlogdtl.BILLING_ACK_MSG)
                ,Parameter("@HN",RISBillingtransactionlogdtl.HN)
                ,Parameter("@AN",RISBillingtransactionlogdtl.AN)
                ,Parameter("@ISEQ",RISBillingtransactionlogdtl.ISEQ)
                ,Parameter("@UNIT_UID",RISBillingtransactionlogdtl.UNIT_UID)
                ,Parameter("@ORDER_DT",RISBillingtransactionlogdtl.ORDER_DT)
                ,Parameter("@EXAM_UID",RISBillingtransactionlogdtl.EXAM_UID)
                ,Parameter("@QTY",RISBillingtransactionlogdtl.QTY)
                ,Parameter("@RATE",RISBillingtransactionlogdtl.RATE)
                ,Parameter("@AMOUNT",RISBillingtransactionlogdtl.AMOUNT)
                ,Parameter("@HR_UNIT",RISBillingtransactionlogdtl.HR_UNIT)
                ,Parameter("@MSG_TYPE",RISBillingtransactionlogdtl.MSG_TYPE)
                ,Parameter("@CLINIC_TYPE",RISBillingtransactionlogdtl.CLINIC_TYPE)
                ,Parameter("@INSURANCE_TYPE_UID",RISBillingtransactionlogdtl.INSURANCE_TYPE_UID)
                ,Parameter("@HR_EMP",RISBillingtransactionlogdtl.HR_EMP)
                ,Parameter("@CREATED_BY",new GBLEnvVariable().UserID)
                ,Parameter("@BILLING_TYPE",RISBillingtransactionlogdtl.BILLING_TYPE)
                //,Parameter("@CREATED_ON",RISBillingtransactionlogdtl.CREATED_ON)
                //,Parameter("@LAST_MODIFIED_BY",RISBillingtransactionlogdtl.LAST_MODIFIED_BY)
                //,Parameter("@LAST_MODIFIED_ON",RISBillingtransactionlogdtl.LAST_MODIFIED_ON)
                ,Parameter("@ENC_ID",RISBillingtransactionlogdtl.ENC_ID)
                ,Parameter("@ENC_TYPE",RISBillingtransactionlogdtl.ENC_TYPE)
			};
            return parameters;
        }
	}
}

