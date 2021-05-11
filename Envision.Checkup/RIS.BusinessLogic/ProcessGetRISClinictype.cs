using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISClinictype : IBusinessLogic
	{
        private RISClinictype _risclinictype;
		private DataSet result;
		public ProcessGetRISClinictype()
		{
			_risclinictype = new  RISClinictype();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISClinictypeSelectData _proc=new RISClinictypeSelectData();
			result=_proc.GetData();
		}
	}
}

