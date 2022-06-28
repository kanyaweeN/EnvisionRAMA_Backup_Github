using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Envision.Common
{
    public class MG_BREASTMASSDETAILS : INotifyPropertyChanged
    {
        public string ACCESSION_NO { get; set; }
        public int MASS_NO { get; set; }
        public string BREAST_TYPE { get; set; }
        private string _FINDING_TYPE = "A";
        /// <summary>
        /// Get or Set Finding Type
        /// </summary>
        public string FINDING_TYPE
        {
            get { return _FINDING_TYPE; }
            set { _FINDING_TYPE = value; }
        }
        private string _MASS_LOCATION_ON_IMAGE = string.Empty;
        /// <summary>
        /// Get or set mass location on image (x,y)
        /// </summary>
        public string MASS_LOCATION_ON_IMAGE
        {
            get { return _MASS_LOCATION_ON_IMAGE; }
            set { _MASS_LOCATION_ON_IMAGE = value; }
        }
        private string _MASS_LOCATION_CLOCK = "0";
        /// <summary>
        /// Get or set mass location clock
        /// </summary>
        public string MASS_LOCATION_CLOCK
        {
            get { return _MASS_LOCATION_CLOCK; }
            set { _MASS_LOCATION_CLOCK = value; }
        }
        /// <summary>
        /// Get or set mass shape
        /// </summary>
        private string _MASS_SHAPE = string.Empty;
        public string MASS_SHAPE
        {
            get { return _MASS_SHAPE; }
            set { _MASS_SHAPE = value; }
        }
        private string _MASS_MARGIN = string.Empty;
        /// <summary>
        /// Get or set mass margin
        /// </summary>
        public string MASS_MARGIN
        {
            get { return _MASS_MARGIN; }
            set { _MASS_MARGIN = value; }
        }
        private string _MASS_DENSITY = string.Empty;
        /// <summary>
        /// Get or set mass density
        /// </summary>
        public string MASS_DENSITY
        {
            get { return _MASS_MARGIN; }
            set { _MASS_MARGIN = value; }
        }

        public string _MASS_DENSITY_TYPE = string.Empty;
        /// <summary>
        /// Get or set mass has fat
        /// </summary>
        public string MASS_DENSITY_TYPE
        {
            get { return _MASS_DENSITY_TYPE; }
            set { _MASS_DENSITY_TYPE = value; }
        }

        private string _MASS_HAS_CALCIFICATION = string.Empty;
        /// <summary>
        /// Get or set mass has calcification
        /// </summary>
        public string MASS_HAS_CALCIFICATION
        {
            get { return _MASS_HAS_CALCIFICATION; }
            set { _MASS_HAS_CALCIFICATION = value; }
        }

        private string _NO_OF_CALCIFICATION_OBJECTS = "0";
        /// <summary>
        /// Get or set number of calcification
        /// </summary>
        public string NO_OF_CALCIFICATION_OBJECTS
        {
            get { return _NO_OF_CALCIFICATION_OBJECTS; }
            set { _NO_OF_CALCIFICATION_OBJECTS = value; }
        }

        private string _TYPE_OF_CALCIFICATION_OBJECT = "M";
        /// <summary>
        /// Get or set calcification object type
        /// </summary>
        public string TYPE_OF_CALCIFICATION_OBJECT
        {
            get { return _TYPE_OF_CALCIFICATION_OBJECT; }
            set { _TYPE_OF_CALCIFICATION_OBJECT = value; }
        }

        public string _TYPICALLY_BENIGN_SKIN = "N";
        /// <summary>
        /// Get or set Benign skin
        /// </summary>
        public string TYPICALLY_BENIGN_SKIN
        {
            get { return _TYPICALLY_BENIGN_SKIN; }
            set { _TYPICALLY_BENIGN_SKIN = value; }
        }

        private string _TYPICALLY_BENIGN_VASCULAR = "N";
        /// <summary>
        /// Get or set Bengin vascular
        /// </summary>
        public string TYPICALLY_BENIGN_VASCULAR 
        {
            get { return _TYPICALLY_BENIGN_VASCULAR; }
            set
            {
                _TYPICALLY_BENIGN_VASCULAR = value;
            }
        }
        private string _TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = "N";
        /// <summary>
        /// Get or set coarse or popcorn like
        /// </summary>
        public string TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE
        {
            get { return _TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE; }
            set { _TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = value; }
        }

        private string _TYPICALLY_BENIGN_ROUND = "N";
        /// <summary>
        /// Get or set  benign round
        /// </summary>
        public string TYPICALLY_BENIGN_ROUND
        {
            get { return _TYPICALLY_BENIGN_ROUND; }
            set { _TYPICALLY_BENIGN_ROUND = value; }
        }

        private string _TYPICALLY_BENIGN_LARGE_ROD_LIKE = "N";
        /// <summary>
        /// Get or set bengin large rod like
        /// </summary>
        public string TYPICALLY_BENIGN_LARGE_ROD_LIKE
        {
            get { return _TYPICALLY_BENIGN_LARGE_ROD_LIKE; }
            set { _TYPICALLY_BENIGN_LARGE_ROD_LIKE = value; }
        }

        public string _TYPICALLY_BENIGN_LUCENT_CENTERED = "N";
        /// <summary>
        /// Get or set benign lucent centered
        /// </summary>
        public string TYPICALLY_BENIGN_LUCENT_CENTERED
        {
            get { return _TYPICALLY_BENIGN_LUCENT_CENTERED; }
            set { _TYPICALLY_BENIGN_LUCENT_CENTERED = value; }
        }

        private string _TYPICALLY_BENIGN_EGGSHELL_OR_RIM = "N";
        /// <summary>
        /// Get or set benign eggshell or rim
        /// </summary>
        public string TYPICALLY_BENIGN_EGGSHELL_OR_RIM
        {
            get { return _TYPICALLY_BENIGN_EGGSHELL_OR_RIM; }
            set { _TYPICALLY_BENIGN_EGGSHELL_OR_RIM = value; }
        }

        private string _TYPICALLY_BENIGN_MILK_OF_CALCIUM = "N";
        /// <summary>
        /// Get or set bengin milk of calcium
        /// </summary>
        public string TYPICALLY_BENIGN_MILK_OF_CALCIUM
        {
            get { return _TYPICALLY_BENIGN_MILK_OF_CALCIUM; }
            set { _TYPICALLY_BENIGN_MILK_OF_CALCIUM = value; }
        }

        private string _TYPICALLY_BENIGN_SUTURE = "N";
        /// <summary>
        /// Get or set benign suture
        /// </summary>
        public string TYPICALLY_BENIGN_SUTURE
        {
            get { return _TYPICALLY_BENIGN_SUTURE; }
            set { _TYPICALLY_BENIGN_SUTURE = value; }
        }

        private string _TYPICALLY_BENIGN_DYSTROPHIC = "N";
        /// <summary>
        /// Get or set benign dystrophic
        /// </summary>
        public string TYPICALLY_BENIGN_DYSTROPHIC
        {
            get { return _TYPICALLY_BENIGN_DYSTROPHIC; }
            set { _TYPICALLY_BENIGN_DYSTROPHIC = value; }
        }

        private string _INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = "N";
        /// <summary>
        /// Get or set concern supicious amorphous or indistinct
        /// </summary>
        public string INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT
        {
            get { return _INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT; }
            set { _INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = value; }
        }

        private string _INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = "N";
        /// <summary>
        /// Get or set concern suspicious coarse heterogenous
        /// </summary>
        public string INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS
        {
            get { return _INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS; }
            set { _INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = value; }
        }

        public string _HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = "N";
        /// <summary>
        /// Get or set higher probability of malignancy fine pleomorphic
        /// </summary>
        public string HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC
        {
            get { return _HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC; }
            set { _HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = value; }
        }

        private string _HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = "N";
        /// <summary>
        /// Get or set higher probability of maliganacy fine linear
        /// </summary>
        public string HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR
        {
            get { return _HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR; }
            set { _HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = value; }
        }

        private string _DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = "N";
        /// <summary>
        /// Get or set distribution modifier diffuse scattered
        /// </summary>
        public string DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED
        {
            get { return _DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED; }
            set { _DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = value; }
        }

        private string _DISTRIBUTION_MODIFIER_REGIONAL = "N";
        /// <summary>
        /// Get or set distribution modifier regional
        /// </summary>
        public string DISTRIBUTION_MODIFIER_REGIONAL
        {
            get { return _DISTRIBUTION_MODIFIER_REGIONAL; }
            set { _DISTRIBUTION_MODIFIER_REGIONAL = value; }
        }

        private string _DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED { get; set; }
        /// <summary>
        /// Get or set distribution modifer grouped or clustered
        /// </summary>
        public string DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED
        {
            get { return _DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED; }
            set { _DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = value; }
        }

        private string _DISTRIBUTION_MODIFIER_LINEAR = "N";
        /// <summary>
        /// Get or set distribution modifier liner
        /// </summary>
        public string DISTRIBUTION_MODIFIER_LINEAR
        {
            get { return _DISTRIBUTION_MODIFIER_LINEAR; }
            set { _DISTRIBUTION_MODIFIER_LINEAR = value; }
        }

        private string _DISTRIBUTION_MODIFIER_SEGMENTAL = "N";
        /// <summary>
        /// Get or set distribution modifier segmental
        /// </summary>
        public string DISTRIBUTION_MODIFIER_SEGMENTAL
        {
            get { return _DISTRIBUTION_MODIFIER_SEGMENTAL; }
            set { _DISTRIBUTION_MODIFIER_SEGMENTAL = value; }
        }

        public string _NO_OF_ARCHITECTURAL_DISTORTION = "0";
        /// <summary>
        /// Get or set number of architectural distortion
        /// </summary>
        public string NO_OF_ARCHITECTURAL_DISTORTION
        {
            get { return _NO_OF_ARCHITECTURAL_DISTORTION; }
            set { _NO_OF_ARCHITECTURAL_DISTORTION = value; }
        }

        private string _ARCHITECTURAL_DISTORTION_OBJECT_TYPE = "M";
        /// <summary>
        /// Get or set architectural distortion object type
        /// </summary>
        public string ARCHITECTURAL_DISTORTION_OBJECT_TYPE
        {
            get { return _ARCHITECTURAL_DISTORTION_OBJECT_TYPE; }
            set { _ARCHITECTURAL_DISTORTION_OBJECT_TYPE = value; }
        }

        public string _ARCHITECTURAL_DISTORTION_TYPE = string.Empty;
        /// <summary>
        /// Get or set architectural distortion type
        /// </summary>
        public string ARCHITECTURAL_DISTORTION_TYPE
        {
            get { return _ARCHITECTURAL_DISTORTION_TYPE; }
            set { _ARCHITECTURAL_DISTORTION_TYPE = value; }
        }

        private string _SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION = "0";
        /// <summary>
        /// Get or set special case no of architectural distortion
        /// </summary>
        public string SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION
        {
            get { return _SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION; }
            set { _SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION = value; }
        }

        private string _SPECIAL_CASE_TYPE = string.Empty; 
        /// <summary>
        /// Get or set special case type
        /// </summary>
        public string SPECIAL_CASE_TYPE
        {
            get { return _SPECIAL_CASE_TYPE; }
            set { _SPECIAL_CASE_TYPE = value; }
        }

        private string _ASSOCIATE_FINDING_TYPE = string.Empty;
        /// <summary>
        /// Get or set associate finding type
        /// </summary>
        public string ASSOCIATE_FINDING_TYPE
        {
            get { return _ASSOCIATE_FINDING_TYPE; }
            set { _ASSOCIATE_FINDING_TYPE = value; }
        }

        private string _AUXILIARY_LYMPH_NODE_TYPE = string.Empty;
        /// <summary>
        /// Get or set auxiliary lymph node type
        /// </summary>
        public string AUXILIARY_LYMPH_NODE_TYPE
        {
            get { return _AUXILIARY_LYMPH_NODE_TYPE; }
            set { _AUXILIARY_LYMPH_NODE_TYPE = value; }
        }

        private string _AUXILIARY_LYMPH_NODE_SIDE = string.Empty;
        /// <summary>
        /// Get or set auxiliary lymph node side
        /// </summary>
        public string AUXILIARY_LYMPH_NODE_SIDE
        {
            get { return _AUXILIARY_LYMPH_NODE_SIDE; }
            set { _AUXILIARY_LYMPH_NODE_SIDE = value; }
        }
        /// <summary>
        /// Get or set auxiliary lymph node size
        /// </summary>
        public int AUXILIARY_LYMPH_NODE_SIZE { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }

        public int SIZE_X { get; set; }
        public int SIZE_Y { get; set; }
        public int SIZE_Z { get; set; }

        private string _ASSOCIATE_FINDING_TYPE_TEXT = string.Empty;
        public string ASSOCIATE_FINDING_TYPE_TEXT
        {
            get { return _ASSOCIATE_FINDING_TYPE_TEXT; }
            set { _ASSOCIATE_FINDING_TYPE_TEXT = value; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
