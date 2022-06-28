﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RISExamresultFilterworklistUpdateData : DataAccessBase
    {
        public RIS_EXAMRESULT_FILTERWORKLIST RIS_EXAMRESULT_FILTERWORKLIST { get; set; }

        public RISExamresultFilterworklistUpdateData()
        {
            RIS_EXAMRESULT_FILTERWORKLIST = new RIS_EXAMRESULT_FILTERWORKLIST();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_FILTERWORKLIST_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter("@FILTER_ID",RIS_EXAMRESULT_FILTERWORKLIST.FILTER_ID),
                Parameter("@FILTER_NAME",RIS_EXAMRESULT_FILTERWORKLIST.FILTER_NAME),
                Parameter("@FILTER_DETAIL",RIS_EXAMRESULT_FILTERWORKLIST.FILTER_DETAIL),
                Parameter("@LAST_MODIFIED_BY",RIS_EXAMRESULT_FILTERWORKLIST.LAST_MODIFIED_BY),
                                      };
            return parameters;
        }
    }
}
