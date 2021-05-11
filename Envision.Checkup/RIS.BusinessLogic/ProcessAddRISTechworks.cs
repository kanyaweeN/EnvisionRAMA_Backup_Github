using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISTechworks : IBusinessLogic
	{
		private RISTechworks _ristechworks;
        private int action;
		public ProcessAddRISTechworks()
		{
			_ristechworks = new  RISTechworks();
            action = 0;
		}
        public ProcessAddRISTechworks(RISTechworks ristechworks)
        {
            _ristechworks = ristechworks;
            action = 1;
        }
		public RISTechworks RISTechworks		{
			get{return _ristechworks;}
			set{_ristechworks=value;}
		}
		public void Invoke()
		{
            RISTechworksInsertData _proc = null;
            if (action == 0)
                _proc = new RISTechworksInsertData();
            else
                _proc = new RISTechworksInsertData(true);
			_proc.RISTechworks=this.RISTechworks;
			_proc.Add();
		}
	}
}

