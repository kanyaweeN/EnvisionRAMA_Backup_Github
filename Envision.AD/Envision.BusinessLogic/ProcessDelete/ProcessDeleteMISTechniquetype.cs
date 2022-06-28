using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteMISTechniquetype : IBusinessLogic
	{
        private MIS_TECHNIQUETYPE MIS_TECHNIQUETYPE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteMISTechniquetype()
		{
            MIS_TECHNIQUETYPE = new MIS_TECHNIQUETYPE();
            Transaction = null;
		}
		
		public void Invoke()
		{
            MIS_TECHNIQUETYPEDeleteData _proc = new MIS_TECHNIQUETYPEDeleteData();
            _proc.MIS_TECHNIQUETYPE = this.MIS_TECHNIQUETYPE;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

