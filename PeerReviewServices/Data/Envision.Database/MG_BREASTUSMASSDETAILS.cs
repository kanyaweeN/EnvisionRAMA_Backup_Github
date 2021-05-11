namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MG_BREASTUSMASSDETAILS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte MASS_NO { get; set; }

        [StringLength(1)]
        public string BREAST_TYPE { get; set; }

        [StringLength(1)]
        public string FINDING_TYPE { get; set; }

        [StringLength(300)]
        public string MASS_LOCATION_ON_IMAGE { get; set; }

        [StringLength(300)]
        public string MASS_LOCATION_CLOCK { get; set; }

        [StringLength(1)]
        public string MASS_TYPE { get; set; }

        [StringLength(1)]
        public string MASS_CYST_TYPE { get; set; }

        [StringLength(1)]
        public string MASS_ORIENTATION { get; set; }

        [StringLength(1)]
        public string MASS_LESION_BOUNDARY { get; set; }

        [StringLength(1)]
        public string MASS_MARGIN { get; set; }

        [StringLength(1)]
        public string MASS_ECHO_PATTERN { get; set; }

        [StringLength(1)]
        public string MASS_POSTERIOR_ACOUSTIC_FEATURES { get; set; }

        [StringLength(200)]
        public string NO_OF_CALCIFICATION_OBJECTS { get; set; }

        [StringLength(1)]
        public string TYPE_OF_CALCIFICATION_OBJECT { get; set; }

        [StringLength(1)]
        public string TYPICALLY_BENIGN_SKIN { get; set; }

        [StringLength(1)]
        public string TYPICALLY_BENIGN_VASCULAR { get; set; }

        [StringLength(1)]
        public string TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE { get; set; }

        [StringLength(1)]
        public string TYPICALLY_BENIGN_LARGE_ROD_LIKE { get; set; }

        [StringLength(1)]
        public string TYPICALLY_BENIGN_ROUND { get; set; }

        [StringLength(1)]
        public string TYPICALLY_BENIGN_LUCENT_CENTERED { get; set; }

        [StringLength(1)]
        public string TYPICALLY_BENIGN_EGGSHELL_OR_RIM { get; set; }

        [StringLength(1)]
        public string TYPICALLY_BENIGN_MILK_OF_CALCIUM { get; set; }

        [StringLength(1)]
        public string TYPICALLY_BENIGN_SUTURE { get; set; }

        [StringLength(1)]
        public string TYPICALLY_BENIGN_DYSTROPHIC { get; set; }

        [StringLength(1)]
        public string INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT { get; set; }

        [StringLength(1)]
        public string INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS { get; set; }

        [StringLength(1)]
        public string HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC { get; set; }

        [StringLength(1)]
        public string HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR { get; set; }

        [StringLength(1)]
        public string DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED { get; set; }

        [StringLength(1)]
        public string DISTRIBUTION_MODIFIER_REGIONAL { get; set; }

        [StringLength(1)]
        public string DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED { get; set; }

        [StringLength(1)]
        public string DISTRIBUTION_MODIFIER_LINEAR { get; set; }

        [StringLength(1)]
        public string DISTRIBUTION_MODIFIER_SEGMENTAL { get; set; }

        [StringLength(200)]
        public string NO_OF_ARCHITECTURAL_DISTORTION { get; set; }

        [StringLength(1)]
        public string ARCHITECTURAL_DISTORTION_OBJECT_TYPE { get; set; }

        [StringLength(1)]
        public string ARCHITECTURAL_DISTORTION_TYPE { get; set; }

        [StringLength(200)]
        public string SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION { get; set; }

        [StringLength(1)]
        public string SPECIAL_CASE_TYPE { get; set; }

        [StringLength(1)]
        public string ASSOCIATE_FINDING_TYPE { get; set; }

        [StringLength(1)]
        public string AUXILIARY_LYMPH_NODE_TYPE { get; set; }

        [StringLength(1)]
        public string AUXILIARY_LYMPH_NODE_SIDE { get; set; }

        public byte? AUXILIARY_LYMPH_NODE_SIZE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? SIZE_X { get; set; }

        public int? SIZE_Y { get; set; }

        public int? SIZE_Z { get; set; }

        [StringLength(200)]
        public string ASSOCIATE_FINDING_TYPE_TEXT { get; set; }
    }
}
