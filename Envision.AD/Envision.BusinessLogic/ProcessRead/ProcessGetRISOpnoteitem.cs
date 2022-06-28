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
	public class ProcessGetRISOpnoteitem : IBusinessLogic
	{
        public RIS_OPNOTEITEM RIS_OPNOTEITEM { get; set; }
		private DataSet result;

		public ProcessGetRISOpnoteitem()
		{
            RIS_OPNOTEITEM = new RIS_OPNOTEITEM();
            RIS_OPNOTEITEM.OP_ITEM_ID = 0; //set default
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISOpnoteitemSelectData _proc=new RISOpnoteitemSelectData();
            _proc.RIS_OPNOTEITEM = RIS_OPNOTEITEM;
			result=_proc.GetData();
		}
	}
}

