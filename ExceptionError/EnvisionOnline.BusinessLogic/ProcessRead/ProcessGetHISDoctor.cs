using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetHISDoctor : IBusinessLogic
    {
        private DataSet result;
        HISDoctor _hisdoctor;
        public ProcessGetHISDoctor()
        {
            _hisdoctor = new HISDoctor();
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public DataSet getData(int org_id)
        {
            HISDoctorSelectData _proc = new HISDoctorSelectData(org_id);
            return _proc.GetData();
        }
        public void Invoke()
        {
            HISDoctorSelectData _proc = new HISDoctorSelectData();
            result = _proc.GetData();
        }
    }
}

