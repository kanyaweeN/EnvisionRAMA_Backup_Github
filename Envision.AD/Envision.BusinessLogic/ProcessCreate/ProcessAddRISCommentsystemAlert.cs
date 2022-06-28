using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data;
using Envision.DataAccess.Select;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISCommentsystemAlert
    {
        public RIS_COMMENTSYSTEMALERT RIS_COMMENTSYSTEMALERT { get; set; }

        public ProcessAddRISCommentsystemAlert()
        {
            RIS_COMMENTSYSTEMALERT = new RIS_COMMENTSYSTEMALERT();
        }

        public void createdAlertMessage()
        {
            RISCommentsystemAlertInsertData alertInsert = new RISCommentsystemAlertInsertData();
            alertInsert.RIS_COMMENTSYSTEMALERT = RIS_COMMENTSYSTEMALERT;
            alertInsert.Add();
        }
        public void createdAlertMessageByAccession()
        {
            RISCommentsystemAlertInsertData alertInsert = new RISCommentsystemAlertInsertData();
            alertInsert.RIS_COMMENTSYSTEMALERT = RIS_COMMENTSYSTEMALERT;
            alertInsert.AddByAccession();
        }
        public void createdAlertMessageBySchedule()
        {
            RISCommentsystemAlertInsertData alertInsert = new RISCommentsystemAlertInsertData();
            alertInsert.RIS_COMMENTSYSTEMALERT = RIS_COMMENTSYSTEMALERT;
            alertInsert.AddBySchedule();
        }
        public void createdAlertMessageByXrayreq()
        {
            RISCommentsystemAlertInsertData alertInsert = new RISCommentsystemAlertInsertData();
            alertInsert.RIS_COMMENTSYSTEMALERT = RIS_COMMENTSYSTEMALERT;
            alertInsert.AddByXrayreq();
        }
    }
}
