using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateMISTechniquetype : IBusinessLogic
	{
        public MIS_TECHNIQUETYPE MIS_TECHNIQUETYPE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateMISTechniquetype()
		{
            MIS_TECHNIQUETYPE = new MIS_TECHNIQUETYPE();
            Transaction = null;
		}
		public void Invoke()
		{
			MISTechniquetypeUpdateData _proc=new MISTechniquetypeUpdateData();
            _proc.MIS_TECHNIQUETYPE = this.MIS_TECHNIQUETYPE;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

