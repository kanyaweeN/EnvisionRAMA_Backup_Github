using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISStudyLibrarydtlDelete : IBusinessLogic
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }

        public ProcessDeleteRISStudyLibrarydtlDelete()
        {
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
        }
	
		public void Invoke()
		{
            RISStudyLibrarydtlDeleteData _proc = new RISStudyLibrarydtlDeleteData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
			_proc.Delete();
		}
	}
}

