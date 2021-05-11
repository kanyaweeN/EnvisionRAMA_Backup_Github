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
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateGBLHospital : IBusinessLogic
	{
		private GBLHospital _gblhospital;
		private bool useTran;
		public ProcessUpdateGBLHospital()
		{
			_gblhospital = new GBLHospital();
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
			GBLHospitalUpdateData _proc=new GBLHospitalUpdateData();
			_proc.GBLHospital=this.GBLHospital;
			//useTran= useTran ?_proc.Update(useTran,true):_proc.Update();
            _proc.Update();
		}
	}
}

