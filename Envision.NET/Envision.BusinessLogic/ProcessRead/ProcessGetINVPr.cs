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
	public class ProcessGetINVPr : IBusinessLogic
	{
        public INV_PR INV_PR { get; set; }
		private DataSet result;

		public ProcessGetINVPr()
		{
            INV_PR = new INV_PR();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVPrSelectData _proc=new INVPrSelectData();
            _proc.INV_PR = this.INV_PR;
			result=_proc.GetData();
		}
        public DataSet SelectAll()
        {
            INVPrSelectData _proc = new INVPrSelectData();
            return _proc.SelectAll();
        }
	}
}

