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
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			HREmpSelectData _proc=new HREmpSelectData();
            _proc.HR_EMP = this.HR_EMP;
			result=_proc.GetData();
		}
        public void InvokeLite()
        {
            HREmpSelectData _prc = new HREmpSelectData();
            _prc.HR_EMP = this.HR_EMP;

            Result = _prc.GetDateLite();
        }
        public DataTable GetEmployee() {
            HREmpSelectData _prc = new HREmpSelectData();
            _prc.HR_EMP = this.HR_EMP;

            return _prc.GetEmpData();
        }
	}
}

