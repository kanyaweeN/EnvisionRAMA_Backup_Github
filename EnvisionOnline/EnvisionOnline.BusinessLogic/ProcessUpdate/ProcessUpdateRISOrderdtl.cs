using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.DataAccess.Update;

namespace EnvisionOnline.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISOrderdtl : IBusinessLogic
    {
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateRISOrderdtl()
        {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            Transaction = null;
        }

        public void Invoke()
        {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData();
            _proc.RIS_ORDERDTL = this.RIS_ORDERDTL;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
        }
    }
}
