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
	public class ProcessGetMISTechniquetype : IBusinessLogic
	{
        public MIS_TECHNIQUETYPE MIS_TECHNIQUETYPE { get; set; }
		private DataSet result;

		public ProcessGetMISTechniquetype()
		{
            MIS_TECHNIQUETYPE = new MIS_TECHNIQUETYPE();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			MISTechniquetypeSelectData _proc=new MISTechniquetypeSelectData();
            //_proc.MIS_TECHNIQUETYPE = this.MIS_TECHNIQUETYPE;
			result=_proc.GetData();
		}
	}
}

