using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class INV_UNITDeleteData : DataAccessBase
    {
        public INV_UNIT INV_UNIT { get; set; }
        
        public INV_UNITDeleteData()
        {
            INV_UNIT = new INV_UNIT();
            StoredProcedureName = StoredProcedure.Prc_INV_UNIT_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@UNIT_ID",INV_UNIT.UNIT_ID)
                                     };
            return parameters;
        }
       
    }
}
