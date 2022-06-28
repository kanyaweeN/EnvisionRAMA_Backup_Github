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
	public class ProcessGetMISLesiontype : IBusinessLogic
	{
        public MIS_LESIONTYPE MIS_LESIONTYPE { get; set; }
		private DataSet result;

		public ProcessGetMISLesiontype()
		{
            MIS_LESIONTYPE = new MIS_LESIONTYPE();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			MISLesiontypeSelectData _proc=new MISLesiontypeSelectData();
            //_proc.MIS_LESIONTYPE = this.MIS_LESIONTYPE;
			result=_proc.GetData();
		}
	}
}

