using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISOrderdtl : IBusinessLogic
	{
		private RISOrderdtl _risorderdtl;
        private SqlTransaction tran = null;

		public ProcessUpdateRISOrderdtl()
		{
			_risorderdtl = new RISOrderdtl();
		}

		public RISOrderdtl RISOrderdtl		{
			get{return _risorderdtl;}
			set{_risorderdtl=value;}
		}

		public void Invoke()
		{
			RISOrderdtlUpdateData _proc=new RISOrderdtlUpdateData();
			_proc.RISOrderdtl=this.RISOrderdtl;
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

        public void UpdateHL7(DataTable dtt) {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData();
            if (tran != null)
                _proc.UpdateHL7Message(tran, dtt);
            else
                _proc.UpdateHL7Message(dtt);
        }
        public void UpdateFlag(DataTable dtt,string flag) {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData();
            _proc.UpdateFlag(dtt, flag);
        }
        public void UpdateStatus() {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData(_risorderdtl);
            _proc.UpdateStatus();
        }
        public void UpdateSend() {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData(_risorderdtl);
            _proc.RISOrderdtl = _risorderdtl;
            _proc.UpdateSend();
        }
        public void UpdatePriority()
        {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData();
            _proc.RISOrderdtl = this.RISOrderdtl;
            _proc.UpdatePriority();
        }
	}
}

