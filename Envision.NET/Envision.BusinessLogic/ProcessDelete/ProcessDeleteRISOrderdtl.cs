using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISOrderdtl// : IBusinessLogic
	{
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISOrderdtl()
		{
            RIS_ORDERDTL = new RIS_ORDERDTL();
            Transaction = null;
		}
		
		public void Invoke_Deleted()
		{
            RIS_ORDERDTLDeleteData _proc = new RIS_ORDERDTLDeleteData();
            _proc.RIS_ORDERDTL = this.RIS_ORDERDTL;
            _proc.RIS_ORDERDTL.ORDER_ID = RIS_ORDERDTL.ORDER_ID;
            _proc.RIS_ORDERDTL.EXAM_ID = RIS_ORDERDTL.EXAM_ID;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

