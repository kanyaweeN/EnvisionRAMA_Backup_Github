using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetPatientRegistration : IBusinessLogic
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }
        DataSet _dataResult;

        public ProcessGetPatientRegistration()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();    
        }

        public void Invoke()
        {
            PatientRegistrationSelectData select = new PatientRegistrationSelectData();
            select.HIS_REGISTRATION = this.HIS_REGISTRATION;
            DataResult = select.Get();
        }

        public DataSet DataResult
        {
            get { return _dataResult; }
            set { _dataResult = value; }
        }
    }
}
