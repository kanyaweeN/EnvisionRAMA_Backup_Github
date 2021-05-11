using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISCommentAlert : IBusinessLogic
    {
        public RIS_COMMENTSYSTEMALERT RIS_COMMENTSYSTEMALERT { get; set; }

        public ProcessGetRISCommentAlert()
        {
            RIS_COMMENTSYSTEMALERT = new RIS_COMMENTSYSTEMALERT();
        }
        public void Invoke()
        {
            
        }
        public int GetAlertMessageCount()
        {
            RISCommentSystemAlertSelect _prc = new RISCommentSystemAlertSelect();
            _prc.RIS_COMMENTSYSTEMALERT = this.RIS_COMMENTSYSTEMALERT;
            return _prc.GetAlertMessageCount();
        }
        public DataSet GetAlertMessage()
        {
            RISCommentSystemAlertSelect _prc = new RISCommentSystemAlertSelect();
            _prc.RIS_COMMENTSYSTEMALERT = this.RIS_COMMENTSYSTEMALERT;

            return _prc.GetAlertMessage();
        }

    }
}
