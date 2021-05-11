using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISExaminstructionsClinicSessionInsertData: DataAccessBase 
	{
        public RIS_EXAMINSTRUCTIONCLINICSESSION RIS_EXAMINSTRUCTIONCLINICSESSION { get; set; }
        public RISExaminstructionsClinicSessionInsertData()
		{
            RIS_EXAMINSTRUCTIONCLINICSESSION = new RIS_EXAMINSTRUCTIONCLINICSESSION();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMINSTRUCTIONCLINICSESSION_UpdateOrInsert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@EXAM_ID",RIS_EXAMINSTRUCTIONCLINICSESSION.EXAM_ID),
                Parameter("@SESSION_ID",RIS_EXAMINSTRUCTIONCLINICSESSION.SESSION_ID),
                Parameter("@INS_UID",RIS_EXAMINSTRUCTIONCLINICSESSION.INS_UID),
                Parameter("@INS_TEXT",RIS_EXAMINSTRUCTIONCLINICSESSION.INS_TEXT),
                Parameter("@INS_TEXT_KID",RIS_EXAMINSTRUCTIONCLINICSESSION.INS_TEXT_KID),
                Parameter("@CREATED_BY",RIS_EXAMINSTRUCTIONCLINICSESSION.CREATED_BY),
			            };
            return parameters;
        }
	}
}
