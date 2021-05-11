using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISExamresultseverityLog : IBusinessLogic
    {
        public RIS_EXAMRESULTSEVERITY_LOG RIS_EXAMRESULTSEVERITY_LOG { get; set; }
        public ProcessAddRISExamresultseverityLog()
        {
            RIS_EXAMRESULTSEVERITY_LOG = new RIS_EXAMRESULTSEVERITY_LOG();
        }
        public void Invoke()
        {
            RISExamresultseverityLogInsertData _proc = new RISExamresultseverityLogInsertData();
            _proc.RIS_EXAMRESULTSEVERITY_LOG = this.RIS_EXAMRESULTSEVERITY_LOG;
            RIS_EXAMRESULTSEVERITY_LOG.SEVERITYLOG_ID = _proc.Add();
        }
    }
}