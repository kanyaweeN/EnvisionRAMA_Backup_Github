using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteFINPayment : IBusinessLogic
	{

        public FIN_PAYMENT FIN_PAYMENT { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteFINPayment()
		{
            FIN_PAYMENT = new FIN_PAYMENT();
            Transaction = null;
        }
		public void Invoke()
		{
            FIN_PAYMENTDeleteData _proc = new FIN_PAYMENTDeleteData();
            _proc.FIN_PAYMENT = FIN_PAYMENT;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

