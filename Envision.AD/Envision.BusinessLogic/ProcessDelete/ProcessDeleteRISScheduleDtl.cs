using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{

    public class ProcessDeleteRISScheduleDtl : IBusinessLogic
    {
        public RIS_SCHEDULEDTL RIS_SCHEDULEDTL { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessDeleteRISScheduleDtl() {
            RIS_SCHEDULEDTL = new RIS_SCHEDULEDTL();
            Transaction = null;
        }
        public void Invoke()
        {
            RIS_SCHEDULEDTLDeleteData _proc = new RIS_SCHEDULEDTLDeleteData();
            _proc.RIS_SCHEDULEDTL = RIS_SCHEDULEDTL;
            _proc.Delete();
        }
        public void InvokeCNMI()
        {
            RIS_SCHEDULEDTLDeleteData _proc = new RIS_SCHEDULEDTLDeleteData();
            _proc.RIS_SCHEDULEDTL = RIS_SCHEDULEDTL;
            _proc.DeleteCNMI();
        }
    }
}
