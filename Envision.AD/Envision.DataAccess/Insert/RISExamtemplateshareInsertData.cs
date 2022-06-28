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
	public class RISExamtemplateshareInsertData : DataAccessBase 
	{
        public RIS_EXAMTEMPLATESHARE RIS_EXAMTEMPLATESHARE { get; set; }
		public  RISExamtemplateshareInsertData()
		{
            RIS_EXAMTEMPLATESHARE = new RIS_EXAMTEMPLATESHARE();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMTEMPLATESHARE_Insert;
		}
		public bool Add()
		{

            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
             Parameter("@EXAM_ID",RIS_EXAMTEMPLATESHARE.EXAM_ID)
                ,Parameter("@TEMPLATE_ID",RIS_EXAMTEMPLATESHARE.TEMPLATE_ID)
                ,Parameter("@SHARE_WITH",RIS_EXAMTEMPLATESHARE.SHARE_WITH)
                ,Parameter("@ORG_ID",RIS_EXAMTEMPLATESHARE.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_EXAMTEMPLATESHARE.CREATED_BY)
			            };
            return parameters;
        }
		
	}
}

