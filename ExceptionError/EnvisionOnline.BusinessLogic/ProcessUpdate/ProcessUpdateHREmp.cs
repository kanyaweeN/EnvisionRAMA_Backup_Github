using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Update;

namespace EnvisionOnline.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateHREmp: IBusinessLogic
    {
        
        public HR_EMP HR_EMP { get; set; }

        public ProcessUpdateHREmp()
        {
            HR_EMP = new HR_EMP();
        }
        public void Invoke()
        {

            HREmpUpdateData _proc = new HREmpUpdateData();
            _proc.HR_EMP = this.HR_EMP;
                _proc.Update();
        }
    }
}
