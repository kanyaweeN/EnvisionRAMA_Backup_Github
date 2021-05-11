using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddONLDirectlyOrder : IBusinessLogic
    {
        private int _unit_id, _clinic_type_id, _exam_id;
        public ProcessAddONLDirectlyOrder(int unit_id, int clinic_type_id, int exam_id)
        {
            _unit_id = unit_id;
            _clinic_type_id = clinic_type_id;
            _exam_id = exam_id;
        }

        public void Invoke()
        {
            ONLDirectlyOrderInsertData add = new ONLDirectlyOrderInsertData(_unit_id, _clinic_type_id, _exam_id);
            add.Add();
        }
    }
}