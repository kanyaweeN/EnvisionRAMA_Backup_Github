using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISServicetype : IBusinessLogic
	{

        private List<RISServicetype> _risservicetype = new List<RISServicetype>();


		public void Invoke()
		{
            foreach (RISServicetype item in _risservicetype)
            {
                RISServicetypeInsertData _proc = new RISServicetypeInsertData();
                _proc.RISServicetype = item;
                _proc.Add();
            }
		}

        public List<RISServicetype> ServiceTypeItem
        {
            get { return _risservicetype; }
            set { _risservicetype = value; }
        }
	}
}

