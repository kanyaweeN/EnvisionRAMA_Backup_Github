using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISOpnoteitemtemplate : IBusinessLogic
	{
		private DataSet result;
		private RISOpnoteitemtemplate _risopnoteitemtemplate;
        public RISOpnoteitemtemplate RISOpnoteitemtemplate
        {
            get { return _risopnoteitemtemplate; }
            set { _risopnoteitemtemplate = value; }
        }
		public ProcessGetRISOpnoteitemtemplate()
		{
			_risopnoteitemtemplate = new  RISOpnoteitemtemplate();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISOpnoteitemtemplateSelectData _proc=new RISOpnoteitemtemplateSelectData();
            _proc.RISOpnoteitemtemplate = this._risopnoteitemtemplate;
			result=_proc.GetData();
		}
	}
}

