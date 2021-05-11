using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class SR_UserPreferenceInsertData : DataAccessBase
    {
        public SR_USERPREFERENCE SR_USERPREFERENCE { get; set; }

        public SR_UserPreferenceInsertData() {
            SR_USERPREFERENCE = new SR_USERPREFERENCE();
            StoredProcedureName = StoredProcedure.Prc_SR_USERPREFERENCE_Insert;
        }
        public void Add()
        {

            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void AddDefault() {
            StoredProcedureName = StoredProcedure.Prc_SR_USERPREFERENCE_InsertDefault ;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters =
		    {
                Parameter( "@TEMPLATE_ID"	    , SR_USERPREFERENCE.TEMPLATE_ID) ,
				Parameter( "@EXAM_ID"           , SR_USERPREFERENCE.EXAM_ID) ,
                Parameter( "@EMP_ID"            , SR_USERPREFERENCE.EMP_ID) ,
                Parameter( "@STATUS"            , SR_USERPREFERENCE.STATUS) ,
                Parameter( "@IS_DEFAULT"        , SR_USERPREFERENCE.IS_DEFAULT),
			};
            return parameters;
        }
    }
}
