using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISServicetype : IBusinessLogic
	{
        private List<int> _risservicetype = new List<int>();


		public void Invoke()
		{
            foreach (int item in _risservicetype)
            {
                RISServicetypeDeleteData _proc = new RISServicetypeDeleteData();
                _proc.ServicetypeID = item;
                _proc.Delete();
            }
		}

        public List<int> DeleteItem
        {
            get { return _risservicetype; }
            set { _risservicetype = value; }
        }

	}
}

