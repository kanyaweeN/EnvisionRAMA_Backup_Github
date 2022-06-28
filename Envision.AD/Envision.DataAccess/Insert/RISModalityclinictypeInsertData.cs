//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    27/04/2009 08:46:09
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISModalityclinictypeInsertData : DataAccessBase 
	{
        public RIS_MODALITYCLINICTYPE RIS_MODALITYCLINICTYPE { get; set; }
		public  RISModalityclinictypeInsertData()
		{
            RIS_MODALITYCLINICTYPE = new RIS_MODALITYCLINICTYPE();
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYCLINICTYPE_Insert;
		}
		public bool Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Add(DbTransaction tran) 
		{
                ParameterList = buildParameter();
                Transaction = tran;
                ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@CLINIC_TYPE_ID",RIS_MODALITYCLINICTYPE.CLINIC_TYPE_ID)
                ,Parameter("@MODALITY_ID",RIS_MODALITYCLINICTYPE.MODALITY_ID)
                ,Parameter("@START_DATETIME",RIS_MODALITYCLINICTYPE.START_DATETIME)
                ,Parameter("@END_DATETIME",RIS_MODALITYCLINICTYPE.END_DATETIME)
                ,Parameter("@MAX_APP",RIS_MODALITYCLINICTYPE.MAX_APP)
                ,Parameter("@ORG_ID",RIS_MODALITYCLINICTYPE.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_MODALITYCLINICTYPE.CREATED_BY)
			            };
            return parameters;
        }
	}
}

