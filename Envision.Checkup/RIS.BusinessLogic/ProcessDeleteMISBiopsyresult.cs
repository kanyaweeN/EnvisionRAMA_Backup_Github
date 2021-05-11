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
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteMISBiopsyresult : IBusinessLogic
	{
		private MISBiopsyresult _misbiopsyresult;
		private bool useTran;
		public ProcessDeleteMISBiopsyresult()
		{
			_misbiopsyresult = new  MISBiopsyresult();
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
			MISBiopsyresultDeleteData _proc=new MISBiopsyresultDeleteData();
			_proc.MISBiopsyresult=this.MISBiopsyresult;
		    _proc.Delete();
		}
	}
}

