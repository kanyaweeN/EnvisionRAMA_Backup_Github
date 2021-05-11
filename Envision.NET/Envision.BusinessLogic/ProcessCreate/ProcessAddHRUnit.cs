//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    02/06/2552 03:51:49
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddHRUnit : IBusinessLogic
	{
        public HR_UNIT HR_UNIT { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddHRUnit()
		{
            HR_UNIT = new HR_UNIT();
            Transaction = null;
		}
		public void Invoke()
		{
			HRUnitInsertData _proc=new HRUnitInsertData();
            _proc.HR_UNIT = this.HR_UNIT;
            HR_UNIT.UNIT_ID = _proc.Add();
		}
	}
}

