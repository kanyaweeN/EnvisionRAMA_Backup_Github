using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class MG_BREASTEXAMRESULT
    {
        public string ACCESSION_NO { get; set; }
        public DateTime REPORTING_DATE { get; set; }
        public string PATIENT_TYPE { get; set; }
        public string PATIENT_TYPE_TEXT { get; set; }
        public string BREAST_COMPOSITION { get; set; }
        public int NO_OF_MASS { get; set; }
        private string _IS_MULTIPLE_MASS = "N";
        /// <summary>
        /// Get or set is mutiple mass
        /// </summary>
        public string IS_MULTIPLE_MASS
        {
            get { return _IS_MULTIPLE_MASS; }
            set { _IS_MULTIPLE_MASS = value; }
        }

        private string _HAS_DOMINANT_CYST = "N";
        /// <summary>
        /// Get or set HAS Dominant cyst
        /// </summary>
        public string HAS_DOMINANT_CYST
        {
            get { return _HAS_DOMINANT_CYST; }
            set { _HAS_DOMINANT_CYST = value; }
        }

        private string _IS_MG_NEGATIVE = "N";
        /// <summary>
        /// Get or set is nagative of mammogram
        /// </summary>
        public string IS_MG_NEGATIVE
        {
            get { return _IS_MG_NEGATIVE; }
            set { _IS_MG_NEGATIVE = value; }
        }
        private string _IS_US_NEGATIVE = "N";
        /// <summary>
        /// Get or set is nagative of ultrasound
        /// </summary>
        public string IS_US_NEGATIVE
        {
            get { return _IS_US_NEGATIVE; }
            set { _IS_US_NEGATIVE = value; }
        }
        private string _PERSONAL_HISTORY_OF_BREAST_CANCER = string.Empty;
        /// <summary>
        /// Get or set personal history of breast cancer
        /// </summary>
        public string PERSONAL_HISTORY_OF_BREAST_CANCER
        {
            get { return _PERSONAL_HISTORY_OF_BREAST_CANCER; }
            set { _PERSONAL_HISTORY_OF_BREAST_CANCER = value; }
        }
        private string _PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE = string.Empty;
        /// <summary>
        /// Get or set personal history of breast cancer breast side
        /// </summary>
        public string PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE
        {
            get { return _PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE; }
            set { _PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE = value; }
        }

        private string _FAMILY_HISTORY_OF_BREAST_CANCER = string.Empty;

        /// <summary>
        /// Get or Set Family history of breast cancer breast
        /// </summary>
        public string FAMILY_HISTORY_OF_BREAST_CANCER
        {
            get { return _FAMILY_HISTORY_OF_BREAST_CANCER; }
            set { _FAMILY_HISTORY_OF_BREAST_CANCER = value; }
        }

        private string _FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE = string.Empty;

        /// <summary>
        /// Get or Set Familiy history of breast cancer type degree
        /// </summary>
        public string FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE
        {
            get { return _FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE; }
            set { _FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE = value; }
        }
        private string _CLINICAL_HISTORY_TYPE = string.Empty;
        /// <summary>
        /// Get or set clinical history type
        /// </summary>
        public string CLINICAL_HISTORY_TYPE
        {
            get { return _CLINICAL_HISTORY_TYPE; }
            set { _CLINICAL_HISTORY_TYPE = value; }
        }
        /// <summary>
        /// Get or set impression text
        /// </summary>
        public string IMPRESSION_TEXT { get; set; }

        private string _FINAL_ASSESSMENT_TYPE = string.Empty;
        /// <summary>
        /// Get or set final assessment type
        /// </summary>
        public string FINAL_ASSESSMENT_TYPE
        {
            get { return _FINAL_ASSESSMENT_TYPE; }
            set { _FINAL_ASSESSMENT_TYPE = value; }
        }
        private string _RECOMMENDATION_TYPE = string.Empty;

        /// <summary>
        /// Get or set recommendation type
        /// </summary>
        public string RECOMMENDATION_TYPE
        {
            get { return _RECOMMENDATION_TYPE; }
            set { _RECOMMENDATION_TYPE = value; }
        }

        private string _RECOMMENDATION_TYPE_WITH_BREAST_SIDE = string.Empty;
        /// <summary>
        /// Get or set recommendation type with breast side
        /// </summary>
        public string RECOMMENDATION_TYPE_WITH_BREAST_SIDE
        {
            get { return _RECOMMENDATION_TYPE_WITH_BREAST_SIDE; }
            set { _RECOMMENDATION_TYPE_WITH_BREAST_SIDE = value; }
        }
        /// <summary>
        /// Get or set recommendation type text
        /// </summary>
        public string RECOMMENDATION_TYPE_TEXT { get; set; }
        public int PRELIM_BY { get; set; }
        public int FINALIZED_BY { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public string REPORT_STATUS { get; set; }

        private string _Is_MULTIPLE_CYST = "N";
        public string IS_MULTIPLE_CYST
        {
            get { return _Is_MULTIPLE_CYST; }
            set { _Is_MULTIPLE_CYST = value; }
        }

        public byte[] BREAST_IMAGE_LEFT { get; set; }
        public byte[] BREAST_IMAGE_RIGHT { get; set; }
        private string _SHOW_BREAST_IMAGE_LEFT = "N";
        public string SHOW_BREAST_IMAGE_LEFT
        {
            get { return _SHOW_BREAST_IMAGE_LEFT; }
            set { _SHOW_BREAST_IMAGE_LEFT = value; }
        }

        private string _SHOW_BREAST_IMAGE_RIGHT = "N";
        public string SHOW_BREAST_IMAGE_RIGHT
        {
            get { return _SHOW_BREAST_IMAGE_RIGHT; }
            set { _SHOW_BREAST_IMAGE_RIGHT = value; }
        }

        private string _COMMENT = string.Empty;
        public string COMMENT
        {
            get { return _COMMENT; }
            set { _COMMENT = value; }
        }
    }
}
