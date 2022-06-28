using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISBpview : IBusinessLogic
	{
        public RIS_BPVIEW RIS_BPVIEW { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISBpview()
		{
            RIS_BPVIEW = new RIS_BPVIEW();
            Transaction = null;
		}
		
		public void Invoke()
		{
            RIS_BPVIEWDeleteData _proc = new RIS_BPVIEWDeleteData();
            _proc.RIS_BPVIEW = this.RIS_BPVIEW;
			_proc.Delete();
		}
	}
}

