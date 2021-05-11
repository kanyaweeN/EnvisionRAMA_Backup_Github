using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISClinictype : IBusinessLogic
    {
        public RIS_CLINICTYPE RIS_CLINICTYPE { get; set; }
        private DataSet result;
        public ProcessGetRISClinictype()
        {
            RIS_CLINICTYPE = new RIS_CLINICTYPE();
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISClinictypeSelectData _proc = new RISClinictypeSelectData();
            result = _proc.GetData();
        }
    }
}
