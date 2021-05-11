using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class MGBreastUSMassDetailsDelete : DataAccessBase
    {
        public MG_BREASTUSMASSDETAILS MG_BREASTUSMASSDETAILS { get; set; }

        public MGBreastUSMassDetailsDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTUSMASSDETAILS_DELETE;
        }

        public void DeleteData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@ACCESSION_NO", this.MG_BREASTUSMASSDETAILS.ACCESSION_NO)
                                       };

            return parameters;
        }
    }
}
