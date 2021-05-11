//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    27/04/2009 08:46:09
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
	public class ProcessAddRISModalityclinictype : IBusinessLogic
	{
		private RISModalityclinictype _rismodalityclinictype;
		private bool useTran;
		public ProcessAddRISModalityclinictype()
		{
			_rismodalityclinictype = new  RISModalityclinictype();
			useTran=false;
		}
		public RISModalityclinictype RISModalityclinictype
		{
			get{return _rismodalityclinictype;}
			set{_rismodalityclinictype=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISModalityclinictypeInsertData _proc=new RISModalityclinictypeInsertData();
			_proc.RISModalityclinictype=this.RISModalityclinictype;
			useTran= useTran ? _proc.Add(useTran,true) : _proc.Add();
		}
	}
}

