using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetINVPo : IBusinessLogic
	{
        public INV_PO INV_PO { get; set; }
		private DataSet result;

		public ProcessGetINVPo()
		{
            INV_PO = new INV_PO();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVPoSelectData _proc=new INVPoSelectData();
            _proc.INV_PO = this.INV_PO;
			result=_proc.GetData();
		}
        public DataSet SelectAll()
        {
            INVPoSelectData _proc = new INVPoSelectData();
            return _proc.SelectAll();
        }
        public DataSet SelectForRecieve()
        {
            INVPoSelectData _proc = new INVPoSelectData();
            return _proc.SelectForRecieve();
        }
        public DataSet GetPOMaster(int PO_ID)
        {
            INVPoSelectData _proc = new INVPoSelectData();
            return _proc.GetPOMaster(PO_ID);
        }
        public DataSet GetPODetail(int PO_ID)
        {
            INVPoSelectData _proc = new INVPoSelectData();
            return _proc.GetPODetail(PO_ID);
        }
	}
}

