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
	public class ProcessGetRISUserorgmap : IBusinessLogic
	{
        public RIS_USERORGMAP RIS_USERORGMAP { get; set; }
		private DataSet result;

		public ProcessGetRISUserorgmap()
		{
            RIS_USERORGMAP = new RIS_USERORGMAP();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISUserorgmapSelectData _proc=new RISUserorgmapSelectData();
            _proc.RIS_USERORGMAP = this.RIS_USERORGMAP;
			result=_proc.GetData();
		}
	}
}

