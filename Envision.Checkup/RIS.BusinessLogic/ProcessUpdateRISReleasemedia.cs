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
	public class ProcessUpdateRISReleasemedia : IBusinessLogic
	{
		private RISReleasemedia _risreleasemedia;
		private bool useTran;
		public ProcessUpdateRISReleasemedia()
		{
			_risreleasemedia = new RISReleasemedia();
			useTran=false;
		}
		public RISReleasemedia RISReleasemedia		{
			get{return _risreleasemedia;}
			set{_risreleasemedia=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISReleasemediaUpdateData _proc=new RISReleasemediaUpdateData();
			_proc.RISReleasemedia=this.RISReleasemedia;
			_proc.Update();
		}
	}
}

