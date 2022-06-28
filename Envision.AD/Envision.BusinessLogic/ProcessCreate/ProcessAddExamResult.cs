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
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddExamResult : IBusinessLogic
    {
        public RIS_EXAMRESULT RIS_EXAMRESULT { get; set; }
        public ProcessAddExamResult()
        {
            RIS_EXAMRESULT = new RIS_EXAMRESULT();
        }

        public void Invoke()
        {
            ExamResultInsertData resultdata = new ExamResultInsertData();
            resultdata.RIS_EXAMRESULT = RIS_EXAMRESULT;
            resultdata.Add();

        }
    }
}
