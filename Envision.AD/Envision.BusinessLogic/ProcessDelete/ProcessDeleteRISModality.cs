using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISModality : IBusinessLogic
	{
        public RIS_MODALITY RIS_MODALITY { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteRISModality()
        {
            RIS_MODALITY = new RIS_MODALITY();
            Transaction = null;
        }
	
		public void Invoke()
		{
            RIS_MODALITYDeleteData _proc = new RIS_MODALITYDeleteData();
            _proc.RIS_MODALITY = this.RIS_MODALITY;
			_proc.Delete();
		}
	}
}

