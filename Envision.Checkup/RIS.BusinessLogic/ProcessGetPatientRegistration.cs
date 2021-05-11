using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetPatientRegistration : IBusinessLogic
    {
        DataSet _dataResult;
        HISRegistration _hisRegistration;

        public ProcessGetPatientRegistration()
        {        
        }

        public void Invoke()
        {
            PatientRegistrationSelectData select = new PatientRegistrationSelectData();
            select.HISRegistration = this.HISRegistration;
            DataResult = select.Get();
        }

        public DataSet DataResult
        {
            get { return _dataResult; }
            set { _dataResult = value; }
        }

        public HISRegistration HISRegistration
        {
            get { return _hisRegistration; }
            set { _hisRegistration = value; }
        }
    }
}
