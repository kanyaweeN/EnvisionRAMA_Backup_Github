using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class GBLException
    {

        private int _EXC_ID;
        private string _EXC_UID;
        private string _EXC_TYPE;
        private string _EXC_TEXT;
        private string _EXC_IP;
        private string _EXC_PC_NAME;
        private int _CURRENT_FORM_ID;
        private int _CURRENT_LANG_ID;
        private int _CONNECTED_EMP_ID;
        private int _ORG_ID;
        private int _CREATED_BY;
        private DateTime _CREATED_ON;
        private int _LAST_MODIFIED_BY;
        private DateTime _LAST_MODIFIED_ON;

        public GBLException()
        {
        }

        public int EXC_ID
        {
            get { return _EXC_ID; }
            set { _EXC_ID = value; }
        }

        public string EXC_UID
        {
            get { return _EXC_UID; }
            set { _EXC_UID = value; }
        }

        public string EXC_TYPE
        {
            get { return _EXC_TYPE; }
            set { _EXC_TYPE = value; }
        }

        public string EXC_TEXT
        {
            get { return _EXC_TEXT; }
            set { _EXC_TEXT = value; }
        }

        public string EXC_IP
        {
            get { return _EXC_IP; }
            set { _EXC_IP = value; }
        }

        public string EXC_PC_NAME
        {
            get { return _EXC_PC_NAME; }
            set { _EXC_PC_NAME = value; }
        }

        public int CURRENT_FORM_ID
        {
            get { return _CURRENT_FORM_ID; }
            set { _CURRENT_FORM_ID = value; }
        }

        public int CURRENT_LANG_ID
        {
            get { return _CURRENT_LANG_ID; }
            set { _CURRENT_LANG_ID = value; }
        }

        public int CONNECTED_EMP_ID
        {
            get { return _CONNECTED_EMP_ID; }
            set { _CONNECTED_EMP_ID = value; }
        }

        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }

        public int CREATED_BY
        {
            get { return _CREATED_BY; }
            set { _CREATED_BY = value; }
        }

        public DateTime CREATED_ON
        {
            get { return _CREATED_ON; }
            set { _CREATED_ON = value; }
        }

        public int LAST_MODIFIED_BY
        {
            get { return _LAST_MODIFIED_BY; }
            set { _LAST_MODIFIED_BY = value; }
        }

        public DateTime LAST_MODIFIED_ON
        {
            get { return _LAST_MODIFIED_ON; }
            set { _LAST_MODIFIED_ON = value; }
        }
    }

}
