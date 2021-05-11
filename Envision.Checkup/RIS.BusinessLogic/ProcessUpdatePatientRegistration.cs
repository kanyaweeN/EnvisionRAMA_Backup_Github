using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
using System.Data;

namespace RIS.BusinessLogic
{
    public class ProcessUpdatePatientRegistration : IBusinessLogic
    {
        HISRegistration _hisreg;
        DataSet _ds;

        public ProcessUpdatePatientRegistration()
        {      
        }

        public void Invoke()
        {
            PatientRegistrationUpdateData update = new PatientRegistrationUpdateData();
            update.HISRegistration = this.HISRegistration;
            _ds = update.Update();
        }

        public DataSet ResultSet
        {
            get { return _ds; }
            set { _ds = value; }
        }

        public HISRegistration HISRegistration
        {
            get { return _hisreg; }
            set { _hisreg = value; }
        }
    }
}
