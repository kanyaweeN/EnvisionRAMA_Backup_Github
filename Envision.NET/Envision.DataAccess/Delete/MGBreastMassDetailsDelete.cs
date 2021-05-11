using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class MGBreastMassDetailsDelete : DataAccessBase
    {
        public MG_BREASTMASSDETAILS MG_BREASTMASSDETAILS { get; set; }
        //public DbTransaction _transaction;
        public MGBreastMassDetailsDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMASSDETAILS_DELETE;
        }

        public void DeleteData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@ACCESSION_NO", this.MG_BREASTMASSDETAILS.ACCESSION_NO)
                                       };

            return parameters;
        }
    }
}
