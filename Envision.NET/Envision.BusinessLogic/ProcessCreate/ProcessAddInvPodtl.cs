using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddINVPodtl : IBusinessLogic
	{
        public INV_PODTL INV_PODTL { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddINVPodtl()
		{
            INV_PODTL = new INV_PODTL();
            Transaction = null;
		}
        public ProcessAddINVPodtl(DbTransaction tran)
        {
            INV_PODTL = new INV_PODTL();
            Transaction = tran;
        }
		public void Invoke()
		{
			INVPodtlInsertData _proc=new INVPodtlInsertData();
            _proc.INV_PODTL = this.INV_PODTL;
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

