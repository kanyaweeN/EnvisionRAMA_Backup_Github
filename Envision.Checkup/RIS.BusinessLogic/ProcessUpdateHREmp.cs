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
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateHREmp : IBusinessLogic
	{
		private HREmp _hremp;
		private bool useTran;
		public ProcessUpdateHREmp()
		{
			_hremp = new HREmp();
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
			HREmpUpdateData _proc=new HREmpUpdateData();
			_proc.HREmp=this.HREmp;
			useTran= useTran ?_proc.Update(useTran,true):_proc.Update();
		}
	}
}

