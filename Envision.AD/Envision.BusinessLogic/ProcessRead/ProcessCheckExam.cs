using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessCheckExam : IBusinessLogic
    {
        private CheckExamResult _result;
        private DataSet _resultset;

        public ProcessCheckExam()
        {

        }

        public void Invoke()
        {
            ExamResultSelectData resultdata = new ExamResultSelectData();
            resultdata.CheckExamResult = this.CheckExamResult;
            ResultSet = resultdata.Get();
        }

        

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public CheckExamResult CheckExamResult
        {
            get { return _result; }
            set { _result = value; }
        }
        	

    }
}
