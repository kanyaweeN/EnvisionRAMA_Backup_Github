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
    public class ProcessAddRisExamresultStatReport : IBusinessLogic
    {
        public RIS_EXAMRESULTSTATREPORT RIS_EXAMRESULTSTATREPORT { get; set; }

        public ProcessAddRisExamresultStatReport()
        {
            RIS_EXAMRESULTSTATREPORT = new RIS_EXAMRESULTSTATREPORT();
        }

        public void Invoke()
        {
            RisExamresultStatReportInsertData addendumdata = new RisExamresultStatReportInsertData();
            addendumdata.RIS_EXAMRESULTSTATREPORT = RIS_EXAMRESULTSTATREPORT;
            addendumdata.Add();

        }
    }
}
