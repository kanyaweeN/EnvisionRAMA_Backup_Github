//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:24
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
	public class MISBiopsyresultInsertData : DataAccessBase 
	{
        public MIS_BIOPSYRESULT MIS_BIOPSYRESULT { get; set; }
		public  MISBiopsyresultInsertData()
		{
            MIS_BIOPSYRESULT = new MIS_BIOPSYRESULT();
			StoredProcedureName = StoredProcedure.Prc_MIS_BIOPSYRESULT_Insert;
		}
		public bool Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Add(bool flag,DbTransaction tran) 
		{
			if (flag)
			{
                ParameterList = buildParameter();
                Transaction = tran;
                ExecuteNonQuery();
			}
			else Add();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter LocNoR = Parameter();
            LocNoR.ParameterName = "@LOC_NO_R";
            if (string.IsNullOrEmpty(MIS_BIOPSYRESULT.LOC_NO_R))
                LocNoR.Value = DBNull.Value;
            else
                LocNoR.Value = MIS_BIOPSYRESULT.LOC_NO_R == "N" ? (object)DBNull.Value : MIS_BIOPSYRESULT.LOC_NO_R;

            DbParameter LocNoL = Parameter();
            LocNoL.ParameterName = "@LOC_NO_L";
            if (string.IsNullOrEmpty(MIS_BIOPSYRESULT.LOC_NO_L))
                LocNoL.Value = DBNull.Value;
            else
                LocNoL.Value = MIS_BIOPSYRESULT.LOC_NO_L == "N" ? (object)DBNull.Value : MIS_BIOPSYRESULT.LOC_NO_L;

            DbParameter Depth_R = Parameter();
            Depth_R.ParameterName = "@DEPTH_TYPE_R";
            if (string.IsNullOrEmpty(MIS_BIOPSYRESULT.DEPTH_TYPE_R.ToString()))
                Depth_R.Value = DBNull.Value;
            else
                Depth_R.Value = MIS_BIOPSYRESULT.DEPTH_TYPE_R.ToString() == "N" ? (object)DBNull.Value : MIS_BIOPSYRESULT.DEPTH_TYPE_R.ToString();

            DbParameter Depth_L = Parameter();
            Depth_L.ParameterName = "@DEPTH_TYPE_L";
            if (string.IsNullOrEmpty(MIS_BIOPSYRESULT.DEPTH_TYPE_L.ToString()))
                Depth_L.Value = DBNull.Value;
            else
                Depth_L.Value = MIS_BIOPSYRESULT.DEPTH_TYPE_L.ToString() == "N" ? (object)DBNull.Value : MIS_BIOPSYRESULT.DEPTH_TYPE_L.ToString();

            DbParameter Lesion = Parameter();
            Lesion.ParameterName = "@LESION_TYPE_ID";
            if (MIS_BIOPSYRESULT.LESION_TYPE_ID == null)
                Lesion.Value = DBNull.Value;
            else
                Lesion.Value = MIS_BIOPSYRESULT.LESION_TYPE_ID == 0 ? (object)DBNull.Value : MIS_BIOPSYRESULT.LESION_TYPE_ID;

            DbParameter Asessment = Parameter();
            Asessment.ParameterName = "@ASESSMENT_TYPE_ID";
            if (MIS_BIOPSYRESULT.ASESSMENT_TYPE_ID == null)
                Asessment.Value = DBNull.Value;
            else
                Asessment.Value = MIS_BIOPSYRESULT.ASESSMENT_TYPE_ID == 0 ? (object)DBNull.Value : MIS_BIOPSYRESULT.ASESSMENT_TYPE_ID;

            DbParameter Tech = Parameter();
            Tech.ParameterName = "@TECHNIQUE_TYPE_ID";
            if (MIS_BIOPSYRESULT.TECHNIQUE_TYPE_ID == null)
                Tech.Value = DBNull.Value;
            else
                Tech.Value = MIS_BIOPSYRESULT.TECHNIQUE_TYPE_ID == 0 ? (object)DBNull.Value : MIS_BIOPSYRESULT.TECHNIQUE_TYPE_ID;

            DbParameter[] parameters ={			
	Parameter("@BIOPSY_RESULT_ID",MIS_BIOPSYRESULT.BIOPSY_RESULT_ID)	
,Parameter("@ACCESSION_NO",MIS_BIOPSYRESULT.ACCESSION_NO)
,Parameter("@RESULT_DT",MIS_BIOPSYRESULT.RESULT_DT)
,Parameter("@RADIOLOGIST_ID",MIS_BIOPSYRESULT.RADIOLOGIST_ID)
,LocNoR
,LocNoL
,Parameter("@TISSUE_TYPE",MIS_BIOPSYRESULT.TISSUE_TYPE)
,Depth_R
,Depth_L
,Parameter("@WIDTH",MIS_BIOPSYRESULT.WIDTH)
,Parameter("@LENGTH",MIS_BIOPSYRESULT.LENGTH)
,Parameter("@DEPTH",MIS_BIOPSYRESULT.DEPTH)
,Parameter("@PROCEDURE_TYPE",MIS_BIOPSYRESULT.PROCEDURE_TYPE)
,Parameter("@NO_OF_CORE",MIS_BIOPSYRESULT.NO_OF_CORE)
,Parameter("@CALCIUM_PCS",MIS_BIOPSYRESULT.CALCIUM_PCS)
,Parameter("@IS_SATISFACTORY",MIS_BIOPSYRESULT.IS_SATISFACTORY)
,Parameter("@IS_SURGERY",MIS_BIOPSYRESULT.IS_SURGERY)
,Parameter("@COMMENTS",MIS_BIOPSYRESULT.COMMENTS)
,Parameter("@IS_PALPABLE",MIS_BIOPSYRESULT.IS_PALPABLE)
,Lesion
,Asessment
,Tech
,Parameter("@LAB_DATA",MIS_BIOPSYRESULT.LAB_DATA)
,Parameter("@ORG_ID",MIS_BIOPSYRESULT.ORG_ID)
,Parameter("@CREATED_BY",MIS_BIOPSYRESULT.CREATED_BY)
,Parameter("@LAST_MODIFIED_BY",MIS_BIOPSYRESULT.LAST_MODIFIED_BY)
,Parameter("@STATUS",MIS_BIOPSYRESULT.STATUS)
			            };
            return parameters;
        }
	}
}

