using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISOpnoteitem : IBusinessLogic
	{
		private RISOpnoteitem _risopnoteitem;
		public ProcessDeleteRISOpnoteitem()
		{
			_risopnoteitem = new  RISOpnoteitem();
		}
		public RISOpnoteitem RISOpnoteitem		{
			get{return _risopnoteitem;}
			set{_risopnoteitem=value;}
		}
		public void Invoke()
		{
			RISOpnoteitemDeleteData _proc=new RISOpnoteitemDeleteData();
			_proc.RISOpnoteitem=this.RISOpnoteitem;
			_proc.Delete();
		}
	}
}

