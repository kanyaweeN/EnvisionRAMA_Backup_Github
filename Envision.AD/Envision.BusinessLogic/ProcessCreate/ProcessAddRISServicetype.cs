using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISServicetype : IBusinessLogic
	{
        public RIS_SERVICETYPE RIS_SERVICETYPE { get; set; }
        private List<RIS_SERVICETYPE> _risservicetype { get; set; }
        public ProcessAddRISServicetype()
        {
            RIS_SERVICETYPE = new RIS_SERVICETYPE();
            _risservicetype = new List<RIS_SERVICETYPE>();
        }
		public void Invoke()
		{
            foreach (RIS_SERVICETYPE item in _risservicetype)
            {
                RISServicetypeInsertData _proc = new RISServicetypeInsertData();
                _proc.RIS_SERVICETYPE = item;
                _proc.Add();
            }
		}

	}
}

