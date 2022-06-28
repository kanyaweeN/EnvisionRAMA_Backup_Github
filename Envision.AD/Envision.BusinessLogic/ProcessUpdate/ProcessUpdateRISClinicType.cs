using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISClinicType: IBusinessLogic
    {
        public RIS_CLINICTYPE RIS_CLINICTYPE { get; set; }

        public ProcessUpdateRISClinicType()
        {
            RIS_CLINICTYPE = new RIS_CLINICTYPE();
        }
        public void Invoke()
        {
           
        }
        public void UpdateByAccession(string accession, int clinic_type, int last_modified_by)
        {
            RISClinicTypeUpdateData proc = new RISClinicTypeUpdateData();
            proc.RIS_CLINICTYPE = this.RIS_CLINICTYPE;
            proc.UpdateByAccession(accession, clinic_type, last_modified_by);
        }

    }
}