using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
using System.Data;

namespace RIS.BusinessLogic
{
    public class ProcessAddPatientRegistration
    {
        HISRegistration _hisreg;
        DataSet _ds;

        public ProcessAddPatientRegistration()
        {      
        }

        public void Invoke()
        {
            PatientRegistrationInsertData insert = new PatientRegistrationInsertData();
            insert.HISRegistration = this.HISRegistration;
            _ds = insert.Add();
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
