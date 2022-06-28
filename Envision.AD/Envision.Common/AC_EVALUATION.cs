using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class AC_EVALUATION
    {
        #region Member
        private int evaluation_id;
        private int assignment_id;
        private string report_type;
        private string report_text;
        private DateTime reporting_timestamp;
        private int evaluated_by;
        private DateTime evaluated_on;
        private int grade_id;
        private string is_clinically_significant;
        private string comments;
        private int org_id;
        private int created_by;
        private DateTime created_on;
        private int last_modified_by;
        private DateTime last_modified_on;
        #endregion

        #region Property
        public int EVALUATION_ID
        {
            get { return evaluation_id; }
            set { evaluation_id = value; }
        }
        public int ASSIGNMENT_ID
        {
            get { return assignment_id; }
            set { assignment_id = value; }
        }
        public string REPORT_TYPE
        {
            get { return report_type; }
            set { report_type = value; }
        }
        public string IS_CLINICALLY_SIGNIFICANT
        {
            get { return is_clinically_significant; }
            set { is_clinically_significant = value; }
        }
        public string COMMENTS
        {
            get { return comments; }
            set { comments = value; }
        }
        public string REPORT_TEXT
        {
            get { return report_text; }
            set { report_text = value; }
        }
        public DateTime REPORTING_TIMESTAMP
        {
            get { return reporting_timestamp; }
            set { reporting_timestamp = value; }
        }
        public int EVALUATED_BY
        {
            get { return evaluated_by; }
            set { evaluated_by = value; }
        }
        public DateTime EVALUATED_ON
        {
            get { return evaluated_on; }
            set { evaluated_on = value; }
        }
        public int GRADE_ID
        {
            get { return grade_id; }
            set { grade_id = value; }
        }
        public int ORG_ID
        {
            get { return org_id; }
            set { org_id = value; }
        }
        public int CREATED_BY
        {
            get { return created_by; }
            set { created_by = value; }
        }
        public DateTime CREATED_ON
        {
            get { return created_on; }
            set { created_on = value; }
        }
        public int LAST_MODIFIED_BY
        {
            get { return last_modified_by; }
            set { last_modified_by = value; }
        }
        public DateTime LAST_MODIFIED_ON
        {
            get { return last_modified_on; }
            set { last_modified_on = value; }
        }

        public int LANGUAGE_OF_REPORT { get; set; }
        public string LANGUAGE_OF_REPORT_COMMENTS { get; set; }
        #endregion


        #region Constructor
        public AC_EVALUATION()
        {

        }
        #endregion
    }
}
