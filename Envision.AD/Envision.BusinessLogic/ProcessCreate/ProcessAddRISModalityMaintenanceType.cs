using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISModalitymaintenanceType : IBusinessLogic
	{
        public RIS_MODALITYMAINTENANCETYPE RIS_MODALITYMAINTENANCETYPE { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddRISModalitymaintenanceType()
		{
            RIS_MODALITYMAINTENANCETYPE = new RIS_MODALITYMAINTENANCETYPE();
            Transaction = null;
		}
		public void Invoke()
		{
            RISModalityMaintenanceTypeInsertData _proc = new RISModalityMaintenanceTypeInsertData();
            _proc.RIS_MODALITYMAINTENANCETYPE = this.RIS_MODALITYMAINTENANCETYPE;
            _proc.Add();
		}
	}
}

