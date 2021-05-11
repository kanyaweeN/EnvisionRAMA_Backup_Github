using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISServicetype : IBusinessLogic
	{
        private List<RISServicetype> _risservicetype = new List<RISServicetype>();
        
		public void Invoke()
		{
            foreach (RISServicetype item in _risservicetype)
            {
                RISServicetypeUpdateData _proc = new RISServicetypeUpdateData();
                _proc.RISServicetype = item;
                _proc.Update();
            }
		}

        public List<RISServicetype> ServiceTypeItem
        {
            get { return _risservicetype; }
            set { _risservicetype = value; }
        }
	}
}

