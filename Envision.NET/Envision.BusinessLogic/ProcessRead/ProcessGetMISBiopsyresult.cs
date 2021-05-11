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
	public class ProcessGetMISBiopsyresult : IBusinessLogic
	{
        public MIS_BIOPSYRESULT MIS_BIOPSYRESULT { get; set; }
		private DataSet result;

		public ProcessGetMISBiopsyresult()
		{
            MIS_BIOPSYRESULT = new MIS_BIOPSYRESULT();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			MISBiopsyresultSelectData _proc=new MISBiopsyresultSelectData();
            _proc.MIS_BIOPSYRESULT = this.MIS_BIOPSYRESULT;
			result=_proc.GetData();
		}
	}
}

