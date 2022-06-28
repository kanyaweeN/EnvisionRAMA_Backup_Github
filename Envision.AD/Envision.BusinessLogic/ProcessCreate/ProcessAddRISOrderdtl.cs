using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic
{
	public class ProcessAddRISOrderdtl : IBusinessLogic
	{
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        DbTransaction tran = null;

		public ProcessAddRISOrderdtl()
		{
            RIS_ORDERDTL = new RIS_ORDERDTL();
		}
		
		public void Invoke()
		{
            RIS_ORDERDTLInsertData _proc = new RIS_ORDERDTLInsertData();
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

