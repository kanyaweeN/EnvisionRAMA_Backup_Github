using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateGBLRadexperience : IBusinessLogic
	{
        public GBL_RADEXPERIENCE GBL_RADEXPERIENCE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateGBLRadexperience()
		{
            GBL_RADEXPERIENCE = new GBL_RADEXPERIENCE();
            Transaction = null;
		}
		public void Invoke()
		{
			GBLRadexperienceUpdateData _proc=new GBLRadexperienceUpdateData();
            _proc.GBL_RADEXPERIENCE = this.GBL_RADEXPERIENCE;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
        public void UpdateGridWorklist(int RadID, string XMLGridWL)
        {
            GBLRadexperienceUpdateData _proc = new GBLRadexperienceUpdateData();
            _proc.UpdateGridWorklist(RadID, XMLGridWL);
        }
        public void UpdateGridHistory(int RadID, string XMLGridHistory)
        {
            GBLRadexperienceUpdateData _proc = new GBLRadexperienceUpdateData();
            _proc.UpdateGridHistory(RadID, XMLGridHistory);
        }
	}
}

