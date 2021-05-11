using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISOrderDtl : IBusinessLogic
    {
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessDeleteRISOrderDtl()
        {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            Transaction = null;
        }

        public void Invoke()
        {
            RISOrderDtlDeleteData _proc = new RISOrderDtlDeleteData();
            _proc.RIS_ORDERDTL = RIS_ORDERDTL;
            _proc.Delete();
        }
    }
}
