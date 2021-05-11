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
	public class ProcessGetRISModalityclinictype : IBusinessLogic
	{
        public RIS_MODALITYCLINICTYPE RIS_MODALITYCLINICTYPE { get; set; }
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
		private DataSet result;

		public ProcessGetRISModalityclinictype()
		{
            RIS_MODALITYCLINICTYPE = new RIS_MODALITYCLINICTYPE();
            RIS_SCHEDULE = new RIS_SCHEDULE();
		}
        public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		
        public void Invoke()
		{
			RISModalityclinictypeSelectData _proc=new RISModalityclinictypeSelectData();
            _proc.RIS_MODALITYCLINICTYPE = this.RIS_MODALITYCLINICTYPE;
			result=_proc.GetExamClinicType();
		}

        public void Invoke(int mode)
        {
            RISModalityclinictypeSelectData _proc = new RISModalityclinictypeSelectData();
            _proc.RIS_MODALITYCLINICTYPE = this.RIS_MODALITYCLINICTYPE;
            _proc.RIS_MODALITYCLINICTYPE.MODE = mode;
            result = _proc.GetExamClinicType();
        }

        public DataTable GetCheckMax() {
            RISModalityclinictypeSelectData _proc = new RISModalityclinictypeSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetCheckTime().Tables[0].Copy();
        }
	}
}

