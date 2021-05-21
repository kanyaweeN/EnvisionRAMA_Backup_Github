using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISRejectcapturelog : IBusinessLogic
    {
        public RIS_REJECTCAPTURELOG RIS_REJECTCAPTURELOG { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddRISRejectcapturelog()
        {
            RIS_REJECTCAPTURELOG = new RIS_REJECTCAPTURELOG();
            Transaction = null;
        }
        public ProcessAddRISRejectcapturelog(DbTransaction tran)
        {
            RIS_REJECTCAPTURELOG = new RIS_REJECTCAPTURELOG();
            Transaction = tran;
        }
        public void Invoke()
        {
            RISRejectcapturelogInsertData _proc = new RISRejectcapturelogInsertData();
            _proc.RIS_REJECTCAPTURELOG = this.RIS_REJECTCAPTURELOG;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
        }
    }
}
