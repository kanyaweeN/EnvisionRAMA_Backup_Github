//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    27/04/2009 08:46:10
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
	public class ProcessUpdateRISModalityclinictype : IBusinessLogic
	{
		private RISModalityclinictype _rismodalityclinictype;
		private bool useTran;
		public ProcessUpdateRISModalityclinictype()
		{
			_rismodalityclinictype = new RISModalityclinictype();
			useTran=false;
		}
		public RISModalityclinictype RISModalityclinictype		{
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
			RISModalityclinictypeUpdateData _proc=new RISModalityclinictypeUpdateData();
			_proc.RISModalityclinictype=this.RISModalityclinictype;
			useTran= useTran ?_proc.Update(useTran,true):_proc.Update();
		}
	}
}

