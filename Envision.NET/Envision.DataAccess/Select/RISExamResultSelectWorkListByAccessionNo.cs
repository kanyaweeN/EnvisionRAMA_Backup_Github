using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Select
{
    public class RISExamResultSelectWorkListByAccessionNo : DataAccessBase
    {
        public RISExamResultSelectWorkListByAccessionNo()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_WorkList_ByAccessionNo;
        }

        /// <summary>
        /// Get Data
        /// </summary>
        /// <param name="accession_no"></param>
        /// <param name="empId"></param>
        /// <returns></returns>
        public DataSet GetData(string accession_no, int empId)
        {
            this.ParameterList = this.BuildParameters(accession_no, empId);
            return this.ExecuteDataSet();
        }

        private DbParameter[] BuildParameters(string accession_no, int empId)
        {
            DbParameter[] parameters = {
                                           Parameter("ACCESSION_NO", accession_no),
                                           Parameter("EMP_ID", empId)
                                       };
            return parameters;
        }
    }
}
