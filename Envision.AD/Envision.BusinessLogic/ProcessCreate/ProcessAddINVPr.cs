using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddINVPr : IBusinessLogic
	{
        public INV_PR INV_PR { get; set; }
        public DbTransaction Transaction { get; set; }
        private int id = 0; 
		public ProcessAddINVPr()
		{
            INV_PR = new INV_PR();
            Transaction = null;
		}
        public ProcessAddINVPr(DbTransaction tran)
        {
            INV_PR = new INV_PR();
            Transaction = tran;
        }
		public void Invoke()
		{
			INVPrInsertData _proc=new INVPrInsertData();
            _proc.INV_PR = this.INV_PR;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.INV_PR.PR_ID = _proc.GetID();
		}
	}
}

