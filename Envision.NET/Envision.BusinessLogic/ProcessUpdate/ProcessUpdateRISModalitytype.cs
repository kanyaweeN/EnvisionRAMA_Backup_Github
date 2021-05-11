using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISModalitytype : IBusinessLogic
    {
        public RIS_MODALITYTYPE RIS_MODALITYTYPE { get; set; }
        public List<RIS_MODALITYTYPE> _rismodalitytype { get; set; }
        public ProcessUpdateRISModalitytype()
        {
            RIS_MODALITYTYPE = new RIS_MODALITYTYPE();
            _rismodalitytype = new List<RIS_MODALITYTYPE>();
        }

		public void Invoke()
		{
            foreach (RIS_MODALITYTYPE item in _rismodalitytype)
            {
                RISModalitytypeUpdateData _proc = new RISModalitytypeUpdateData();
                _proc.RIS_MODALITYTYPE = item;
                _proc.Update();
            }
		}
	}
}

