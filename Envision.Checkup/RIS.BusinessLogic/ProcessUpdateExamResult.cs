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
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateExamResult : IBusinessLogic
    {
        private ExamResultUpdate _result;

        public ProcessUpdateExamResult()
        {

        }

        public void Invoke()
        {
            ExamResultUpdateData resultdata = new ExamResultUpdateData();
            resultdata.ExamResultUpdate = this.ExamResultUpdate;
            resultdata.Update();

        }

        public ExamResultUpdate ExamResultUpdate
        {
            get { return _result; }
            set { _result = value; }
        }
    }
}
