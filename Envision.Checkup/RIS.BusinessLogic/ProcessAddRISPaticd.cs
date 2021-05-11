using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISPaticd : IBusinessLogic
	{
		private RISPaticd _rispaticd;
        private SqlTransaction tran;
		public ProcessAddRISPaticd()
		{
			_rispaticd = new  RISPaticd();
		}
		public RISPaticd RISPaticd		{
			get{return _rispaticd;}
			set{_rispaticd=value;}
		}
		public void Invoke()
		{
			RISPaticdInsertData _proc=new RISPaticdInsertData();
			_proc.RISPaticd=this.RISPaticd;
            if (tran == null)
                _proc.Add();
            else
                _rispaticd.PAT_ICD_ID = _proc.Add(tran);
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

