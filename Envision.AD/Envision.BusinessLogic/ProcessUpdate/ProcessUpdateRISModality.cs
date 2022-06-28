using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISModality : IBusinessLogic
	{
        public RIS_MODALITY RIS_MODALITY { get; set; }

		public ProcessUpdateRISModality(){
            RIS_MODALITY = new RIS_MODALITY();
        }
		public void Invoke()
		{
			RISModalityUpdateData _proc=new RISModalityUpdateData();
            _proc.RIS_MODALITY = this.RIS_MODALITY;
			_proc.Update();
		}
	}
}

