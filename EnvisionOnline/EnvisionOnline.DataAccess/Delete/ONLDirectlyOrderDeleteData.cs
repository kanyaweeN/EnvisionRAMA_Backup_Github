using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class ONLDirectlyOrderDeleteData: DataAccessBase
    {
        private int _unit_id, _clinic_type_id;
        public ONLDirectlyOrderDeleteData(int unit_id , int clinic_type_id)
        {
            _unit_id = unit_id;
            _clinic_type_id = clinic_type_id;
            StoredProcedureName = StoredProcedure.Prc_ONL_DIRECTLYORDER_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void Delete(DbTransaction tran)
        {
            if (tran == null)
            {
                ParameterList = buildParameter();
                ExecuteNonQuery();
            }
            else
            {
                ParameterList = buildParameter();
                Transaction = tran;
                ExecuteNonQuery();
            }
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@UNIT_ID", _unit_id),
                                       Parameter("@CLINIC_TYPE_ID", _clinic_type_id)
                                       };
            return parameters;
        }
    }
}