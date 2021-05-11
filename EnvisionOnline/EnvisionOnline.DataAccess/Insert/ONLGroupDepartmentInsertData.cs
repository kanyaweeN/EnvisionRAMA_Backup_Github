using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class ONLGroupDepartmentInsertData : DataAccessBase
    {
        public ONL_GROUPDEPARTMENT ONL_GROUPDEPARTMENT { get; set; }
        public ONLGroupDepartmentInsertData()
        {
            ONL_GROUPDEPARTMENT = new ONL_GROUPDEPARTMENT();
        }
        public void Add()
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPDEPARTMENT_Insert;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={		
	             Parameter("@GDEPT_TEXT",ONL_GROUPDEPARTMENT.GDEPT_TEXT)
                 ,Parameter("@GDEPT_TYPE",ONL_GROUPDEPARTMENT.GDEPT_TYPE)
                 ,Parameter("@CREATED_BY",ONL_GROUPDEPARTMENT.CREATED_BY)
			};
            return parameters;
        }
    }
}
