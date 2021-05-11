using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetGBLSequences : IBusinessLogic
	{
		private DataSet result;
        private GBLSequences _gblsequences;
		public ProcessGetGBLSequences()
		{
			_gblsequences = new  GBLSequences();
		}
        public GBLSequences GBLSequences{
            get { return _gblsequences; }
            set { _gblsequences = value; }
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			GBLSequencesSelectData _proc=new GBLSequencesSelectData();
			result=_proc.GetData();
		}
        public int GetAccessionNo() {
            GBLSequencesSelectData _proc = new GBLSequencesSelectData();
            _proc.GBLSequences = _gblsequences;
            return _proc.GetRunningNo();
        }
        public int GetRunnigNo() {
            GBLSequencesSelectData _proc = new GBLSequencesSelectData();
            _proc.GBLSequences = _gblsequences;
            return _proc.GetRunning();
        }
	}
}

