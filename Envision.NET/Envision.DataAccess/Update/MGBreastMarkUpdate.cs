using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Update;
using System.Data;

namespace Envision.DataAccess.Update
{
    public class MGBreastMarkUpdate : DataAccessBase
    {
        public MG_BREASTMARK MG_BREASTMARK { get; set; }
        public DbTransaction Trans { get; set; }
    
        public MGBreastMarkUpdate()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMARK_UPDATE;
        }

        public void UpdateData(bool UseTransaction)
        {
            this.ParameterList = this.BuildParameters();
            if (UseTransaction && (this.Trans != null))
            {
                this.Transaction = this.Trans;
            }
            DataTable dt = this.ExecuteDataTable();
            if (dt != null)
                if (dt.Rows.Count > 0)
                {
                    string id = dt.Rows[0]["BREAST_MARK_ID"].ToString();
                    if (!string.IsNullOrEmpty(id.Trim()))
                        this.MG_BREASTMARK.BREAST_MARK_ID = Convert.ToInt32(id);
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
                                            //Parameter("@BREAST_MARK_ID", this.MG_BREASTMARK.BREAST_MARK_ID),
                                            Parameter("@ACCESSION_NO", this.MG_BREASTMARK.ACCESSION_NO),
                                            Parameter("@BREAST_SCREEN_WIDTH", this.MG_BREASTMARK.BREAST_SCREEN_WIDTH),
                                            Parameter("@BREAST_SCREEN_HIGHT", this.MG_BREASTMARK.BREAST_SCREEN_HIGHT),
                                            pBreastScreenImg,
                                            Parameter("@BREAST_SCREEN_SCALE", this.MG_BREASTMARK.BREAST_SCREEN_SCALE),
                                            Parameter("@NO_OF_MASS", this.MG_BREASTMARK.NO_OF_MASS),
                                            Parameter("@ORG_ID", this.MG_BREASTMARK.ORG_ID),
                                            Parameter("@LAST_MODIFIED_BY", this.MG_BREASTMARK.LAST_MODIFIED_BY)
                                       };

            return parameters;
        }
    }
}
