using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
using System.Data.SqlClient;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISPaticd : IBusinessLogic
	{
		private RISPaticd _rispaticd;
        private SqlTransaction tran;
		public ProcessUpdateRISPaticd()
		{
			_rispaticd = new RISPaticd();
		}
		public RISPaticd RISPaticd		{
			get{return _rispaticd;}
			set{_rispaticd=value;}
		}
		public void Invoke()
		{
			RISPaticdUpdateData _proc=new RISPaticdUpdateData();
			_proc.RISPaticd=this.RISPaticd;
            if (tran == null)
                _proc.Update();
            else
                _proc.Update(tran);
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

