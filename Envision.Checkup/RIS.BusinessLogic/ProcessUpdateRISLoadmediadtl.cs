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
	public class ProcessUpdateRISLoadmediadtl : IBusinessLogic
	{
		private RISLoadmediadtl _risloadmediadtl;
		private bool useTran;
		public ProcessUpdateRISLoadmediadtl()
		{
			_risloadmediadtl = new RISLoadmediadtl();
			useTran=false;
		}
		public RISLoadmediadtl RISLoadmediadtl		{
			get{return _risloadmediadtl;}
			set{_risloadmediadtl=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISLoadmediadtlUpdateData _proc=new RISLoadmediadtlUpdateData();
			_proc.RISLoadmediadtl=this.RISLoadmediadtl;
			/*useTran= useTran ?_proc.Update(useTran,true):*/_proc.Update();
		}
	}
}

