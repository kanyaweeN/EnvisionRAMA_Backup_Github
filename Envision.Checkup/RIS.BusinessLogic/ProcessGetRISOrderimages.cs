using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISOrderimages : IBusinessLogic
	{
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }
		private DataSet result;
		public ProcessGetRISOrderimages()
		{
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}

		public void Invoke()
		{
			RISOrderimagesSelectData _proc=new RISOrderimagesSelectData();
            _proc.RIS_ORDERIMAGE = RIS_ORDERIMAGE;
			result=_proc.GetData();
		}
	}
}

