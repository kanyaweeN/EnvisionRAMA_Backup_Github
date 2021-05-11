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
	public class ProcessGetGBLSequences : IBusinessLogic
	{
        public GBL_SEQUENCE GBL_SEQUENCE { get; set; }
        public DataSet Result { get; set; }

		public ProcessGetGBLSequences()
		{
            GBL_SEQUENCE = new GBL_SEQUENCE();
            Result = new DataSet();
		}
		public void Invoke()
		{
			GBLSequencesSelectData _proc=new GBLSequencesSelectData();
            Result = _proc.GetData();
		}
        public int GetAccessionNo() {
            GBLSequencesSelectData _proc = new GBLSequencesSelectData();
            _proc.GBL_SEQUENCE = GBL_SEQUENCE;
            return _proc.GetRunningNo();
        }
        public int GetRunnigNo() {
            GBLSequencesSelectData _proc = new GBLSequencesSelectData();
            _proc.GBL_SEQUENCE = GBL_SEQUENCE;
            return _proc.GetRunning();
        }
	}
}

