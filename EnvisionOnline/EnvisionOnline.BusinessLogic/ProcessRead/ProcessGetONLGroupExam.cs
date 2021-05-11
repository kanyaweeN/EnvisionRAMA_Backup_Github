using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetONLGroupExam : IBusinessLogic
    {
        public DataSet Result { get; set; }
        public ProcessGetONLGroupExam()
        {
            Result = new DataSet();
        }

        public void Invoke()
        {
            ONLGroupExamSelectData get = new ONLGroupExamSelectData();
            Result = get.GetData();
        }
        public void GetDataByGTypeID(int GTypeID)
        {
            ONLGroupExamSelectData get = new ONLGroupExamSelectData();
            Result = get.GetDataByGTypeID(GTypeID);
        }
    }
}
