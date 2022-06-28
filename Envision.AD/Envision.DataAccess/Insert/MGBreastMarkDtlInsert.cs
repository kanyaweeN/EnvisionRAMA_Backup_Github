using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class MGBreastMarkDtlInsert : DataAccessBase
    {
        public MG_BREASTMARKDTL MG_BREASTMARKDTL { get; set; }
        public DbTransaction Trans { get; set; }
        public MGBreastMarkDtlInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMARKDTL_INSERT;
        }
        public void InsertData(bool UseTransaction)
        {
            this.ParameterList = this.BuildParameters();
            if (UseTransaction && (this.Trans != null))
                this.Transaction = this.Trans;
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@BREAST_MARK_ID", this.MG_BREASTMARKDTL.BREAST_MARK_ID),
                                            Parameter("@MARK_ID", this.MG_BREASTMARKDTL.MARK_ID),
                                            Parameter("@MASS_NO", this.MG_BREASTMARKDTL.MASS_NO),
                                            Parameter("@IS_US_FINDING", this.MG_BREASTMARKDTL.IS_US_FINDING),
                                            Parameter("@BREAST_VIEW", this.MG_BREASTMARKDTL.BREAST_VIEW),
                                            Parameter("@SHAPE", this.MG_BREASTMARKDTL.SHAPE),
                                            Parameter("@STYLE", this.MG_BREASTMARKDTL.STYLE),
                                            Parameter("@ORIGIN_X", this.MG_BREASTMARKDTL.ORIGIN_X),
                                            Parameter("@ORIGIN_Y", this.MG_BREASTMARKDTL.ORIGIN_Y),
                                            Parameter("@FILL_COLOR", this.MG_BREASTMARKDTL.FILL_COLOR),
                                            Parameter("@STROKE_COLOR", this.MG_BREASTMARKDTL.STROKE_COLOR),
                                            Parameter("@DIMENSION", this.MG_BREASTMARKDTL.DIMENSION),
                                            Parameter("@THICKNESS", this.MG_BREASTMARKDTL.THICKNESS),
                                            Parameter("@START_COOR_X", this.MG_BREASTMARKDTL.START_COOR_X),
                                            Parameter("@START_COOR_Y", this.MG_BREASTMARKDTL.START_COOR_Y),
                                            Parameter("@END_COOR_X", this.MG_BREASTMARKDTL.END_COOR_X),
                                            Parameter("@END_COOR_Y", this.MG_BREASTMARKDTL.END_COOR_Y),
                                            Parameter("@ANGLE", this.MG_BREASTMARKDTL.ANGLE),
                                            Parameter("@CLOCK_NO", this.MG_BREASTMARKDTL.CLOCK_NO),
                                            Parameter("@LOCATION_X", this.MG_BREASTMARKDTL.LOCATION_X),
                                            Parameter("@LOCATION_Y", this.MG_BREASTMARKDTL.LOCATION_Y),
                                            Parameter("@ORG_ID", this.MG_BREASTMARKDTL.ORG_ID),
                                            Parameter("@CREATED_BY", this.MG_BREASTMARKDTL.CREATED_BY),
                                       };

            return parameters;
        }
    }
}
