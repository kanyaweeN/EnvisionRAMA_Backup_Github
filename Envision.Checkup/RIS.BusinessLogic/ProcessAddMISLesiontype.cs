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
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddMISLesiontype : IBusinessLogic
	{
		private MISLesiontype _mislesiontype;
		private bool useTran;
		public ProcessAddMISLesiontype()
		{
			_mislesiontype = new  MISLesiontype();
			useTran=false;
		}
		public MISLesiontype MISLesiontype
		{
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
			MISLesiontypeInsertData _proc=new MISLesiontypeInsertData();
			_proc.MISLesiontype=this.MISLesiontype;
			useTran= useTran ? _proc.Add(useTran,true) : _proc.Add();
		}
	}
}

