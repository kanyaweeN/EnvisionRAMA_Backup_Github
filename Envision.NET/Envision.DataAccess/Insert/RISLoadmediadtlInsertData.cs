//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:27
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
	public class RISLoadmediadtlInsertData : DataAccessBase 
	{
        public RIS_LOADMEDIADTL RIS_LOADMEDIADTL { get; set; }
		public  RISLoadmediadtlInsertData()
		{
            RIS_LOADMEDIADTL = new RIS_LOADMEDIADTL();
			StoredProcedureName = StoredProcedure.Prc_RIS_LOADMEDIADTL_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();

		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();

        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
            Parameter("@LOAD_ID",RIS_LOADMEDIADTL.LOAD_ID)
            ,Parameter("@EXAM_ID",RIS_LOADMEDIADTL.EXAM_ID)
            ,Parameter("@ACCESSION_NO",RIS_LOADMEDIADTL.ACCESSION_NO)
            ,Parameter("@HL7_TEXT",RIS_LOADMEDIADTL.HL7_TEXT)
            ,Parameter("@HL7_SENT",RIS_LOADMEDIADTL.HL7_SENT)
            ,Parameter("@CREATED_BY",RIS_LOADMEDIADTL.CREATED_BY)
            ,Parameter("@LAST_MODIFIED_BY",RIS_LOADMEDIADTL.LAST_MODIFIED_BY)
			            };
            return parameters;
        }
	}
}

