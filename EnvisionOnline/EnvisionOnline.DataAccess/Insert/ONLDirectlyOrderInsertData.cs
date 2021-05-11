using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class ONLDirectlyOrderInsertData : DataAccessBase
    {
        private int _unit_id, _clinic_type_id, _exam_id;
        public ONLDirectlyOrderInsertData(int unit_id, int clinic_type_id, int exam_id)
        {
            _unit_id = unit_id;
            _clinic_type_id = clinic_type_id;
            _exam_id = exam_id;
        }
        public void Add()
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_DIRECTLYORDER_Insert;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={		
	             Parameter("@UNIT_ID",_unit_id)
                ,Parameter("@CLINIC_TYPE_ID",_clinic_type_id)
                ,Parameter("@EXAM_ID",_exam_id)
			};
            return parameters;
        }
    }
}
