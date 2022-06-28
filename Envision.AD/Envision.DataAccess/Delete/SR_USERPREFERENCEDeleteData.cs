using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class SR_USERPREFERENCEDeleteData : DataAccessBase
    {
        public SR_USERPREFERENCE SR_USERPREFERENCE { get; set; }

        public SR_USERPREFERENCEDeleteData() {
            StoredProcedureName = StoredProcedure.Prc_SR_USERPREFERENCE_DeleteByEmpId;
        }
        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@EMP_ID",SR_USERPREFERENCE.EMP_ID)
                                     };
            return parameters;
        }
        public void DeleteByTemplateId()
        {
            StoredProcedureName = StoredProcedure.Prc_SR_USERPREFERENCE_DeleteByTemplateId;
            ParameterList = buildParameterTemplateId();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterTemplateId()
        {
            DbParameter[] parameters ={
                                         Parameter("@TEMPLATE_ID",SR_USERPREFERENCE.TEMPLATE_ID)
                                     };
            return parameters;
        }
    }
}
