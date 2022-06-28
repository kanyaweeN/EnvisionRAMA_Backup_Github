using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdatePatientRegistration : IBusinessLogic
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }
        public DataSet ResultSet { get; set; }

        public ProcessUpdatePatientRegistration()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            ResultSet = new DataSet();
        }

        public void Invoke()
        {
            PatientRegistrationUpdateData update = new PatientRegistrationUpdateData();
            update.HIS_REGISTRATION = this.HIS_REGISTRATION;
            ResultSet = update.Update();
        }
    }
}
