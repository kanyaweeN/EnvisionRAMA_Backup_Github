using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddPatientRegistration
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }
        public DataSet _ds { get; set; }

        public ProcessAddPatientRegistration()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            _ds = new DataSet();
        }

        public void Invoke()
        {
            PatientRegistrationInsertData insert = new PatientRegistrationInsertData();
            insert.HIS_REGISTRATION = this.HIS_REGISTRATION;
            _ds = insert.Add();
        }
    }
}
