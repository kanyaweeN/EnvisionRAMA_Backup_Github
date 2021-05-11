using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Update;

namespace EnvisionOnline.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdatePatientPhone: IBusinessLogic
    {
        
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }

        public ProcessUpdatePatientPhone()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
        }
        public void Invoke()
        {

            PatientPhoneUpdateData _proc = new PatientPhoneUpdateData();
            _proc.HIS_REGISTRATION = this.HIS_REGISTRATION;
                _proc.Update();
        }
    }
}
