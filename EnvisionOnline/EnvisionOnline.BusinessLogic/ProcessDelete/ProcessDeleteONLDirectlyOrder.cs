using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteONLDirectlyOrder : IBusinessLogic
    {
        private int _unit_id, _clinic_type_id;
        public ProcessDeleteONLDirectlyOrder(int unit_id, int clinic_type_id)
        {
            _unit_id = unit_id;
            _clinic_type_id = clinic_type_id;
        }

        public void Invoke()
        {
            ONLDirectlyOrderDeleteData _proc = new ONLDirectlyOrderDeleteData(_unit_id, _clinic_type_id);
            _proc.Delete();
        }
    }
}
