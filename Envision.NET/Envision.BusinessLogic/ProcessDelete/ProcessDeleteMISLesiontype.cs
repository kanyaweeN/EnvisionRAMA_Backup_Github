using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteMISLesiontype : IBusinessLogic
	{
        public MIS_LESIONTYPE MIS_LESIONTYPE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteMISLesiontype()
		{
            MIS_LESIONTYPE = new MIS_LESIONTYPE();
            Transaction = null;
		}
		
		public void Invoke()
		{
            MIS_LESIONTYPEDeleteData _proc = new MIS_LESIONTYPEDeleteData();
            _proc.MIS_LESIONTYPE = this.MIS_LESIONTYPE;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

