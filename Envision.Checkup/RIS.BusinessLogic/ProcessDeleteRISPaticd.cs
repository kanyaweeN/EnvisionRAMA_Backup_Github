using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISPaticd : IBusinessLogic
	{
		private RISPaticd _rispaticd;
        private SqlTransaction tran;

		public ProcessDeleteRISPaticd()
		{
			_rispaticd = new  RISPaticd();
		}
		public RISPaticd RISPaticd		{
			get{return _rispaticd;}
			set{_rispaticd=value;}
		}
		public void Invoke()
		{
			RISPaticdDeleteData _proc=new RISPaticdDeleteData();
			_proc.RISPaticd=this.RISPaticd;
            if (tran == null)
                _proc.Delete();
            else
                _proc.Delete(tran);
		}
        public SqlTransaction UseTransaction
        {
            set
            {
                tran = value;
            }
        }
	}
}

