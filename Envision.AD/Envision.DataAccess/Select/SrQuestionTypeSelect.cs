using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class SrQuestionTypeSelect : DataAccessBase
    {
        public SR_QUESTIONTYPE SR_QUESTIONTYPE { get; set; } 
        public SrQuestionTypeSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONTYPE_SELECT;
        }

        public DataSet SelectData()
        {
            this.ParameterList = this.BuildParameters();
            return this.ExecuteDataSet();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@ORG_ID", SR_QUESTIONTYPE.ORG_ID)
                                       };
            return parameters;
        }
    }
}
