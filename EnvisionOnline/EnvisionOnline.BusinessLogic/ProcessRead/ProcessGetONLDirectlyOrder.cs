using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetONLDirectlyOrder : IBusinessLogic
    {
        private DataSet result;
        int _unit_id, _clinic_type_id, _exam_id, mode;
        public ProcessGetONLDirectlyOrder(int unit_id, int clinic_type_id, int exam_id)
        {
            _unit_id = unit_id;
            _clinic_type_id = clinic_type_id;
            _exam_id = exam_id;
            mode = 0;
        }
        public ProcessGetONLDirectlyOrder(int unit_id, int clinic_type_id)
        {
            _unit_id = unit_id;
            _clinic_type_id = clinic_type_id;
            mode = 1;
        }
        public ProcessGetONLDirectlyOrder(int exam_id)
        {
            _exam_id = exam_id;
            mode = 2;
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            ONLDirectlyOrderSelectData _proc = new ONLDirectlyOrderSelectData();
            if (mode == 0)
                result = _proc.GetData(_unit_id, _clinic_type_id, _exam_id);
            else if (mode == 1)
                result = _proc.GetData(_unit_id, _clinic_type_id);
            else if (mode == 2)
                result = _proc.GetData(_exam_id);
        }
    }
}


