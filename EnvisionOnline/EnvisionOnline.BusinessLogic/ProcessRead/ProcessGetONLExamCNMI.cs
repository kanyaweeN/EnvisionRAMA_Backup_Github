using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetONLExamCNMI
    {
        public DataSet Result { get; set; }
        public ProcessGetONLExamCNMI()
        {
            Result = new DataSet();
        }

        public void Invoke(int exam_id)
        {

            ONLExamCNMISelectData get = new ONLExamCNMISelectData();
            Result = get.Get(exam_id);
        }
    }
}
