using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class SRQuestionTypeSelectData : DataAccessBase 
    {
        public SR_QUESTIONTYPE SR_QUESTIONTYPE { get; set; } 

        public SRQuestionTypeSelectData() {
            SR_QUESTIONTYPE = new SR_QUESTIONTYPE();
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONTYPE_Select;
        }
        public DataTable GetData() {
            DataTable dtt = new DataTable();
            this.ParameterList = this.BuildParameters();
            dtt = ExecuteDataTable();
            return dtt;
        }
        //public DataSet SelectData()
        //{
        //    this.ParameterList = this.BuildParameters();
        //    return this.ExecuteDataSet();
        //}

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@ORG_ID", SR_QUESTIONTYPE.ORG_ID)
                                       };
            return parameters;
        }

    }
}
