using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class MGBreastMassDetailsUpdate : DataAccessBase
    {
        public MG_BREASTMASSDETAILS MG_BREASTMASSDETAILS { get; set; }
        public MGBreastMassDetailsUpdate()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMASSDETAILS_UPDATE;
        }

        public void UpdateData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@ACCESSION_NO", this.MG_BREASTMASSDETAILS.ACCESSION_NO),
                                            Parameter("@MASS_NO", this.MG_BREASTMASSDETAILS.MASS_NO),
                                            Parameter("@BREAST_TYPE", this.MG_BREASTMASSDETAILS.BREAST_TYPE),
                                            Parameter("@MASS_LOCATION_ON_IMAGE", this.MG_BREASTMASSDETAILS.MASS_LOCATION_ON_IMAGE),
                                            Parameter("@MASS_LOCATION_CLOCK", this.MG_BREASTMASSDETAILS.MASS_LOCATION_CLOCK),
                                            Parameter("@MASS_SHAPE", this.MG_BREASTMASSDETAILS.MASS_SHAPE),
                                            Parameter("@MASS_MARGIN", this.MG_BREASTMASSDETAILS.MASS_MARGIN),
                                            Parameter("@MASS_DENSITY", this.MG_BREASTMASSDETAILS.MASS_DENSITY),
                                            Parameter("@MASS_DENSITY_TYPE", this.MG_BREASTMASSDETAILS.MASS_DENSITY_TYPE),
                                            Parameter("@MASS_HAS_CALCIFICATION", this.MG_BREASTMASSDETAILS.MASS_HAS_CALCIFICATION),
                                            Parameter("@NO_OF_CALCIFICATION_OBJECTS", this.MG_BREASTMASSDETAILS.NO_OF_CALCIFICATION_OBJECTS),
                                            Parameter("@TYPE_OF_CALCIFICATION_OBJECT", this.MG_BREASTMASSDETAILS.TYPE_OF_CALCIFICATION_OBJECT),
                                            Parameter("@TYPICALLY_BENIGN_SKIN", this.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_SKIN),
                                            Parameter("@TYPICALLY_BENIGN_LARGE_ROD_LIKE", this.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_LARGE_ROD_LIKE),
                                            Parameter("@TYPICALLY_BENIGN_VASCULAR", this.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_VASCULAR),
                                            Parameter("@TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE", this.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE),
                                            Parameter("@TYPICALLY_BENIGN_ROUND", this.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_ROUND),
                                            Parameter("@TYPICALLY_BENIGN_LUCENT_CENTERED", this.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_LUCENT_CENTERED),
                                            Parameter("@TYPICALLY_BENIGN_EGGSHELL_OR_RIM", this.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_EGGSHELL_OR_RIM),
                                            Parameter("@TYPICALLY_BENIGN_MILK_OF_CALCIUM", this.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_MILK_OF_CALCIUM),
                                            Parameter("@TYPICALLY_BENIGN_SUTURE", this.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_SUTURE),
                                            Parameter("@TYPICALLY_BENIGN_DYSTROPHIC", this.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_DYSTROPHIC),
                                            Parameter("@INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT", this.MG_BREASTMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT),
                                            Parameter("@INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS", this.MG_BREASTMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS),
                                            Parameter("@HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC", this.MG_BREASTMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC),
                                            Parameter("@HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR", this.MG_BREASTMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR),
                                            Parameter("@DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED", this.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED),
                                            Parameter("@DISTRIBUTION_MODIFIER_REGIONAL", this.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_REGIONAL),
                                            Parameter("@DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED", this.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED),
                                            Parameter("@DISTRIBUTION_MODIFIER_LINEAR", this.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_LINEAR),
                                            Parameter("@DISTRIBUTION_MODIFIER_SEGMENTAL", this.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_SEGMENTAL),
                                            Parameter("@NO_OF_ARCHITECTURAL_DISTORTION", this.MG_BREASTMASSDETAILS.NO_OF_ARCHITECTURAL_DISTORTION),
                                            Parameter("@ARCHITECTURAL_DISTORTION_OBJECT_TYPE", this.MG_BREASTMASSDETAILS.ARCHITECTURAL_DISTORTION_OBJECT_TYPE),
                                            Parameter("@ARCHITECTURAL_DISTORTION_TYPE", this.MG_BREASTMASSDETAILS.ARCHITECTURAL_DISTORTION_TYPE),
                                            Parameter("@SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION", this.MG_BREASTMASSDETAILS.SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION),
                                            Parameter("@SPECIAL_CASE_TPYE", this.MG_BREASTMASSDETAILS.SPECIAL_CASE_TYPE),
                                            Parameter("@SPECIAL_CASE_TYPE", this.MG_BREASTMASSDETAILS.SPECIAL_CASE_TYPE),
                                            Parameter("@AUXILIARY_LYMPH_NODE_TYPE", this.MG_BREASTMASSDETAILS.AUXILIARY_LYMPH_NODE_TYPE),
                                            Parameter("@AUXILIARY_LYMPH_NODE_SIDE", this.MG_BREASTMASSDETAILS.AUXILIARY_LYMPH_NODE_SIDE),
                                            Parameter("@AUXILIARY_LYMPH_NODE_SIZE", this.MG_BREASTMASSDETAILS.AUXILIARY_LYMPH_NODE_SIZE),
                                            Parameter("@ASSOCIATE_FINDING_TYPE", this.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_TYPE),
                                            //Parameter("@SPECIAL_CASE_TYPE_ASYMMETRIC_TUBULAR_STRUCTURE", this.MG_BREASTMASSDETAILS.SPECIAL_CASE_TYPE_ASYMMETRIC_TUBULAR_STRUCTURE),
                                            //Parameter("@SPECIAL_CASE_TYPE_INTRAMAMMARY_LYMPH_NODE", this.MG_BREASTMASSDETAILS.SPECIAL_CASE_TYPE_INTRAMAMMARY_LYMPH_NODE),
                                            //Parameter("@SPECIAL_CASE_TYPE_GLOBAL_ASYMMETRY", this.MG_BREASTMASSDETAILS.SPECIAL_CASE_TYPE_GLOBAL_ASYMMETRY),
                                            //Parameter("@SPECIAL_CASE_TYPE_FOCAL_ASYMMETRY", this.MG_BREASTMASSDETAILS.SPECIAL_CASE_TYPE_FOCAL_ASYMMETRY),
                                            //Parameter("@SPECIAL_CASE_TYPE_FOCAL_ASYMMETRY_LOCATION", this.MG_BREASTMASSDETAILS.SPECIAL_CASE_TYPE_FOCAL_ASYMMETRY_LOCATION),
                                            //Parameter("@ASSOCIATE_FINDING_SKIN_RETRACTION", this.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_SKIN_RETRACTION),
                                            //Parameter("@ASSOCIATE_FINDING_NIPPLE_RETRACTION", this.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_NIPPLE_RETRACTION),
                                            //Parameter("@ASSOCIATE_FINDING_SKIN_THICKENING", this.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_SKIN_THICKENING),
                                            //Parameter("@ASSOCIATE_FINDING_TRABECULAR_THICKENING", this.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_TRABECULAR_THICKENING),
                                            //Parameter("@ASSOCIATE_FINDING_SKIN_LESION", this.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_SKIN_LESION),
                                            //Parameter("@ASSOCIATE_FINDING_AXILLARY", this.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_AXILLARY),
                                            Parameter("@ORG_ID", this.MG_BREASTMASSDETAILS.ORG_ID),
                                            Parameter("@LAST_MODIFIED_BY", this.MG_BREASTMASSDETAILS.LAST_MODIFIED_BY),
                                            Parameter("@SIZE_X", this.MG_BREASTMASSDETAILS.SIZE_X),
                                            Parameter("@SIZE_Y", this.MG_BREASTMASSDETAILS.SIZE_Y),
                                            Parameter("@SIZE_Z", this.MG_BREASTMASSDETAILS.SIZE_Z),
                                            Parameter("@ASSOCIATE_FINDING_TYPE_TEXT", this.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_TYPE_TEXT)
                                       };

            return parameters;
        }
    }
}
