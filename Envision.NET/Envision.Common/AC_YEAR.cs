using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class AC_YEAR
    {
        #region Member
        private int year_id;
        private string year_uid;
        private DateTime start_date;
        private DateTime end_date;
        private int org_id;
        private int created_by;
        private DateTime created_on;
        private int last_modified_by;
        private DateTime last_modified_on;
        #endregion


        #region Property
        public int YEAR_ID
        {
            get { return year_id; }
            set { year_id = value; }
        }
        public string YEAR_UID
        {
            get { return year_uid; }
            set { year_uid = value; }
        }
        public DateTime START_DATE
        {
            get { return start_date; }
            set { start_date = value; }
        }
        public DateTime END_DATE
        {
            get { return end_date; }
            set { end_date = value; }
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
        #endregion


        #region Constructor
        public AC_YEAR()
        {

        }
        #endregion

    }
}
