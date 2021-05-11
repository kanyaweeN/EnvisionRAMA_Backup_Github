using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RISBPViewMappingDeleteData: DataAccessBase 
	{
        public RIS_BPVIEWMAPPING RIS_BPVIEWMAPPING { get; set; }

        public RISBPViewMappingDeleteData()
		{
            RIS_BPVIEWMAPPING = new RIS_BPVIEWMAPPING();
            StoredProcedureName = StoredProcedure.Prc_RIS_BPVIEWMAPPING_DeleteAll;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@EXAM_ID",RIS_BPVIEWMAPPING.EXAM_ID)
                                     };
            return parameters;
        }
	}
}


