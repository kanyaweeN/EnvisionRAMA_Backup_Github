using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISLoadmedia : IBusinessLogic
	{

        public RIS_LOADMEDIA RIS_LOADMEDIA { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISLoadmedia()
		{
            RIS_LOADMEDIA = new RIS_LOADMEDIA();
            Transaction = null;
		}
		
		public void Invoke()
		{
            RIS_LOADMEDIADeleteData _proc = new RIS_LOADMEDIADeleteData();
            _proc.RIS_LOADMEDIA = this.RIS_LOADMEDIA;
			 _proc.Delete();
		}
	}
}

