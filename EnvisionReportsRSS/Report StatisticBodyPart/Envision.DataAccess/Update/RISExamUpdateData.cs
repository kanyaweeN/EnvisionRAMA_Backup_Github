using Envision.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Envision.DataAccess.Update
{
    public class RISExamUpdateData : DataAccessBase
    {
        public RIS_EXAM RIS_EXAM { get; set; }

        public RISExamUpdateData()
        {
            RIS_EXAM = new RIS_EXAM();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void UpdateByCode()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_UpdateByCode;
            ParameterList = buildParameterByCode();
            ExecuteNonQuery();
        }


        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@EXAM_ID",RIS_EXAM.EXAM_ID),
                                         Parameter("@EXAM_CODE",RIS_EXAM.EXAM_CODE),
                                     };
            return parameters;
        }
        private DbParameter[] buildParameterByCode()
        {
            DbParameter[] parameters ={
                                         Parameter("@EXAM_CODE",RIS_EXAM.EXAM_CODE),
                                           Parameter("@EXAM_NAME",RIS_EXAM.EXAM_NAME),
                                     };
            return parameters;
        }
    }
}
