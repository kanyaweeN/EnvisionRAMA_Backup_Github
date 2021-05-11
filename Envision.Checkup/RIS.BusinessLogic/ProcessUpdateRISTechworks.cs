using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISTechworks : IBusinessLogic
	{
		private RISTechworks _ristechworks;
		public ProcessUpdateRISTechworks()
		{
			_ristechworks = new RISTechworks();
		}
		public RISTechworks RISTechworks		{
			get{return _ristechworks;}
			set{_ristechworks=value;}
		}
		public void Invoke()
		{
			RISTechworksUpdateData _proc=new RISTechworksUpdateData();
			_proc.RISTechworks=RISTechworks;
			_proc.Update();
		}
	}
}

