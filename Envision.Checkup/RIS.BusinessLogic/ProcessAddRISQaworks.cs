using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISQaworks : IBusinessLogic
	{
		private RISQaworks _risqaworks;
		public ProcessAddRISQaworks()
		{
			_risqaworks = new  RISQaworks();
		}
		public RISQaworks RISQaworks		{
			get{return _risqaworks;}
			set{_risqaworks=value;}
		}
		public void Invoke()
		{
			RISQaworksInsertData _proc=new RISQaworksInsertData();
			_proc.RISQaworks=this.RISQaworks;
			_proc.Add();
		}
	}
}

