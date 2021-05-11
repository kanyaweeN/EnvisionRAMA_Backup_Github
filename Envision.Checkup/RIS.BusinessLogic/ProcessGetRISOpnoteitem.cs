using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISOpnoteitem : IBusinessLogic
	{
		private DataSet result;
		private RISOpnoteitem _risopnoteitem;
		public ProcessGetRISOpnoteitem()
		{
			_risopnoteitem = new  RISOpnoteitem();
            _risopnoteitem.OP_ITEM_ID = 0; //set default
		}
        public RISOpnoteitem RISOpnoteitem
        {
            get { return _risopnoteitem; }
            set { _risopnoteitem = value; }
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISOpnoteitemSelectData _proc=new RISOpnoteitemSelectData();
            _proc.RISOpnoteitem = _risopnoteitem;
			result=_proc.GetData();
		}
	}
}

