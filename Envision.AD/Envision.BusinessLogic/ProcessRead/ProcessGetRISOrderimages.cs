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
        public DataTable GetDataByID() {
            RISOrderimagesSelectData _proc = new RISOrderimagesSelectData();
            _proc.RIS_ORDERIMAGE = RIS_ORDERIMAGE;
            return _proc.GetDataByID();
        }
	}
}

