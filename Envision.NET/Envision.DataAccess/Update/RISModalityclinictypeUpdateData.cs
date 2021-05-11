using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISModalityclinictypeUpdateData : DataAccessBase 
	{
        public RIS_MODALITYCLINICTYPE RIS_MODALITYCLINICTYPE { get; set; }

		public  RISModalityclinictypeUpdateData()
		{
            RIS_MODALITYCLINICTYPE = new RIS_MODALITYCLINICTYPE();
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYCLINICTYPE_Update;
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Update(DbTransaction tran) 
		{
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@MODALITY_CLINICTYPE_ID",RIS_MODALITYCLINICTYPE.MODALITY_CLINICTYPE_ID)
                ,Parameter("@CLINIC_TYPE_ID",RIS_MODALITYCLINICTYPE.CLINIC_TYPE_ID)
                ,Parameter("@MODALITY_ID",RIS_MODALITYCLINICTYPE.MODALITY_ID)
                ,Parameter("@START_DATETIME",RIS_MODALITYCLINICTYPE.START_DATETIME)
                ,Parameter("@END_DATETIME",RIS_MODALITYCLINICTYPE.END_DATETIME)
                ,Parameter("@MAX_APP",RIS_MODALITYCLINICTYPE.MAX_APP)
                ,Parameter("@ORG_ID",RIS_MODALITYCLINICTYPE.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_MODALITYCLINICTYPE.CREATED_BY)
                ,Parameter("@CLINIC_TYPE_ID_OLD",RIS_MODALITYCLINICTYPE.CLINIC_TYPE_ID_OLD)
                                      };
            return parameters;
        }
	}
}

