using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeletePatientRegistration
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeletePatientRegistration()
        {
            HIS_REGISTRATION=new HIS_REGISTRATION();
            Transaction=null;
        }

        public void Invoke()
        {
            PatientRegistrationDeleteData update = new PatientRegistrationDeleteData();
            update.HIS_REGISTRATION = HIS_REGISTRATION;
            update.Delete();
        }
    }
}
