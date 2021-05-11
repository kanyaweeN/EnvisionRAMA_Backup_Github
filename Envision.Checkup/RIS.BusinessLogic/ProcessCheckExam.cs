/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Select;
using System.Data;
using RIS.Common;

namespace RIS.BusinessLogic
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
