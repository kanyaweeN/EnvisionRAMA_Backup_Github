using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class RISClinicalIndicationInsertData: DataAccessBase
    {

        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public RISClinicalIndicationInsertData()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            this.StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATION_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter paramCI_PARENT = Parameter();
            paramCI_PARENT.ParameterName = "@CI_PARENT";
            if (RIS_CLINICALINDICATION.CI_PARENT == null)
                paramCI_PARENT.Value = DBNull.Value;
            else if (RIS_CLINICALINDICATION.CI_PARENT == 0)
                paramCI_PARENT.Value = DBNull.Value;
            else
                paramCI_PARENT.Value = RIS_CLINICALINDICATION.CI_PARENT;

            DbParameter[] parameters ={			
                           Parameter("@CI_UID",RIS_CLINICALINDICATION.CI_UID),
                           Parameter("@CI_DESC",RIS_CLINICALINDICATION.CI_DESC),
                           Parameter("@CI_LEVEL",RIS_CLINICALINDICATION.CI_LEVEL),
                           paramCI_PARENT,
            Parameter("@IS_USER_DEFINED",RIS_CLINICALINDICATION.IS_USER_DEFINED),
            Parameter("@ORG_ID",RIS_CLINICALINDICATION.ORG_ID),
            Parameter("@CREATED_BY",RIS_CLINICALINDICATION.CREATED_BY),
			            };
            return parameters;
        }
    }
}
