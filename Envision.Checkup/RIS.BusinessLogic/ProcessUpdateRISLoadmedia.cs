//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:27
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
	public class ProcessUpdateRISLoadmedia : IBusinessLogic
	{
		private RISLoadmedia _risloadmedia;
		private bool useTran;
		public ProcessUpdateRISLoadmedia()
		{
			_risloadmedia = new RISLoadmedia();
			useTran=false;
		}
		public RISLoadmedia RISLoadmedia		{
			get{return _risloadmedia;}
			set{_risloadmedia=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISLoadmediaUpdateData _proc=new RISLoadmediaUpdateData();
			_proc.RISLoadmedia=this.RISLoadmedia;
			_proc.Update();
		}
	}
}

