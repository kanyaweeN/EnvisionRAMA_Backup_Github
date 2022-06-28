using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLEmployee
    {
        public HR_EMP GBLEmployee { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteGBLEmployee()
        {
            GBLEmployee = new HR_EMP();
            Transaction = null;
        }

        public void Invoke()
        {
            GBLEmployeeDeleteData gbldata = new GBLEmployeeDeleteData();
            gbldata.HR_EMP = GBLEmployee;
            gbldata.Delete();
        }
    }
}
