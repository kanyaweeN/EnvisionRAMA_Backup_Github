using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetONLClinicsession : IBusinessLogic
    {
        private DataSet result;
        private int action;
        private int modalityID;

        public ProcessGetONLClinicsession()
        {
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            ONLClinicsessionSelectData _proc = new ONLClinicsessionSelectData();
            result = _proc.GetData();
        }
    }
}
