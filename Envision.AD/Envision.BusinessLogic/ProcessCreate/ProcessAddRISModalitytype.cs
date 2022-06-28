using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISModalitytype : IBusinessLogic
	{
        public RIS_MODALITYTYPE RIS_MODALITYTYPE { get; set; }
        public List<RIS_MODALITYTYPE> _rismodalitytype { get; set; }

		public ProcessAddRISModalitytype()
        {
            RIS_MODALITYTYPE = new RIS_MODALITYTYPE();
            _rismodalitytype = new List<RIS_MODALITYTYPE>();
        }

        public void Invoke()
        {
            foreach (RIS_MODALITYTYPE item in _rismodalitytype)
            {
                RISModalitytypeInsertData _proc = new RISModalitytypeInsertData();
                _proc.RIS_MODALITYTYPE = item;
                _proc.Add();
            }
        }
	}
}

