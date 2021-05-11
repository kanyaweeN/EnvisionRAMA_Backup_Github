using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetHISDoctor : IBusinessLogic
	{
		private DataSet result;
        HISDoctor _hisdoctor;
		public ProcessGetHISDoctor()
		{
			_hisdoctor = new  HISDoctor();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			HISDoctorSelectData _proc=new HISDoctorSelectData();
			result=_proc.GetData();
		}
	}
}

