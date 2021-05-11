using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class HL7MonitoringNew
    {
        #region Member
        private int sp_types;
        private string msg_type;
        private int org_id;
        private DateTime from_date;
        private DateTime to_date;
        #endregion


        #region Property
        public int SP_TYPES
        {
            get { return sp_types; }
            set { sp_types = value; }
        }
        public string MSG_TYPE
        {
            get { return msg_type; }
            set { msg_type = value; }
        }
        public int ORG_ID
        {
            get { return org_id; }
            set { org_id = value; }
        }
        public DateTime FROM_DATE
        {
            get { return from_date; }
            set { from_date = value; }
        }
        public DateTime TO_DATE
        {
            get { return to_date; }
            set { to_date = value; }
        }
        #endregion


        #region Constructor
        public HL7MonitoringNew()
        {

        }
        #endregion


        #region Method
        public HL7MonitoringNew Copy()
        {
            return MemberwiseClone() as HL7MonitoringNew;
        }
        #endregion
    }
}
