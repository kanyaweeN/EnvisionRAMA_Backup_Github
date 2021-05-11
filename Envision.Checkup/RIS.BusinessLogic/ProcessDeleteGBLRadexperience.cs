//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2009 05:03:16
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
	public class ProcessDeleteGBLRadexperience : IBusinessLogic
	{
		private GBLRadexperience _gblradexperience;
		private bool useTran;
		public ProcessDeleteGBLRadexperience()
		{
			_gblradexperience = new  GBLRadexperience();
			useTran=false;
		}
		public GBLRadexperience GBLRadexperience		{
			get{return _gblradexperience;}
			set{_gblradexperience=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			GBLRadexperienceDeleteData _proc=new GBLRadexperienceDeleteData();
			_proc.GBLRadexperience=this.GBLRadexperience;
			useTran= useTran ? _proc.Delete(useTran,true) : _proc.Delete();
		}
	}
}

