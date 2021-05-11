using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISOpnoteitem : IBusinessLogic
	{
		private RISOpnoteitem _risopnoteitem;
		public ProcessUpdateRISOpnoteitem()
		{
			_risopnoteitem = new RISOpnoteitem();
		}
		public RISOpnoteitem RISOpnoteitem		{
			get{return _risopnoteitem;}
			set{_risopnoteitem=value;}
		}
		public void Invoke()
		{
			RISOpnoteitemUpdateData _proc=new RISOpnoteitemUpdateData();
			_proc.RISOpnoteitem=this.RISOpnoteitem;
			_proc.Update();
		}
	}
}

