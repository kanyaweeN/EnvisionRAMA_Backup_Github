using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISOrder : IBusinessLogic
	{
        public RIS_ORDER RIS_ORDER { get; set; }
        public DbTransaction Transaction { get; set; }

        private int action = 0;
        private bool cancelOrder;

        public ProcessUpdateRISOrder() {
            RIS_ORDER = new RIS_ORDER();
            action = 0;
            cancelOrder = false;
        }
        public ProcessUpdateRISOrder(RIS_ORDER risOrder)
        {
            RIS_ORDER = new RIS_ORDER();
            RIS_ORDER = risOrder;
            action = 1;
            cancelOrder = false;
        }
        public ProcessUpdateRISOrder(bool useTrans)
        {
            RIS_ORDER = new RIS_ORDER();
            action = 1;
            cancelOrder = false;
        }
        public ProcessUpdateRISOrder(RIS_ORDER risOrder, bool CancelOrder)
        {
            RIS_ORDER = new RIS_ORDER();
            RIS_ORDER = risOrder;
            action = 2;
            cancelOrder = CancelOrder;
        }

		public void Invoke()
		{
            RISOrderUpdateData _proc = null;
            
            switch (action)
            {
                case 0:
                    _proc = new RISOrderUpdateData();
                    _proc.RIS_ORDER = this.RIS_ORDER;
                    break;
                case 1:
                    _proc = new RISOrderUpdateData(RIS_ORDER);
                    break;
                case 2:
                    _proc = new RISOrderUpdateData(RIS_ORDER, true);
                    break;
            }

            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
         
		}

        public void UpdateRequestResult()
        {
            RISOrderUpdateData _proc = new RISOrderUpdateData();
            _proc.RIS_ORDER = RIS_ORDER;
            _proc.UpdateRequestResult();
        }
	}
}

