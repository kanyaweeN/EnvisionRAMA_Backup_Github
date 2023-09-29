using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
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
        public ProcessGetRISModality(bool selectAll)
        {
            RIS_MODALITY = new RIS_MODALITY();
            action = selectAll ? 1 : 0;
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISModalitySelectData _proc;
            if (action == 0)
                _proc = new RISModalitySelectData();
            else
                _proc = new RISModalitySelectData(true);
            result = _proc.GetData();
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
        public DataSet GetDataID(int modalityID)
        {
            RISModalitySelectData _proc = new RISModalitySelectData();
            return _proc.GetDataID(modalityID);
        }
        public void getModalitysetAppintmentByPatientType(int modalityId)
        {
            RISModalitySelectData _proc = new RISModalitySelectData();
            result = _proc.getModalitysetAppintmentByPatientType(modalityId);
        }
    }
}

