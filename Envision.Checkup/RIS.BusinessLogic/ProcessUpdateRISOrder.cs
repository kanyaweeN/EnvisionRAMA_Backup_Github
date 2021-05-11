using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISOrder : IBusinessLogic
	{
		private RISOrder _risorder;
        private SqlTransaction tran;
        private int action = 0;
        private bool cancelOrder;

        public ProcessUpdateRISOrder() {
            _risorder = new RISOrder();
            action = 0;
            cancelOrder = false;
        }
		public ProcessUpdateRISOrder(RISOrder risOrder){
            _risorder = risOrder;
            action = 1;
            cancelOrder = false;
        }
        public ProcessUpdateRISOrder(bool useTrans)
        {
            _risorder = new RISOrder();
            action = 1;
            cancelOrder = false;
        }
        public ProcessUpdateRISOrder(RISOrder risOrder, bool CancelOrder)
        {
            _risorder = risOrder;
            action = 2;
            cancelOrder = CancelOrder;
        }

		public RISOrder RISOrder{
			get{return _risorder;}
			set{_risorder=value;}
		}

		public void Invoke()
		{
            RISOrderUpdateData _proc = null;
            
            switch (action)
            {
                case 0:
                    _proc = new RISOrderUpdateData();
                    _proc.RISOrder=this.RISOrder;
                    break;
                case 1:
                    _proc = new RISOrderUpdateData(RISOrder);
                    break;
                case 2:
                    _proc = new RISOrderUpdateData(RISOrder,true);
                    break;
            }
           
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

