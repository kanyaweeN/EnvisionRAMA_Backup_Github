using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISOrderexamflag: IBusinessLogic
	{
		private DataSet result;
        public RIS_ORDEREXAMFLAG RIS_ORDEREXAMFLAG { get; set; }
        public ProcessGetRISOrderexamflag()
		{
            RIS_ORDEREXAMFLAG = new RIS_ORDEREXAMFLAG();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISOrderexamflagSelectData _proc = new RISOrderexamflagSelectData();
            _proc.RIS_ORDEREXAMFLAG = this.RIS_ORDEREXAMFLAG;
            result = _proc.GetData();
		}
        public void InvokeSchedule()
        {
            RISOrderexamflagSelectData _proc = new RISOrderexamflagSelectData();
            _proc.RIS_ORDEREXAMFLAG = this.RIS_ORDEREXAMFLAG;
            result = _proc.GetDataSchedule();
        }
        public void InvokeXrayreq()
        {
            RISOrderexamflagSelectData _proc = new RISOrderexamflagSelectData();
            _proc.RIS_ORDEREXAMFLAG = this.RIS_ORDEREXAMFLAG;
            result = _proc.GetDataXrayreq();
        }
        public DataTable resultDetail()
        {
            RISOrderexamflagSelectData _proc = new RISOrderexamflagSelectData();
            _proc.RIS_ORDEREXAMFLAG = this.RIS_ORDEREXAMFLAG;
            return _proc.GetDetail().Tables[0];
        }
	}
}
