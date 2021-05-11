using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class MGBreastExamResultInsert : DataAccessBase
    {
        public MG_BREASTEXAMRESULT MG_BREASTEXAMRESULT { get; set; }
        public DbTransaction Trans { get; set; }
        public MGBreastExamResultInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTEXAMRESULT_INSERT;
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
            DbParameter pReporting_Date = null;
            if (this.MG_BREASTEXAMRESULT.REPORTING_DATE == DateTime.MinValue)
                pReporting_Date = Parameter("@REPORTING_DATE", DBNull.Value);
            else
                pReporting_Date = Parameter("@REPORTING_DATE", this.MG_BREASTEXAMRESULT.REPORTING_DATE);
            DbParameter[] parameters = {
                                           Parameter("@ACCESSION_NO", this.MG_BREASTEXAMRESULT.ACCESSION_NO),
                                           pReporting_Date,
                                           Parameter("@PATIENT_TYPE", this.MG_BREASTEXAMRESULT.PATIENT_TYPE),
                                           Parameter("@PATIENT_TYPE_TEXT", this.MG_BREASTEXAMRESULT.PATIENT_TYPE_TEXT),
                                           Parameter("@BREAST_COMPOSITION", this.MG_BREASTEXAMRESULT.BREAST_COMPOSITION),
                                           Parameter("@IS_MULTIPLE_MASS", this.MG_BREASTEXAMRESULT.IS_MULTIPLE_MASS),
                                           Parameter("@HAS_DOMINANT_CYST", this.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST),
                                           Parameter("@IS_MG_NEGATIVE", this.MG_BREASTEXAMRESULT.IS_MG_NEGATIVE),
                                           Parameter("@IS_US_NEGATIVE", this.MG_BREASTEXAMRESULT.IS_US_NEGATIVE),
                                           Parameter("@PERSONAL_HISTORY_OF_BREAST_CANCER", this.MG_BREASTEXAMRESULT.PERSONAL_HISTORY_OF_BREAST_CANCER),
                                           Parameter("@PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE", this.MG_BREASTEXAMRESULT.PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE),
                                           Parameter("@FAMILY_HISTORY_OF_BREAST_CANCER", this.MG_BREASTEXAMRESULT.FAMILY_HISTORY_OF_BREAST_CANCER),
                                           Parameter("@FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE", this.MG_BREASTEXAMRESULT.FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE),
                                           Parameter("@CLINICAL_HISTORY_TYPE", this.MG_BREASTEXAMRESULT.CLINICAL_HISTORY_TYPE),
                                           Parameter("@IMPRESSION_TEXT", this.MG_BREASTEXAMRESULT.IMPRESSION_TEXT),
                                           Parameter("@FINAL_ASSESSMENT_TYPE", this.MG_BREASTEXAMRESULT.FINAL_ASSESSMENT_TYPE),
                                           Parameter("@RECOMMENDATION_TYPE", this.MG_BREASTEXAMRESULT.RECOMMENDATION_TYPE),
                                           Parameter("@RECOMMENDATION_TYPE_WITH_BREAST_SIDE", this.MG_BREASTEXAMRESULT.RECOMMENDATION_TYPE_WITH_BREAST_SIDE),
                                           Parameter("@RECOMMENDATION_TYPE_TEXT", this.MG_BREASTEXAMRESULT.RECOMMENDATION_TYPE_TEXT),
                                           Parameter("@NO_OF_MASS", this.MG_BREASTEXAMRESULT.NO_OF_MASS),
                                           Parameter("@PRELIM_BY", this.MG_BREASTEXAMRESULT.PRELIM_BY),
                                           Parameter("@FINALIZED_BY", this.MG_BREASTEXAMRESULT.FINALIZED_BY),
                                           Parameter("@ORG_ID", this.MG_BREASTEXAMRESULT.ORG_ID),
                                           Parameter("@CREATED_BY", this.MG_BREASTEXAMRESULT.CREATED_BY),
                                           Parameter("@REPORT_STATUS", this.MG_BREASTEXAMRESULT.REPORT_STATUS),
                                           Parameter("@IS_MULTIPLE_CYST", this.MG_BREASTEXAMRESULT.IS_MULTIPLE_CYST),
                                           Parameter("@BREAST_IMAGE_LEFT", this.MG_BREASTEXAMRESULT.BREAST_IMAGE_LEFT),
                                           Parameter("@BREAST_IMAGE_RIGHT", this.MG_BREASTEXAMRESULT.BREAST_IMAGE_RIGHT),
                                           Parameter("@SHOW_BREAST_IMAGE_LEFT", this.MG_BREASTEXAMRESULT.SHOW_BREAST_IMAGE_LEFT),
                                           Parameter("@SHOW_BREAST_IMAGE_RIGHT", this.MG_BREASTEXAMRESULT.SHOW_BREAST_IMAGE_RIGHT),
                                           Parameter("@COMMENT", this.MG_BREASTEXAMRESULT.COMMENT)
                                       };
            return parameters;
        }
    }
}
