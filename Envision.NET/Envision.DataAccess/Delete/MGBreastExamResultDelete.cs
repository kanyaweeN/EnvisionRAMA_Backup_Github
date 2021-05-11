using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class MGBreastExamResultDelete : DataAccessBase
    {
        public MG_BREASTEXAMRESULT MG_BREASTEXAMRESULT { get; set; }
        public MGBreastExamResultDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTEXAMRESULT_DELETE;
        }
        public void DeleteData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@ACCESSION_NO", this.MG_BREASTEXAMRESULT.ACCESSION_NO)
                                       };
            return parameters;
        }
    }
}
