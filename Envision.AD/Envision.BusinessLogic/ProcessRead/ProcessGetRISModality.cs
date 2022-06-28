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
	public class ProcessGetRISModality : IBusinessLogic
	{
        public RIS_MODALITY RIS_MODALITY { get; set; }
		private DataSet result;
        private int action;


		public ProcessGetRISModality()
		{
            RIS_MODALITY = new RIS_MODALITY();
            action = 0;
		}
        public ProcessGetRISModality(bool selectAll) {
            RIS_MODALITY = new RIS_MODALITY();
            action = selectAll ? 1 : 0;
        }

		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISModalitySelectData _proc;
            if (action == 0)
                _proc = new RISModalitySelectData();
            else
                _proc = new RISModalitySelectData(true);
			result=_proc.GetData();
		}
        public void InvokeCNMI()
        {
            RISModalitySelectData _proc;
            if (action == 0)
                _proc = new RISModalitySelectData();
            else
                _proc = new RISModalitySelectData(true);
            result = _proc.GetDataCNMI();
        }
        public void Invoke_forAIMC()
        {
            RISModalitySelectData _proc;
            _proc = new RISModalitySelectData();
            result = _proc.GetData_forAIMC();
        }
        public void Invoke_forIntervention()
        {
            RISModalitySelectData _proc;
            _proc = new RISModalitySelectData();
            _proc.RIS_MODALITY = this.RIS_MODALITY;
            result = _proc.GetData_forIntervention();
        }

        public DataSet GetCheckDuplicateIsDefault(int EXAM_ID, int MODALITY_ID)
        {
            RISModalitySelectData data = new RISModalitySelectData();
            DataSet ds = data.GetCheckDuplicateIsDefault(EXAM_ID, MODALITY_ID);
            return ds;
        }
        public DataSet GetModalityForExamSetup(int EXAM_ID)
        {
            RISModalitySelectData data = new RISModalitySelectData();
            DataSet ds = data.GetModalityForExamSetup(EXAM_ID);
            return ds;
        }
	}
}

