using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
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
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISExamSelectData _proc = new RISExamSelectData();
            if (action == 1)
                _proc = new RISExamSelectData(true);
            result = _proc.GetData();
        }
        public DataTable InvokeOnlineAll()
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.InvokeOnlineAll();
        }
        public DataTable InvokeOnlineAllCNMI()
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.InvokeOnlineAllCNMI();
        }
        public DataTable InvokeOnline_visible()
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.InvokeOnline_visible();
        }
        public DataSet Consumable()
        {
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
        public DataTable GetExamPanelPortable(int exam_id)
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetExamPanelPortable(exam_id);
        }
        public DataTable GetExamPanelPortable(int exam_id, int clinic_type_id)
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetExamPanelPortable(exam_id,clinic_type_id);
        }
        public void GetAllExam_IncludeUnActive()
        {
            RISExamSelectData _proc = new RISExamSelectData();
            result = _proc.GetAllExam_IncludeUnActive();
        }
        public int GetExamtypeCTorMRI(int exam_id)
        {
            int exam_type = 0;
            RISExamSelectData _proc = new RISExamSelectData();
            DataTable dt =_proc.GetExamtypeCTorMRI(exam_id);
            if (dt.Rows.Count > 0)
                exam_type = Convert.ToInt32(dt.Rows[0]["EXAM_TYPE"]);
            return exam_type;
        }
        public String GetExamtypeRiskManagement(int exam_id)
        {
            String risk_mode = string.Empty;
            RISExamSelectData _proc = new RISExamSelectData();
            DataTable dt = _proc.GetExamtypeRiskManagement(exam_id);
            if (dt.Rows.Count > 0)
                risk_mode = dt.Rows[0]["RISK_MODE"].ToString();
            return risk_mode;
        }
        public DataTable GetExamRHS(int exam_id)
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetExamRHS(exam_id);
        }
        public DataTable GetExamLocation(int exam_id)
        {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetExamLocation(exam_id);
        }
    }
}

