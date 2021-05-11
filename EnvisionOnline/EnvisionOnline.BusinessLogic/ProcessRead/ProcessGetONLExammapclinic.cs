using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetONLExammapclinic : IBusinessLogic
    {
        public ONL_EXAMMAPCLINIC ONL_EXAMMAPCLINIC { get; set; }
        public DataSet Result { get; set; }
        public ProcessGetONLExammapclinic()
        {
            ONL_EXAMMAPCLINIC = new ONL_EXAMMAPCLINIC();
            Result = new DataSet();
        }

        public void Invoke()
        {

            ONLExammapclinicSelectData get = new ONLExammapclinicSelectData();
            get.ONL_EXAMMAPCLINIC = this.ONL_EXAMMAPCLINIC;
            Result = get.Get();
        }
    }
}