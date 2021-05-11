using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISServicetype : IBusinessLogic
	{
        public RIS_SERVICETYPE RIS_SERVICETYPE { get; set; }
        private List<RIS_SERVICETYPE> _risservicetype { get; set; }

        public ProcessUpdateRISServicetype()
        {
            RIS_SERVICETYPE = new RIS_SERVICETYPE();
            _risservicetype = new List<RIS_SERVICETYPE>();
        }

        public void Invoke()
        {
            foreach (RIS_SERVICETYPE item in _risservicetype)
            {
                RISServicetypeUpdateData _proc = new RISServicetypeUpdateData();
                _proc.RIS_SERVICETYPE = item;
                _proc.Update();
            }
        }
	}
}

