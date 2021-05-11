using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISOpnoteitem : IBusinessLogic
	{
		private RISOpnoteitem _risopnoteitem;
		public ProcessAddRISOpnoteitem()
		{
			_risopnoteitem = new  RISOpnoteitem();
		}
		public RISOpnoteitem RISOpnoteitem		{
			get{return _risopnoteitem;}
			set{_risopnoteitem=value;}
		}
		public void Invoke()
		{
			RISOpnoteitemInsertData _proc=new RISOpnoteitemInsertData();
			_proc.RISOpnoteitem=this.RISOpnoteitem;
			_proc.Add();
		}
	}
}

