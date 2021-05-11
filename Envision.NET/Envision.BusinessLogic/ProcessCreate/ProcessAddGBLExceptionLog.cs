/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLExceptionLog : IBusinessLogic
    {
        public GBL_EXCEPTIONLOG GBL_EXCEPTIONLOG { get; set; }

        public ProcessAddGBLExceptionLog()
        {
            GBL_EXCEPTIONLOG = new GBL_EXCEPTIONLOG();
        }

        public void Invoke()
        {
            GBLExceptionLogInsertData alertdata = new GBLExceptionLogInsertData();
            alertdata.GBL_EXCEPTIONLOG = this.GBL_EXCEPTIONLOG;
            alertdata.Add();

        }

    }
}
