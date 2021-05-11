using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISOpnoteitemtemplate : IBusinessLogic
	{
        private SqlTransaction tran = null;
		private RISOpnoteitemtemplate _risopnoteitemtemplate;
		public ProcessAddRISOpnoteitemtemplate()
		{
			_risopnoteitemtemplate = new  RISOpnoteitemtemplate();
		}
        public ProcessAddRISOpnoteitemtemplate(SqlTransaction Transaction)
        {
            _risopnoteitemtemplate = new RISOpnoteitemtemplate();
            tran = Transaction;
        }
		public RISOpnoteitemtemplate RISOpnoteitemtemplate		{
			get{return _risopnoteitemtemplate;}
			set{_risopnoteitemtemplate=value;}
		}
		public void Invoke()
		{
			RISOpnoteitemtemplateInsertData _proc=new RISOpnoteitemtemplateInsertData();
			_proc.RISOpnoteitemtemplate=this.RISOpnoteitemtemplate;
            if (tran == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(tran);
            }
		}
	}
}

