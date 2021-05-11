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
	public class ProcessGetRISReleasemedia : IBusinessLogic
	{
        public RIS_RELEASEMEDIA RIS_RELEASEMEDIA { get; set; }
		private DataSet result;

		public ProcessGetRISReleasemedia()
		{
            RIS_RELEASEMEDIA = new RIS_RELEASEMEDIA();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISReleasemediaSelectData _proc=new RISReleasemediaSelectData();
            _proc.RIS_RELEASEMEDIA = this.RIS_RELEASEMEDIA;
			result=_proc.GetData();
		}
	}
}

