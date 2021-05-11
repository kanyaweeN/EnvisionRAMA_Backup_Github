using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddINVPo : IBusinessLogic
	{
        public INV_PO INV_PO { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddINVPo()
		{
            INV_PO = new INV_PO();
            Transaction = null;
		}
        public ProcessAddINVPo(DbTransaction tran)
        {
            INV_PO = new INV_PO();
            Transaction = tran;
        }
		public void Invoke()
		{
			INVPoInsertData _proc=new INVPoInsertData();
            _proc.INV_PO = this.INV_PO;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.INV_PO.PO_ID = _proc.GetID();
		}
	}
}

