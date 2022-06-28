//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    02/06/2552 08:25:41
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
	public class ProcessAddHREmp : IBusinessLogic
	{
        public HR_EMP HR_EMP { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddHREmp()
		{
            HR_EMP = new HR_EMP();
            Transaction = null;
		}
		public void Invoke()
		{
            HREmpInsertData _proc = new HREmpInsertData();
            _proc.HR_EMP = this.HR_EMP;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
        public void AddFromHis() {
            HREmpInsertData _proc = new HREmpInsertData();
            _proc.HR_EMP = this.HR_EMP;
            _proc.HR_EMP.EMP_ID = _proc.AddFromHIS();
        }
        public void AddADFromHis()
        {
            HREmpInsertData _proc = new HREmpInsertData();
            _proc.HR_EMP = this.HR_EMP;
            _proc.HR_EMP.EMP_ID = _proc.AddADFromHis();
        }
	}
}

