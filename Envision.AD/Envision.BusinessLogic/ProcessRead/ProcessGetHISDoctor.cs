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
        public void getDataByID(int emp_id)
        {
            HISDoctorSelectData _proc = new HISDoctorSelectData();
            result = _proc.GetDataByID(emp_id);
        }
	}
}

