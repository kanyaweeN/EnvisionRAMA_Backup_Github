using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_UNIT
    {
        private int _UNIT_ID;
        private string _UNIT_UID;
        private string _UNIT_NAME;
        private string _UNIT_DESC;
        private int _EXTERNAL_UNIT;
        private int _ORG_ID;

        public INV_UNIT()
        { 
        }

        public int UNIT_ID
        {
            get { return _UNIT_ID; }
            set { _UNIT_ID = value; }
        }

        public string UNIT_UID
        {
            get { return _UNIT_UID; }
            set { _UNIT_UID = value; }
        }

        public string UNIT_NAME
        {
            get { return _UNIT_NAME; }
            set { _UNIT_NAME = value; }
        }

        public string UNIT_DESC
        {
            get { return _UNIT_DESC; }
            set { _UNIT_DESC = value; }
        }

        public int EXTERNAL_UNIT
        {
            get { return _EXTERNAL_UNIT; }
            set { _EXTERNAL_UNIT = value; }
        }

        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }

    }
}
