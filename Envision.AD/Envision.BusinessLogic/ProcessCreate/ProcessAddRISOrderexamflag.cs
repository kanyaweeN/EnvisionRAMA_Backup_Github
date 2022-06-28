using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISOrderexamflag: IBusinessLogic
	{
        public RIS_ORDEREXAMFLAG RIS_ORDEREXAMFLAG { get; set; }
        public ProcessAddRISOrderexamflag()
		{
            RIS_ORDEREXAMFLAG = new RIS_ORDEREXAMFLAG();
		}
		public void Invoke()
		{
            RISOrderexamflagInsertData _proc = new RISOrderexamflagInsertData();
            _proc.RIS_ORDEREXAMFLAG = this.RIS_ORDEREXAMFLAG;
			_proc.Add();
		}
	}
}
