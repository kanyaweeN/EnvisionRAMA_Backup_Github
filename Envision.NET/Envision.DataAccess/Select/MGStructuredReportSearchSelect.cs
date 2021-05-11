using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class MGStructuredReportSearchSelect : DataAccessBase
    {
        public MG_BREASTEXAMRESULT MG_BREASTEXAMRESULT { get; set; }
        public MG_BREASTMASSDETAILS MG_BREASTMASSDETAILS { get; set; }
        public MG_BREASTUSMASSDETAILS MG_BREASTUSMASSDETAILS { get; set; }
 
        public MGStructuredReportSearchSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MGStructuredReportSearch;
        }

        public DataSet GetData(DateTime dtFrom, DateTime dtTo, bool isSearchByUS, bool isSearchAll)
        {
            this.ParameterList = this.BuildParameters(dtFrom, dtTo, isSearchByUS, isSearchAll);
            return this.ExecuteDataSet();
        }

        private DbParameter[] BuildParameters(DateTime dtFrom, DateTime dtTo, bool isSearchByUS, bool isSearchAll)
        {
            DbParameter[] parameters = { 
                                            Parameter("FROM_DT", dtFrom),
                                            Parameter("TO_DT", dtTo),
                                            Parameter("IS_SEARCH_BY_US", isSearchByUS == true ? "Y" : "N"),
                                            Parameter("IS_SEARCH_ALL", isSearchAll == true ? "Y" : "N"),
                                            Parameter("BREAST_COMPOSITION", MG_BREASTEXAMRESULT.BREAST_COMPOSITION),
                                            Parameter("CLINICAL_HISTORY_TYPE",MG_BREASTEXAMRESULT.CLINICAL_HISTORY_TYPE),
                                            Parameter("FAMILY_HISTORY_OF_BREAST_CANCER",MG_BREASTEXAMRESULT.FAMILY_HISTORY_OF_BREAST_CANCER),
                                            Parameter("FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE",MG_BREASTEXAMRESULT.FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE),
                                            Parameter("FINAL_ASSESSMENT_TYPE",MG_BREASTEXAMRESULT.FINAL_ASSESSMENT_TYPE),
                                            Parameter("IS_MG_NEGATIVE",MG_BREASTEXAMRESULT.IS_MG_NEGATIVE),
                                            Parameter("IS_MULTIPLE_MASS",MG_BREASTEXAMRESULT.IS_MULTIPLE_MASS),
                                            Parameter("IS_US_NEGATIVE",MG_BREASTEXAMRESULT.IS_US_NEGATIVE),
                                            Parameter("NO_OF_MASS",MG_BREASTEXAMRESULT.NO_OF_MASS),
                                            Parameter("PATIENT_TYPE",MG_BREASTEXAMRESULT.PATIENT_TYPE),
                                            Parameter("PERSONAL_HISTORY_OF_BREAST_CANCER",MG_BREASTEXAMRESULT.PERSONAL_HISTORY_OF_BREAST_CANCER),
                                            Parameter("PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE",MG_BREASTEXAMRESULT.PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE),
                                            Parameter("RECOMMENDATION_TYPE",MG_BREASTEXAMRESULT.RECOMMENDATION_TYPE),
                                            Parameter("ARCHITECTURAL_DISTORTION_OBJECT_TYPE",MG_BREASTMASSDETAILS.ARCHITECTURAL_DISTORTION_OBJECT_TYPE),
                                            Parameter("ARCHITECTURAL_DISTORTION_TYPE",MG_BREASTMASSDETAILS.ARCHITECTURAL_DISTORTION_TYPE),
                                            Parameter("ASSOCIATE_FINDING_TYPE",MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_TYPE),
                                            Parameter("BREAST_TYPE",MG_BREASTMASSDETAILS.BREAST_TYPE),
                                            Parameter("DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED",MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED),
                                            Parameter("DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED",MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED),
                                            Parameter("DISTRIBUTION_MODIFIER_LINEAR",MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_LINEAR),
                                            Parameter("DISTRIBUTION_MODIFIER_REGIONAL",MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_REGIONAL),
                                            Parameter("DISTRIBUTION_MODIFIER_SEGMENTAL",MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_SEGMENTAL),
                                            Parameter("FINDING_TYPE",MG_BREASTMASSDETAILS.FINDING_TYPE),
                                            Parameter("HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR",MG_BREASTMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR),
                                            Parameter("HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC",MG_BREASTMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC),
                                            Parameter("INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT",MG_BREASTMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT),
                                            Parameter("INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS",MG_BREASTMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS),
                                            Parameter("MASS_DENSITY",MG_BREASTMASSDETAILS.MASS_DENSITY),
                                            Parameter("MASS_DENSITY_TYPE",MG_BREASTMASSDETAILS.MASS_DENSITY_TYPE),
                                            Parameter("MASS_HAS_CALCIFICATION",MG_BREASTMASSDETAILS.MASS_HAS_CALCIFICATION),
                                            Parameter("MASS_LOCATION_CLOCK",MG_BREASTMASSDETAILS.MASS_LOCATION_CLOCK),
                                            Parameter("MASS_MARGIN",MG_BREASTMASSDETAILS.MASS_MARGIN),
                                            Parameter("MASS_SHAPE",MG_BREASTMASSDETAILS.MASS_SHAPE),
                                            Parameter("NO_OF_ARCHITECTURAL_DISTORTION",MG_BREASTMASSDETAILS.NO_OF_ARCHITECTURAL_DISTORTION),
                                            Parameter("NO_OF_CALCIFICATION_OBJECTS",MG_BREASTMASSDETAILS.NO_OF_CALCIFICATION_OBJECTS),
                                            Parameter("TYPE_OF_CALCIFICATION_OBJECT",MG_BREASTMASSDETAILS.TYPE_OF_CALCIFICATION_OBJECT),
                                            Parameter("TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE",MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE),
                                            Parameter("TYPICALLY_BENIGN_DYSTROPHIC",MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_DYSTROPHIC),
                                            Parameter("TYPICALLY_BENIGN_EGGSHELL_OR_RIM",MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_EGGSHELL_OR_RIM),
                                            Parameter("TYPICALLY_BENIGN_LARGE_ROD_LIKE",MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_LARGE_ROD_LIKE),
                                            Parameter("TYPICALLY_BENIGN_LUCENT_CENTERED",MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_LUCENT_CENTERED),
                                            Parameter("TYPICALLY_BENIGN_MILK_OF_CALCIUM",MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_MILK_OF_CALCIUM),
                                            Parameter("TYPICALLY_BENIGN_ROUND",MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_ROUND),
                                            Parameter("TYPICALLY_BENIGN_SKIN",MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_SKIN),
                                            Parameter("TYPICALLY_BENIGN_SUTURE",MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_SUTURE),
                                            Parameter("TYPICALLY_BENIGN_VASCULAR",MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_VASCULAR),
                                            Parameter("MASS_CYST_TYPE",MG_BREASTUSMASSDETAILS.MASS_CYST_TYPE),
                                            Parameter("MASS_ECHO_PATTERN",MG_BREASTUSMASSDETAILS.MASS_ECHO_PATTERN),
                                            Parameter("MASS_LESION_BOUNDARY",MG_BREASTUSMASSDETAILS.MASS_LESION_BOUNDARY),
                                            Parameter("MASS_MARGIN_US",MG_BREASTUSMASSDETAILS.MASS_MARGIN),
                                            Parameter("MASS_ORIENTATION",MG_BREASTUSMASSDETAILS.MASS_ORIENTATION),
                                            Parameter("MASS_POSTERIOR_ACOUSTIC_FEATURES",MG_BREASTUSMASSDETAILS.MASS_POSTERIOR_ACOUSTIC_FEATURES),
                                            Parameter("MASS_TYPE",MG_BREASTUSMASSDETAILS.MASS_TYPE)
                                       };
            return parameters;
        }
    }
}
