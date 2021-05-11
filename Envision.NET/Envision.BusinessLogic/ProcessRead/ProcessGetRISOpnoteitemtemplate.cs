using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetRISOpnoteitemtemplate : IBusinessLogic
	{
        public RIS_OPNOTEITEMTEMPLATE RIS_OPNOTEITEMTEMPLATE { get; set; }
		private DataSet result;
		public ProcessGetRISOpnoteitemtemplate()
		{
            RIS_OPNOTEITEMTEMPLATE = new RIS_OPNOTEITEMTEMPLATE();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISOpnoteitemtemplateSelectData _proc=new RISOpnoteitemtemplateSelectData();
            _proc.RIS_OPNOTEITEMTEMPLATE = this.RIS_OPNOTEITEMTEMPLATE;
			result=_proc.GetData();
		}
	}
}

