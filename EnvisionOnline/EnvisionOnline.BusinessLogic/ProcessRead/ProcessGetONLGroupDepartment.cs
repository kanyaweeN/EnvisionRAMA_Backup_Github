using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetONLGroupDepartment : IBusinessLogic
    {
        public DataSet Result { get; set; }
        public ProcessGetONLGroupDepartment()
        {
            Result = new DataSet();
        }

        public void Invoke()
        {
            ONLGroupDepartmentSelectData get = new ONLGroupDepartmentSelectData();
            Result = get.GetData();
        }
        public void GetDataByGDeptType(string groupDepartmentType)
        {
            ONLGroupDepartmentSelectData get = new ONLGroupDepartmentSelectData();
            Result = get.GetDataByGDeptType(groupDepartmentType);
        }
    }
}