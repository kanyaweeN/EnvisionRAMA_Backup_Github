using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISLoadmediadtlUpdateData : DataAccessBase 
	{
        public RIS_LOADMEDIADTL RIS_LOADMEDIADTL { get; set; }

		public  RISLoadmediadtlUpdateData()
		{
            RIS_LOADMEDIADTL = new RIS_LOADMEDIADTL();
			StoredProcedureName = StoredProcedure.Prc_RIS_LOADMEDIADTL_Update;
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@LOAD_ID",RIS_LOADMEDIADTL.LOAD_ID)
,Parameter("@EXAM_ID",RIS_LOADMEDIADTL.EXAM_ID)
,Parameter("@ACCESSION_NO",RIS_LOADMEDIADTL.ACCESSION_NO)
,Parameter("@HL7_TEXT",RIS_LOADMEDIADTL.HL7_TEXT)
,Parameter("@HL7_SENT",RIS_LOADMEDIADTL.HL7_SENT)
,Parameter("@LAST_MODIFIED_BY",RIS_LOADMEDIADTL.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

