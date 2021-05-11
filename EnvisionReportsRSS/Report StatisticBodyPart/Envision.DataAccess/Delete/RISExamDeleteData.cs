using Envision.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Envision.DataAccess.Delete
{
    public class RISExamDeleteData : DataAccessBase
    {
        public RIS_EXAM RIS_EXAM { get; set; }

        public RISExamDeleteData()
        {
            RIS_EXAM = new RIS_EXAM();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_Delete;
        }
        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@EXAM_ID",RIS_EXAM.EXAM_ID),
                                     };
            return parameters;
        }
    }
}
