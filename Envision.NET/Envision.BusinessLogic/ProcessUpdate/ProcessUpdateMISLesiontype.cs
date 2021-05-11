using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateMISLesiontype : IBusinessLogic
	{
        public MIS_LESIONTYPE MIS_LESIONTYPE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateMISLesiontype()
		{
            MIS_LESIONTYPE = new MIS_LESIONTYPE();
            Transaction = null;
		}
		public void Invoke()
		{
			MISLesiontypeUpdateData _proc=new MISLesiontypeUpdateData();
            _proc.MIS_LESIONTYPE = this.MIS_LESIONTYPE;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

