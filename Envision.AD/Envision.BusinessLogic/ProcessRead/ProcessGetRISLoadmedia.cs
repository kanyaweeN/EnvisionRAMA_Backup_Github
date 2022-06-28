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
	public class ProcessGetRISLoadmedia : IBusinessLogic
	{
        public RIS_LOADMEDIA RIS_LOADMEDIA { get; set; }
		private DataSet result;

		public ProcessGetRISLoadmedia()
		{
            RIS_LOADMEDIA = new RIS_LOADMEDIA();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISLoadmediaSelectData _proc=new RISLoadmediaSelectData();
            _proc.RIS_LOADMEDIA = this.RIS_LOADMEDIA;
			result=_proc.GetData();
		}
	}
}

