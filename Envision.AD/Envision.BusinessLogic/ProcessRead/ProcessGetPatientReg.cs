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
    public class ProcessGetPatientReg : IBusinessLogic
    {
        private string _patreg;
        public DataSet _resultset;

        public ProcessGetPatientReg(string patreg)
        {
            _patreg = patreg;
        }

        public void Invoke()
        {
            PatientRegSelectData envdata = new PatientRegSelectData();
            ResultSet = envdata.Get(_patreg);
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }



    }
}
