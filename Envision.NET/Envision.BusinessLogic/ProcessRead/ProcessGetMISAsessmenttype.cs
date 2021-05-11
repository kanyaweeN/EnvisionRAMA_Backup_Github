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
	public class ProcessGetMISAsessmenttype : IBusinessLogic
	{
        public MIS_ASESSMENTTYPE MIS_ASESSMENTTYPE { get; set; } 
		private DataSet result;

		public ProcessGetMISAsessmenttype()
		{
            MIS_ASESSMENTTYPE = new MIS_ASESSMENTTYPE();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			MISAsessmenttypeSelectData _proc=new MISAsessmenttypeSelectData();
            //_proc.MIS_ASESSMENTTYPE = this.MIS_ASESSMENTTYPE;
			result=_proc.GetData();
		}
	}
}

