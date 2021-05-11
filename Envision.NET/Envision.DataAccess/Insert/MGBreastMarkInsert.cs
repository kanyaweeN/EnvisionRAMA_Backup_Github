using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class MGBreastMarkInsert : DataAccessBase
    {
        public MG_BREASTMARK MG_BREASTMARK { get; set; }
        public DbTransaction Trans { get; set; }
        public MGBreastMarkInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMARK_INSERT;
        }

        public void InsertData(bool IsUseTransaction)
        {
            ParameterList = this.BuildParameters();
            if (IsUseTransaction && (Trans != null))
                this.Transaction = this.Trans;
            DataSet ds = this.ExecuteDataSet();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        this.MG_BREASTMARK.BREAST_MARK_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["BREAST_MARK_ID"]);
                    }
                }
            }
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter pBreastScreenImg = null;
            if (this.MG_BREASTMARK.BREAST_SCREEN_IMG != null)
            {
                if (this.MG_BREASTMARK.BREAST_SCREEN_IMG.Length == 0)
                {
                    pBreastScreenImg = Parameter();
                    pBreastScreenImg.ParameterName = "@BREAST_SCREEN_IMG";
                    pBreastScreenImg.DbType = DbType.Binary;
                    pBreastScreenImg.Value = DBNull.Value;
                }
                else
                    pBreastScreenImg = Parameter("@BREAST_SCREEN_IMG", this.MG_BREASTMARK.BREAST_SCREEN_IMG);
            }
            else
            {
                pBreastScreenImg = Parameter();
                pBreastScreenImg.ParameterName = "@BREAST_SCREEN_IMG";
                pBreastScreenImg.DbType = DbType.Binary;
                pBreastScreenImg.Value = DBNull.Value;
            }
            DbParameter[] parameters = { 
                                        Parameter("@ACCESSION_NO", this.MG_BREASTMARK.ACCESSION_NO),
                                        Parameter("@BREAST_SCREEN_WIDTH", this.MG_BREASTMARK.BREAST_SCREEN_WIDTH),
                                        Parameter("@BREAST_SCREEN_HIGHT", this.MG_BREASTMARK.BREAST_SCREEN_HIGHT),
                                        pBreastScreenImg,
                                        Parameter("@BREAST_SCREEN_SCALE", this.MG_BREASTMARK.BREAST_SCREEN_SCALE),
                                        Parameter("@NO_OF_MASS", this.MG_BREASTMARK.NO_OF_MASS),
                                        Parameter("@ORG_ID", this.MG_BREASTMARK.ORG_ID),
                                        Parameter("@CREATED_BY", this.MG_BREASTMARK.CREATED_BY)
                                   };

            return parameters;
        }
    }
}
