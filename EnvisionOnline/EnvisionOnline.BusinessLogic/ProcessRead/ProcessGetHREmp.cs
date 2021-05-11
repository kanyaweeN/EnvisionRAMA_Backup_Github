using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetHREmp : IBusinessLogic
    {
        public HR_EMP HR_EMP { get; set; }
        private DataSet result;
        public ProcessGetHREmp()
        {
            HR_EMP = new HR_EMP();
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            HREmpSelectData _proc = new HREmpSelectData();
            _proc.HR_EMP = this.HR_EMP;
            result = _proc.GetData();
        }
        public void InvokeLite()
        {
            HREmpSelectData _prc = new HREmpSelectData();
            _prc.HR_EMP = this.HR_EMP;

            Result = _prc.GetDateLite();
        }
        public void checkUser()
        {
            HREmpSelectData _proc = new HREmpSelectData();
            _proc.HR_EMP = this.HR_EMP;
            result = _proc.checkData();
        }
    }
}
