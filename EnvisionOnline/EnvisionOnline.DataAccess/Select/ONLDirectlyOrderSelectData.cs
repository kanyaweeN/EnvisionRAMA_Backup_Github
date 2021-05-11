using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class ONLDirectlyOrderSelectData : DataAccessBase
    {
        public ONLDirectlyOrderSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_DIRECTLYORDER_Select;
        }
        public DataSet GetData(int unit_id, int clinic_type, int exam_id)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(unit_id, clinic_type, exam_id);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int unit_id, int clinic_type, int exam_id)
        {
            DbParameter[] parameters = { 
                                                Parameter("@UNIT_ID",unit_id)
                                                ,Parameter("@CLINIC_TYPE_ID",clinic_type)
                                                ,Parameter("@EXAM_ID",exam_id)
                                       };
            return parameters;
        }

        public DataSet GetData(int unit_id, int clinic_type)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_ONL_DIRECTLYORDER_SelectByUnitAndClinic;
            ParameterList = buildParameter(unit_id, clinic_type);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int unit_id, int clinic_type)
        {
            DbParameter[] parameters = { 
                                                Parameter("@UNIT_ID",unit_id)
                                                ,Parameter("@CLINIC_TYPE_ID",clinic_type)
                                       };
            return parameters;
        }

        public DataSet GetData(int exam_id)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_ONL_DIRECTLYORDER_SelectByExamId;
            ParameterList = buildParameter(exam_id);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int exam_id)
        {
            DbParameter[] parameters = { 
                                                Parameter("@EXAM_ID",exam_id)
                                       };
            return parameters;
        }
    }
}

