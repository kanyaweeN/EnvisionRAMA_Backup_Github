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
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISLoadmedia : IBusinessLogic
	{
		private RISLoadmedia _risloadmedia;
		private bool useTran;
		public ProcessDeleteRISLoadmedia()
		{
			_risloadmedia = new  RISLoadmedia();
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
			RISLoadmediaDeleteData _proc=new RISLoadmediaDeleteData();
			_proc.RISLoadmedia=this.RISLoadmedia;
			 _proc.Delete();
		}
	}
}

