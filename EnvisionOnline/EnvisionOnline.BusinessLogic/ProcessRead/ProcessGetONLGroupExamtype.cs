using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetONLGroupExamtype: IBusinessLogic
    {
        public DataSet Result { get; set; }
        public ProcessGetONLGroupExamtype()
        {
            Result = new DataSet();
        }

        public void Invoke()
        {
            ONLGroupExamtypeSelectData get = new ONLGroupExamtypeSelectData();
            Result = get.GetData();
        }
        public void GetDataByGDeptID(int gDeptID)
        {
            ONLGroupExamtypeSelectData get = new ONLGroupExamtypeSelectData();
            Result = get.GetDataByGDeptID(gDeptID);
        }
    }
}