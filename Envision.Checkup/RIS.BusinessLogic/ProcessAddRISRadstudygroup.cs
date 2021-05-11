//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/04/2009 12:35:35
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
	public class ProcessAddRISRadstudygroup : IBusinessLogic
	{
		private RISRadstudygroup _risradstudygroup;
		private bool useTran;
		public ProcessAddRISRadstudygroup()
		{
			_risradstudygroup = new  RISRadstudygroup();
			useTran=false;
		}
		public RISRadstudygroup RISRadstudygroup
		{
			get{return _risradstudygroup;}
			set{_risradstudygroup=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISRadstudygroupInsertData _proc=new RISRadstudygroupInsertData();
			_proc.RISRadstudygroup=this.RISRadstudygroup;
			useTran= useTran ? _proc.Add(useTran,true) : _proc.Add();
		}
	}
}

