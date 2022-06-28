using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISModalityclinictype : IBusinessLogic
	{
        public RIS_MODALITYCLINICTYPE RIS_MODALITYCLINICTYPE { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessUpdateRISModalityclinictype()
		{
            RIS_MODALITYCLINICTYPE = new RIS_MODALITYCLINICTYPE();
            Transaction = null;
		}
		public void Invoke()
		{
			RISModalityclinictypeUpdateData _proc=new RISModalityclinictypeUpdateData();
            _proc.RIS_MODALITYCLINICTYPE = this.RIS_MODALITYCLINICTYPE;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

