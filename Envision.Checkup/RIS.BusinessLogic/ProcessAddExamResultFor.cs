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
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddExamResultFor : IBusinessLogic
    {
        private ExamResultSave _result;

        public ProcessAddExamResultFor()
        {

        }

        public void Invoke()
        {
            ExamResultForInsertData resultdata = new ExamResultForInsertData();
            resultdata.ExamResultSave = this.ExamResultSave;
            resultdata.Add();

        }

        public ExamResultSave ExamResultSave
        {
            get { return _result; }
            set { _result = value; }
        }
    }
}
