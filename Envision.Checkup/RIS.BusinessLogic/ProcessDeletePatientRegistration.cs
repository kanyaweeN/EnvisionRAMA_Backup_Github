using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeletePatientRegistration
    {
        HISRegistration _hisreg;

        public ProcessDeletePatientRegistration()
        {      
        }

        public void Invoke()
        {
            PatientRegistrationDeleteData update = new PatientRegistrationDeleteData();
            update.HISRegistration = this.HISRegistration;
            update.Delete();
        }

        public HISRegistration HISRegistration
        {
            get { return _hisreg; }
            set { _hisreg = value; }
        }
    }
}
