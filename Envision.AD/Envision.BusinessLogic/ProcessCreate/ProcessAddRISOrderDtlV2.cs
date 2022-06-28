using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Insert;
using Envision.Common;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISOrderDtlV2 : IBusinessLogic
    {
         public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        DbTransaction tran = null;

        public ProcessAddRISOrderDtlV2()
		{
            RIS_ORDERDTL = new RIS_ORDERDTL();
		}
		
		public void Invoke()
		{
            RISOrderDtlInsertV2 _proc = new RISOrderDtlInsertV2();
            _proc.RIS_ORDERDTL = RIS_ORDERDTL;
            if (tran == null)
                _proc.Add();
            else
                _proc.Add(tran);
		}

        public DbTransaction UseTransaction
        {
            set
            {
                tran = value;
            }
        }
    }
}
