//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    23/03/2553 05:16:49
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
	public class RISBillingtransactionlogInsertData : DataAccessBase 
	{
		private RISBillingtransactionlog	_risbillingtransactionlog;
		public  RISBillingtransactionlogInsertData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_BILLINGTRANSACTIONLOG_Insert;
		}
		public  RISBillingtransactionlog	RISBillingtransactionlog
		{
			get{return _risbillingtransactionlog;}
			set{_risbillingtransactionlog=value;}
		}
		public bool Add()
		{
            //param= new RISBillingtransactionlogInsertDataParameters(RISBillingtransactionlog);
            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
            //return true;

            ParameterList = buildParameter();
            DataSet ds = ExecuteDataSet();
            return true;
		}

        public DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@ACCESSION_NO",RISBillingtransactionlog.ACCESSION_NO)
                ,Parameter("@CREATED_BY",new GBLEnvVariable().UserID)
                //,new SqlParameter("@CREATED_ON",RISBillingtransactionlog.CREATED_ON)
                //,new SqlParameter("@LAST_MODIFIED_BY",RISBillingtransactionlog.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",RISBillingtransactionlog.LAST_MODIFIED_ON)
			};
            return parameters;
        }
	}
}

