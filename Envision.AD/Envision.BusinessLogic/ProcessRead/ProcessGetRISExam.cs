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
	public class ProcessGetRISExam : IBusinessLogic
	{
        public RIS_EXAM RIS_EXAM { get; set; }
		private DataSet result;
        private int action;

		public ProcessGetRISExam()
		{
            RIS_EXAM = new RIS_EXAM();
            action = 0;
		}
        public ProcessGetRISExam(bool selectAll)
        {
            RIS_EXAM = new RIS_EXAM();
            action = 1;
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamSelectData _proc=new RISExamSelectData();
            if (action == 1)
                _proc = new RISExamSelectData(true);
			result=_proc.GetData();
		}
        public void InvokeCNMI()
        {
            RISExamSelectData _proc = new RISExamSelectData();
            if (action == 1)
                _proc = new RISExamSelectData(true);
            result = _proc.GetDataCNMI();
        }
        public DataSet Consumable() {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetConsumable();
        }
        public DataTable GetExam_byBarcode(string barcode)
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetExam_byBarcode(barcode);
        }
        public DataTable GetExamInvervent()
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetExamInvervent();
        }
        public void GetExamNonInterventConsumable()
        {
            RISExamSelectData _proc = new RISExamSelectData();
            _proc = new RISExamSelectData(true);
            result = _proc.GetExamNonInterventConsumable();
        }
        public DataTable GetExamPanel()
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetExamPanel();
        }
        public void GetAllExam_IncludeUnActive()
        {
            RISExamSelectData _proc = new RISExamSelectData();
            result = _proc.GetAllExam_IncludeUnActive();
        }
        public DataTable GetExamAIMC()
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetExamAIMC();
        }
        public DataTable GetIsSendBilling(string ACCESSION_NO)
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetIsSendBilling(ACCESSION_NO);
        }
        public DataTable GetExamPanelPortable(int exam_id)
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetExamPanelPortable(exam_id);
        }
        public DataTable GetExamPanelPortable(int exam_id, int clinic_type_id)
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetExamPanelPortable(exam_id, clinic_type_id);
        }
        public DataTable GetExamMappingBilling(int exam_id)
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetExamMappingBilling(exam_id);
        }
	}
}

