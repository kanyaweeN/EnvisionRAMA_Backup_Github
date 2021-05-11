using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISReleasemedia : IBusinessLogic
	{
        public RIS_RELEASEMEDIA RIS_RELEASEMEDIA { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISReleasemedia()
		{
            RIS_RELEASEMEDIA = new RIS_RELEASEMEDIA();
            Transaction = null;
		}
		
		public void Invoke()
		{
			RISReleasemediaDeleteData _proc=new RISReleasemediaDeleteData();
            _proc.RIS_RELEASEMEDIA = RIS_RELEASEMEDIA;
			_proc.Delete();
		}
	}
}

