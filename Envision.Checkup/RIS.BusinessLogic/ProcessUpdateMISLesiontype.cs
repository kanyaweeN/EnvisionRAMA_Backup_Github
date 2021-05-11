//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:24
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
	public class ProcessUpdateMISLesiontype : IBusinessLogic
	{
		private MISLesiontype _mislesiontype;
		private bool useTran;
		public ProcessUpdateMISLesiontype()
		{
			_mislesiontype = new MISLesiontype();
			useTran=false;
		}
		public MISLesiontype MISLesiontype		{
			get{return _mislesiontype;}
			set{_mislesiontype=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			MISLesiontypeUpdateData _proc=new MISLesiontypeUpdateData();
			_proc.MISLesiontype=this.MISLesiontype;
			useTran= useTran ?_proc.Update(useTran,true):_proc.Update();
		}
	}
}

