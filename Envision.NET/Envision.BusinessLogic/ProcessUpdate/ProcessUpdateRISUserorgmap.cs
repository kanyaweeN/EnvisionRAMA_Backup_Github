using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISUserorgmap : IBusinessLogic
	{
        public RIS_USERORGMAP RIS_USERORGMAP { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateRISUserorgmap()
		{
            RIS_USERORGMAP = new RIS_USERORGMAP();
            Transaction = null;
		}
		public void Invoke()
		{
			RISUserorgmapUpdateData _proc=new RISUserorgmapUpdateData();
            _proc.RIS_USERORGMAP = this.RIS_USERORGMAP;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

