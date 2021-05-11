//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    30/01/2552 03:44:19
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteGBLHospital : IBusinessLogic
	{
		private GBLHospital _gblhospital;
		private bool useTran;
		public ProcessDeleteGBLHospital()
		{
			_gblhospital = new  GBLHospital();
			useTran=false;
		}
		public GBLHospital GBLHospital		{
			get{return _gblhospital;}
			set{_gblhospital=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			GBLHospitalDeleteData _proc=new GBLHospitalDeleteData();
			_proc.GBLHospital=this.GBLHospital;
            _proc.Delete();
		}
        public bool DeleteMapping(int HOSID) {
            GBLHospitalDeleteData _proc = new GBLHospitalDeleteData();
            return _proc.DeleteMapping(HOSID);
        }
	}
}

