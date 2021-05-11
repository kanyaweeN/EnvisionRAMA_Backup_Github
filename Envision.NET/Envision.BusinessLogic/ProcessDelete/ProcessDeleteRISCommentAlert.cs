using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISCommentAlert : IBusinessLogic
    {
        public RIS_COMMENTSYSTEMALERT RIS_COMMENTSYSTEMALERT;

        public ProcessDeleteRISCommentAlert()
        {
            RIS_COMMENTSYSTEMALERT = new RIS_COMMENTSYSTEMALERT();
        }
        public void Invoke()
        { 
        
        }

        public void DeleteByAccession(int readerId, string accessionNo)
        {
            RISCommentAlertDeleteData proc = new RISCommentAlertDeleteData();
            proc.RIS_COMMENTSYSTEMALERT.READER_ID = readerId;
            proc.RIS_COMMENTSYSTEMALERT.ACCESSION_NO = accessionNo;
            proc.Delete();
        }

        public void DeleteBySchedule(int readerId, int scheduleId)
        {
            RISCommentAlertDeleteData proc = new RISCommentAlertDeleteData();
            proc.RIS_COMMENTSYSTEMALERT.READER_ID = readerId;
            proc.RIS_COMMENTSYSTEMALERT.SCHEDULE_ID = scheduleId;
            proc.DeleteByScheduleId();
        }
    }
}
