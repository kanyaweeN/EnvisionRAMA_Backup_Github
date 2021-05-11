using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class ACFinalizePrivilegeInsertData : DataAccessBase 
    {
        public AC_FINALIZEPRIVILEGE AC_FINALIZEPRIVILEGE { get; set; }
        int _id = 0;
        public ACFinalizePrivilegeInsertData()
		{
            AC_FINALIZEPRIVILEGE = new AC_FINALIZEPRIVILEGE();
            StoredProcedureName = StoredProcedure.Prc_AC_FINALIZEPRIVILEGE_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
        }
        public int GetID()
        {
            return _id;
        }
        private DbParameter[] buildParameter()
        {
            //@FINALIZEPRIVILEGE_ID int
            //,@EMP_ID int
            //,@EXAM_ID int
            //,@IS_ACTIVE nvarchar(1)
            //,@ORG_ID int
            //,@CREATED_BY int

            DbParameter[] parameters ={
                Parameter("@FINALIZEPRIVILEGE_ID",AC_FINALIZEPRIVILEGE.FINALIZEPRIVILEGE_ID)
                ,Parameter("@EMP_ID",AC_FINALIZEPRIVILEGE.EMP_ID)
                ,Parameter("@EXAM_ID",AC_FINALIZEPRIVILEGE.EXAM_ID)
                ,Parameter("@IS_ACTIVE",AC_FINALIZEPRIVILEGE.IS_ACTIVE)
                ,Parameter("@ORG_ID",AC_FINALIZEPRIVILEGE.ORG_ID)
                ,Parameter("@CREATED_BY", AC_FINALIZEPRIVILEGE.CREATED_BY)
            };
            return parameters;
        }
    }
}
