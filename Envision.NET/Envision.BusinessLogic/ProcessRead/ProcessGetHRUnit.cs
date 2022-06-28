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
	public class ProcessGetHRUnit : IBusinessLogic
	{
        public HR_UNIT HR_UNIT { get; set; }
		private DataSet result;
		public ProcessGetHRUnit()
		{
            HR_UNIT = new HR_UNIT();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			HRUnitSelectData _proc=new HRUnitSelectData();
			result=_proc.GetData();
		}
        public void InvokeCNMI()
        {
            HRUnitSelectData _proc = new HRUnitSelectData();
            result = _proc.GetDataCNMI();
        }
        public void Invoke_forAIMC()
        {
            HRUnitSelectData _proc = new HRUnitSelectData();
            result = _proc.GetData_forAIMC();
        }
        public void Invoke_forRadiologistWorklist()
        {
            HRUnitSelectData _proc = new HRUnitSelectData();
            result = _proc.GetData_forRadiologistWorklist();
        }
        public void GetData_WithUnitType()
        {
            HRUnitSelectData _proc = new HRUnitSelectData();
            result = _proc.GetData_WithUnitType();
        }
        public void GetDataByID(int unit_id)
        {
            HRUnitSelectData _proc = new HRUnitSelectData();
            result = _proc.GetDataByID(unit_id);
        }
        public void GetDataByUID(string unit_uid)
        {
            HRUnitSelectData _proc = new HRUnitSelectData();
            result = _proc.GetDataByUID(unit_uid);
        }
	}
}

