using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class MGBreastUSMassDetailsInsert : DataAccessBase
    {
        public MG_BREASTUSMASSDETAILS MG_BREASTUSMASSDETAILS { get; set; }
        public DbTransaction Trans { get; set; }
        public MGBreastUSMassDetailsInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTUSMASSDETAILS_INSERT;
        }
        public void InsertData(bool UseTransaction)
        {
            this.ParameterList = this.BuildParameters();
            if (UseTransaction && (this.Trans != null))
                this.Transaction = Trans;
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@ACCESSION_NO", this.MG_BREASTUSMASSDETAILS.ACCESSION_NO),
                                            Parameter("@MASS_NO", this.MG_BREASTUSMASSDETAILS.MASS_NO),
                                            Parameter("@BREAST_TYPE", this.MG_BREASTUSMASSDETAILS.BREAST_TYPE),
                                            Parameter("@FINDING_TYPE", this.MG_BREASTUSMASSDETAILS.FINDING_TYPE),
                                            Parameter("@MASS_LOCATION_ON_IMAGE", this.MG_BREASTUSMASSDETAILS.MASS_LOCATION_ON_IMAGE),
                                            Parameter("@MASS_LOCATION_CLOCK", this.MG_BREASTUSMASSDETAILS.MASS_LOCATION_CLOCK),
                                            Parameter("@MASS_TYPE", this.MG_BREASTUSMASSDETAILS.MASS_TYPE),
                                            Parameter("@MASS_CYST_TYPE", this.MG_BREASTUSMASSDETAILS.MASS_CYST_TYPE),
                                            Parameter("@MASS_ORIENTATION", this.MG_BREASTUSMASSDETAILS.MASS_ORIENTATION),
                                            Parameter("@MASS_MARGIN", this.MG_BREASTUSMASSDETAILS.MASS_MARGIN),
                                            Parameter("@MASS_LESION_BOUNDARY", this.MG_BREASTUSMASSDETAILS.MASS_LESION_BOUNDARY),
                                            Parameter("@MASS_ECHO_PATTERN", this.MG_BREASTUSMASSDETAILS.MASS_ECHO_PATTERN),
                                            Parameter("@MASS_POSTERIOR_ACOUSTIC_FEATURES", this.MG_BREASTUSMASSDETAILS.MASS_POSTERIOR_ACOUSTIC_FEATURES),                                            
                                            Parameter("@NO_OF_CALCIFICATION_OBJECTS", this.MG_BREASTUSMASSDETAILS.NO_OF_CALCIFICATION_OBJECTS),
                                            Parameter("@TYPE_OF_CALCIFICATION_OBJECT", this.MG_BREASTUSMASSDETAILS.TYPE_OF_CALCIFICATION_OBJECT),
                                            Parameter("@TYPICALLY_BENIGN_SKIN", this.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_SKIN),
                                            Parameter("@TYPICALLY_BENIGN_LARGE_ROD_LIKE", this.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_LARGE_ROD_LIKE),
                                            Parameter("@TYPICALLY_BENIGN_VASCULAR", this.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_VASCULAR),
                                            Parameter("@TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE", this.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE),
                                            Parameter("@TYPICALLY_BENIGN_ROUND", this.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_ROUND),
                                            Parameter("@TYPICALLY_BENIGN_LUCENT_CENTERED", this.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_LUCENT_CENTERED),
                                            Parameter("@TYPICALLY_BENIGN_EGGSHELL_OR_RIM", this.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_EGGSHELL_OR_RIM),
                                            Parameter("@TYPICALLY_BENIGN_MILK_OF_CALCIUM", this.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_MILK_OF_CALCIUM),
                                            Parameter("@TYPICALLY_BENIGN_SUTURE", this.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_SUTURE),
                                            Parameter("@TYPICALLY_BENIGN_DYSTROPHIC", this.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_DYSTROPHIC),
                                            Parameter("@INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT", this.MG_BREASTUSMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT),
                                            Parameter("@INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS", this.MG_BREASTUSMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS),
                                            Parameter("@HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC", this.MG_BREASTUSMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC),
                                            Parameter("@HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR", this.MG_BREASTUSMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR),
                                            Parameter("@DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED", this.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED),
                                            Parameter("@DISTRIBUTION_MODIFIER_REGIONAL", this.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_REGIONAL),
                                            Parameter("@DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED", this.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED),
                                            Parameter("@DISTRIBUTION_MODIFIER_LINEAR", this.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_LINEAR),
                                            Parameter("@DISTRIBUTION_MODIFIER_SEGMENTAL", this.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_SEGMENTAL),
                                            Parameter("@NO_OF_ARCHITECTURAL_DISTORTION", this.MG_BREASTUSMASSDETAILS.NO_OF_ARCHITECTURAL_DISTORTION),
                                            Parameter("@ARCHITECTURAL_DISTORTION_OBJECT_TYPE", this.MG_BREASTUSMASSDETAILS.ARCHITECTURAL_DISTORTION_OBJECT_TYPE),
                                            Parameter("@ARCHITECTURAL_DISTORTION_TYPE", this.MG_BREASTUSMASSDETAILS.ARCHITECTURAL_DISTORTION_TYPE),
                                            Parameter("@SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION", this.MG_BREASTUSMASSDETAILS.SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION),
                                            Parameter("@SPECIAL_CASE_TYPE", this.MG_BREASTUSMASSDETAILS.SPECIAL_CASE_TYPE),
                                            Parameter("@AUXILIARY_LYMPH_NODE_TYPE", this.MG_BREASTUSMASSDETAILS.AUXILIARY_LYMPH_NODE_TYPE),
                                            Parameter("@AUXILIARY_LYMPH_NODE_SIDE", this.MG_BREASTUSMASSDETAILS.AUXILIARY_LYMPH_NODE_SIDE),
                                            Parameter("@AUXILIARY_LYMPH_NODE_SIZE", this.MG_BREASTUSMASSDETAILS.AUXILIARY_LYMPH_NODE_SIZE),
                                            Parameter("@ASSOCIATE_FINDING_TYPE", this.MG_BREASTUSMASSDETAILS.ASSOCIATE_FINDING_TYPE),
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
                                            Parameter("@ORG_ID", this.MG_BREASTUSMASSDETAILS.ORG_ID),
                                            Parameter("@CREATED_BY", this.MG_BREASTUSMASSDETAILS.CREATED_BY),
                                            Parameter("@SIZE_X", this.MG_BREASTUSMASSDETAILS.SIZE_X),
                                            Parameter("@SIZE_Y", this.MG_BREASTUSMASSDETAILS.SIZE_Y),
                                            Parameter("@SIZE_Z", this.MG_BREASTUSMASSDETAILS.SIZE_Z),
                                            Parameter("@ASSOCIATE_FINDING_TYPE_TEXT", this.MG_BREASTUSMASSDETAILS.ASSOCIATE_FINDING_TYPE_TEXT)
                                       };

            return parameters;
        }
    }
}
