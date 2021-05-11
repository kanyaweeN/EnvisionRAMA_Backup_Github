using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class HR_UnitDeleteDataforExcel : DataAccessBase
    {
        public HR_UNIT HR_UNIT { get; set; }

        public HR_UnitDeleteDataforExcel()
        {
            HR_UNIT = new HR_UNIT();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_Delete;
        }
        public bool Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
        }
        public bool Delete(DbTransaction tran)
        {
            if (tran != null)
            {
                ParameterList = buildParameter();
                Transaction = tran;
                ExecuteNonQuery();
            }
            else Delete();
            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@UNIT_ID",HR_UNIT.UNIT_ID)
                                     };
            return parameters;
        }
    }
}

