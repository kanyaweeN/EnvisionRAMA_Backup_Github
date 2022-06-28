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
    public class ProcessGetRISOnlineArrivalWorklist : IBusinessLogic
    {
        private DataSet result;
        private OnlineArrivalWorklist _onlineArrival;
        private int action;

		public ProcessGetRISOnlineArrivalWorklist()
		{
            _onlineArrival = new OnlineArrivalWorklist();
		}
        public OnlineArrivalWorklist OnlineArrivalWorklist
        {
            get { return _onlineArrival; }
            set { _onlineArrival = value; }
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISOnlineArrivalWorklistSelectData _proc = new RISOnlineArrivalWorklistSelectData();
            _proc.OnlineArrivalWorklist = this.OnlineArrivalWorklist;
			result=_proc.GetData();
		}
    }
}
