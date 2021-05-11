using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class ExamResultSelectData : DataAccessBase
    {
        public CheckExamResult CheckExamResult { get; set; }

        public ExamResultSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_CheckExamResult;
            CheckExamResult = new CheckExamResult();
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                            Parameter( "@SP_TYPE"	        , CheckExamResult.SpType ),
                                            Parameter( "@ACCESSION_NO"	    , CheckExamResult.AccessionNo ) ,
				                            Parameter( "@ASSIGNED_TO"       , CheckExamResult.AssignedTO ),
                                            Parameter( "@ASSIGNED_BY"       , CheckExamResult.AssignedBy )
                                       };
            return parameters;
        }
    }
}
