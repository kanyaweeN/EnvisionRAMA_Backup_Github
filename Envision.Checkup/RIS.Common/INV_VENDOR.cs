using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_VENDOR
    {
        private int _VENDOR_ID;
        private string _VENDOR_UID;
        private string _VENDOR_NAME;
        private int _ORG_ID;

        public INV_VENDOR()
        { 
        }

        public int VENDOR_ID
        {
            get { return _VENDOR_ID; }
            set { _VENDOR_ID = value; }
        }

        public string VENDOR_UID
        {
            get { return _VENDOR_UID; }
            set { _VENDOR_UID = value; }
        }

        public string VENDOR_NAME
        {
            get { return _VENDOR_NAME; }
            set { _VENDOR_NAME = value; }
        }

        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }
    }
}
