//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISModalityInsertData : DataAccessBase 
	{
        public RIS_MODALITY RIS_MODALITY { get; set; }
		public  RISModalityInsertData()
		{
            RIS_MODALITY = new RIS_MODALITY();
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_Insert;
		}
		public DataSet Add()
		{
            ParameterList = buildParameter();
            DataSet ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@MODALITY_UID",RIS_MODALITY.MODALITY_UID),
                Parameter("@MODALITY_NAME",RIS_MODALITY.MODALITY_NAME),
                Parameter("@MODALITY_TYPE",RIS_MODALITY.MODALITY_TYPE),
                Parameter("@ROOM_ID",RIS_MODALITY.ROOM_ID),
                Parameter("@UNIT_ID",RIS_MODALITY.UNIT_ID),
                Parameter("@START_TIME",RIS_MODALITY.START_TIME),
                Parameter("@END_TIME",RIS_MODALITY.END_TIME),
                Parameter("@AVG_INV_TIME",RIS_MODALITY.AVG_INV_TIME),
                Parameter("@IS_ACTIVE",RIS_MODALITY.IS_ACTIVE),
                Parameter("@ORG_ID",RIS_MODALITY.ORG_ID),
                Parameter("@CREATED_BY",RIS_MODALITY.CREATED_BY),
			};
            return parameters;
        }
	}
}

