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
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddGBLHospital : IBusinessLogic
	{
		private GBLHospital _gblhospital;
		private bool useTran;
		public ProcessAddGBLHospital()
		{
			_gblhospital = new  GBLHospital();
			useTran=false;
		}
		public GBLHospital GBLHospital
		{
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
			GBLHospitalInsertData _proc=new GBLHospitalInsertData();
			_proc.GBLHospital=this.GBLHospital;
            _proc.Add();
		}
        public void Mapping() {
            GBLHospitalInsertData _proc = new GBLHospitalInsertData();
            _proc.GBLHospital = this.GBLHospital;
            _proc.Mapping();
        }
	}
}

