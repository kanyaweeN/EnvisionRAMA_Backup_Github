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
	public class ProcessUpdateMISBiopsyresult : IBusinessLogic
	{
		private MISBiopsyresult _misbiopsyresult;
		private bool useTran;
		public ProcessUpdateMISBiopsyresult()
		{
			_misbiopsyresult = new MISBiopsyresult();
			useTran=false;
		}
		public MISBiopsyresult MISBiopsyresult		{
			get{return _misbiopsyresult;}
			set{_misbiopsyresult=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			MISBiopsyresultUpdateData _proc=new MISBiopsyresultUpdateData();
			_proc.MISBiopsyresult=this.MISBiopsyresult;
		    _proc.Update();
		}
	}
}

