using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeletePatient : IBusinessLogic
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeletePatient()
        {
            RIS_PATSTATUS = new RIS_PATSTATUS();
            Transaction = null;
        }

        public void Invoke()
        {
            PatientDeleteData patientdata = new PatientDeleteData();
            patientdata.RIS_PATSTATUS = this.RIS_PATSTATUS;
            patientdata.Delete();
        }
    }
}
