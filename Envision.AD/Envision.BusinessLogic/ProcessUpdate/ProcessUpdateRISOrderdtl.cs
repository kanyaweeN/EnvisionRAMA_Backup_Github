using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISOrderdtl : IBusinessLogic
	{
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateRISOrderdtl()
		{
            RIS_ORDERDTL = new RIS_ORDERDTL();
            Transaction = null;
		}

		public void Invoke()
		{
			RISOrderdtlUpdateData _proc=new RISOrderdtlUpdateData();
            _proc.RIS_ORDERDTL = this.RIS_ORDERDTL;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}

        public void UpdateHL7(DataTable dtt) {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData();
            if (Transaction != null)
                _proc.UpdateHL7Message(Transaction, dtt);
            else
                _proc.UpdateHL7Message(dtt);
        }
        public void UpdateFlag(DataTable dtt,string flag) {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData();
            _proc.UpdateFlag(dtt, flag);
        }
        public void UpdateStatus() {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData(RIS_ORDERDTL);
            _proc.UpdateStatus();
        }
        public void UpdateSend() {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData(RIS_ORDERDTL);
            _proc.RIS_ORDERDTL = RIS_ORDERDTL;
            _proc.UpdateSend();
        }
        public void UpdateIsDeleted()
        {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData();
            _proc.RIS_ORDERDTL = this.RIS_ORDERDTL;
            _proc.UpdateIsDeleted();
        }
        public void UpdatePriority()
        {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData();
            _proc.RIS_ORDERDTL = this.RIS_ORDERDTL;
            _proc.UpdatePriority();
        }
        public void UpdateIsDF(string is_df,string accession_no,int emp_id)
        {
            RISOrderdtlUpdateData _proc = new RISOrderdtlUpdateData();
            _proc.UpdateIsDF(is_df, accession_no,emp_id);
        }
	}
}

