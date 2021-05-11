using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISSchedule : IBusinessLogic
	{
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISSchedule()
		{
            RIS_SCHEDULE = new RIS_SCHEDULE();
            Transaction = null;
		}
		public void Invoke()
		{
			RIS_SCHEDULEDeleteData _proc=new RIS_SCHEDULEDeleteData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
			_proc.Delete();
		}
        public void InvokeReservation()
        {
            RIS_SCHEDULEDeleteData _proc = new RIS_SCHEDULEDeleteData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.InvokeReservation();
        }
	}
}

