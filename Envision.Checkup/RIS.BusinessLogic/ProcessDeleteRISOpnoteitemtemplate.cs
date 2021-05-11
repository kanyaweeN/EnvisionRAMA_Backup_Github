using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISOpnoteitemtemplate : IBusinessLogic
	{
        private SqlTransaction tran = null;
		private RISOpnoteitemtemplate _risopnoteitemtemplate;
		public ProcessDeleteRISOpnoteitemtemplate()
		{
			_risopnoteitemtemplate = new  RISOpnoteitemtemplate();
		}
        public ProcessDeleteRISOpnoteitemtemplate(SqlTransaction Transaction)
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
            RISOpnoteitemtemplateDeleteData _proc = new RISOpnoteitemtemplateDeleteData();
			_proc.RISOpnoteitemtemplate=this.RISOpnoteitemtemplate;
            if (tran == null)
            {
                _proc.Delete();
            }
            else
            {
                _proc.Delete(tran);
            }
		}
	}
}

