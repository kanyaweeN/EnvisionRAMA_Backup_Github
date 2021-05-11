//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    18/06/2009 04:37:11
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
	public class ProcessDeleteHREmp : IBusinessLogic
	{
		private HREmp _hremp;
		private bool useTran;
		public ProcessDeleteHREmp()
		{
			_hremp = new  HREmp();
			useTran=false;
		}
		public HREmp HREmp		{
			get{return _hremp;}
			set{_hremp=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			HREmpDeleteData _proc=new HREmpDeleteData();
			_proc.HREmp=this.HREmp;
			useTran= useTran ? _proc.Delete(useTran,true) : _proc.Delete();
		}
	}
}

