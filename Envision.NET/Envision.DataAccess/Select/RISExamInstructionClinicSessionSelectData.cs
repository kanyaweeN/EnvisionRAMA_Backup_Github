using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISExamInstructionClinicSessionSelectData : DataAccessBase
    {
        public RISExamInstructionClinicSessionSelectData()
        {
        }
        public DataSet GetData(int exam_id, int session_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMINSTRUCTIONCLINICSESSION_SelectByExamAndSession;
            ParameterList = new DbParameter[] {
                Parameter("@EXAM_ID",exam_id),
                Parameter("@SESSION_ID",session_id),
			};
            return ExecuteDataSet();
        }
    }
}

