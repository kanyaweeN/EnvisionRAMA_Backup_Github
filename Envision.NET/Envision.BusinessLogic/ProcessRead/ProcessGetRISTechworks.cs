using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetRISTechworks : IBusinessLogic
	{
        public RIS_TECHWORK RIS_TECHWORK { get; set; }
		private DataSet result;

		public ProcessGetRISTechworks()
		{
            RIS_TECHWORK = new RIS_TECHWORK();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISTechworksSelectData _proc=new RISTechworksSelectData();
            _proc.RIS_TECHWORK = RIS_TECHWORK;
			result=_proc.GetData();
		}
        public void SelectByAccessionNo()
        {
            RISTechworksSelectData _proc = new RISTechworksSelectData();
            _proc.RIS_TECHWORK = RIS_TECHWORK;
            result = _proc.SelectByAccessionNo();
        }
        public void SelectWithHN()
        {
            RISTechworksSelectData _proc = new RISTechworksSelectData();
            //_proc.RIS_TECHWORK = RIS_TECHWORK;
            result = _proc.SelectByAccessionNo();
        }
	}
}

