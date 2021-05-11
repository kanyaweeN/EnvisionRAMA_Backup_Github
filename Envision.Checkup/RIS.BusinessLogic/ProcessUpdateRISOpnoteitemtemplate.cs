using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISOpnoteitemtemplate : IBusinessLogic
	{
		private RISOpnoteitemtemplate _risopnoteitemtemplate;
		public ProcessUpdateRISOpnoteitemtemplate()
		{
			_risopnoteitemtemplate = new RISOpnoteitemtemplate();
		}
		public RISOpnoteitemtemplate RISOpnoteitemtemplate		{
			get{return _risopnoteitemtemplate;}
			set{_risopnoteitemtemplate=value;}
		}
		public void Invoke()
		{
			RISOpnoteitemtemplateUpdateData _proc=new RISOpnoteitemtemplateUpdateData();
			_proc.RISOpnoteitemtemplate=this.RISOpnoteitemtemplate;
			_proc.Update();
		}
	}
}

