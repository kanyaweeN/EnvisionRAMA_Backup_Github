//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2552 02:48:53
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISExamresulttemplateInsertData : DataAccessBase 
	{
        public RIS_EXAMRESULTTEMPLATE RIS_EXAMRESULTTEMPLATE { get; set; }
		public  RISExamresulttemplateInsertData()
		{
            RIS_EXAMRESULTTEMPLATE = new RIS_EXAMRESULTTEMPLATE();
		}
		public int Add()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTEMPLATE_Insert;
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return (int)ParameterList[0].Value;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter param1 = Parameter("@TEMPLATE_ID", RIS_EXAMRESULTTEMPLATE.TEMPLATE_ID);
            param1.Direction = ParameterDirection.Output;

            DbParameter[] parameters ={			
		        param1
                ,Parameter("@TEMPLATE_UID",RIS_EXAMRESULTTEMPLATE.TEMPLATE_UID)
                ,Parameter("@EXAM_ID",RIS_EXAMRESULTTEMPLATE.EXAM_ID)
                ,Parameter("@TEMPLATE_NAME",RIS_EXAMRESULTTEMPLATE.TEMPLATE_NAME)
                ,Parameter("@TEMPLATE_TEXT",RIS_EXAMRESULTTEMPLATE.TEMPLATE_TEXT)
                ,Parameter("@TEMPLATE_TEXT_RTF",RIS_EXAMRESULTTEMPLATE.TEMPLATE_TEXT_RTF)
                ,Parameter("@TEMPLATE_TYPE",RIS_EXAMRESULTTEMPLATE.TEMPLATE_TYPE)
                ,Parameter("@AUTO_APPLY",RIS_EXAMRESULTTEMPLATE.AUTO_APPLY)
                ,Parameter("@ORG_ID",RIS_EXAMRESULTTEMPLATE.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_EXAMRESULTTEMPLATE.CREATED_BY)
                ,Parameter("@SEVERITY_ID",RIS_EXAMRESULTTEMPLATE.SEVERITY_ID)
			            };
            return parameters;
        }
		
	}
}

