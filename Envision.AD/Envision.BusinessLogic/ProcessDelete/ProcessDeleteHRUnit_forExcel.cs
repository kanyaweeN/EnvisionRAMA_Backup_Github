using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteHRUnit_forExcel : IBusinessLogic
    {
        public HR_UNIT HR_UNIT { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteHRUnit_forExcel()
        {
            HR_UNIT = new HR_UNIT();
            Transaction = null;
        }

        public void Invoke()
        {
            HR_UnitDeleteDataforExcel _proc = new HR_UnitDeleteDataforExcel();
            _proc.HR_UNIT = HR_UNIT;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
        }
    }
}

