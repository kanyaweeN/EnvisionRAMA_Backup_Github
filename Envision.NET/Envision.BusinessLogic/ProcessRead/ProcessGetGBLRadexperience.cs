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
	public class ProcessGetGBLRadexperience : IBusinessLogic
	{
        public GBL_RADEXPERIENCE GBL_RADEXPERIENCE { get; set; }
        public DataSet Result { get; set; }

		public ProcessGetGBLRadexperience()
		{
            GBL_RADEXPERIENCE = new GBL_RADEXPERIENCE();
            Result = new DataSet();
		}
		public void Invoke()
		{
			GBLRadexperienceSelectData _proc=new GBLRadexperienceSelectData();
            _proc.GBL_RADEXPERIENCE = this.GBL_RADEXPERIENCE;
            Result = _proc.GetData();
		}
	}
}

