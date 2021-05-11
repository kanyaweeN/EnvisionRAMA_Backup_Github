using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetXRAYREQ : IBusinessLogic
	{
		private DataSet result;
        private XRAYREQ _xrayreq;

        
        private int sptype;

		public ProcessGetXRAYREQ()
		{
			_xrayreq = new  XRAYREQ();
		}

		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
        public int StoreType {
            get { return sptype; }
            set { sptype = value; }
        }
        public XRAYREQ XRAYREQ
        {
            get { return _xrayreq; }
            set { _xrayreq = value; }
        }
		public void Invoke()
		{
			XRAYREQSelectData _proc=new XRAYREQSelectData();
            _proc.XRAYREQ = XRAYREQ;
            result = _proc.GetData(sptype);
		}
	}
}

