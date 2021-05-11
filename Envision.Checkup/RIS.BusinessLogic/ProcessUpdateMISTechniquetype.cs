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
	public class ProcessUpdateMISTechniquetype : IBusinessLogic
	{
		private MISTechniquetype _mistechniquetype;
		private bool useTran;
		public ProcessUpdateMISTechniquetype()
		{
			_mistechniquetype = new MISTechniquetype();
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
			MISTechniquetypeUpdateData _proc=new MISTechniquetypeUpdateData();
			_proc.MISTechniquetype=this.MISTechniquetype;
			useTran= useTran ?_proc.Update(useTran,true):_proc.Update();
		}
	}
}

