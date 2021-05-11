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
    public class ProcessAddGBLAlert : IBusinessLogic
    {
        public GBL_ALERT GBL_ALERT { get; set; }
        public ProcessAddGBLAlert()
        {
            GBL_ALERT = new GBL_ALERT();
        }

        public void Invoke()
        {
            GBLAlertInsertData alertdata = new GBLAlertInsertData();
            alertdata.GBL_ALERT = this.GBL_ALERT;
            alertdata.Add();

        }
    }
}
