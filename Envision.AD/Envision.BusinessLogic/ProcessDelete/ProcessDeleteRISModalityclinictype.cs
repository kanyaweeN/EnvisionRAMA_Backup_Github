using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISModalityclinictype : IBusinessLogic
	{
        public RIS_MODALITYCLINICTYPE RIS_MODALITYCLINICTYPE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISModalityclinictype()
		{
            RIS_MODALITYCLINICTYPE = new RIS_MODALITYCLINICTYPE();
            Transaction = null;
		}
		
		public void Invoke()
		{
            RIS_MODALITYCLINICTYPEDeleteData _proc = new RIS_MODALITYCLINICTYPEDeleteData();
            _proc.RIS_MODALITYCLINICTYPE = this.RIS_MODALITYCLINICTYPE;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

