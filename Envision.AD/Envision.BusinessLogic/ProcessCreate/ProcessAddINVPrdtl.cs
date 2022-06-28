using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddINVPrdtl : IBusinessLogic
	{
        public INV_PRDTL INV_PRDTL { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddINVPrdtl()
		{
            INV_PRDTL = new INV_PRDTL();
            Transaction = null;
		}
        public ProcessAddINVPrdtl(DbTransaction tran)
        {
            INV_PRDTL = new INV_PRDTL();
            Transaction = tran;
        }
		public void Invoke()
		{
			INVPrdtlInsertData _proc=new INVPrdtlInsertData();
            _proc.INV_PRDTL = this.INV_PRDTL;
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

