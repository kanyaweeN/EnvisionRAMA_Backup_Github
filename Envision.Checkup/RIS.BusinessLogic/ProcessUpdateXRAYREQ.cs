using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateXRAYREQ : IBusinessLogic
	{
		private XRAYREQ _xrayreq;
        private SqlTransaction tran;

		public ProcessUpdateXRAYREQ()
		{
			_xrayreq = new XRAYREQ();
		}
		public XRAYREQ XRAYREQ		{
			get{return _xrayreq;}
			set{_xrayreq=value;}
		}
		public void Invoke()
		{
			XRAYREQUpdateData _proc=new XRAYREQUpdateData();
			_proc.XRAYREQ=this.XRAYREQ;
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

