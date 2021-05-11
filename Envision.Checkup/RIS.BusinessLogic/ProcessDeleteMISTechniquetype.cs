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
	public class ProcessDeleteMISTechniquetype : IBusinessLogic
	{
		private MISTechniquetype _mistechniquetype;
		private bool useTran;
		public ProcessDeleteMISTechniquetype()
		{
			_mistechniquetype = new  MISTechniquetype();
			useTran=false;
		}
		public MISTechniquetype MISTechniquetype		{
			get{return _mistechniquetype;}
			set{_mistechniquetype=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			MISTechniquetypeDeleteData _proc=new MISTechniquetypeDeleteData();
			_proc.MISTechniquetype=this.MISTechniquetype;
			useTran= useTran ? _proc.Delete(useTran,true) : _proc.Delete();
		}
	}
}

