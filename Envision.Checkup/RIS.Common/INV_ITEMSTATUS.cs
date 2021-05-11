using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_ITEMSTATUS
    {
        private int _ITEMSTATUS_ID;
        private string _ITEMSTATUS_UID;
        private string _ITEMSTATUS_NAME;
        private int _ORG_ID;

        public INV_ITEMSTATUS()
        { 
        }

        public int ITEMSTATUS_ID
        {
            get { return _ITEMSTATUS_ID; }
            set { _ITEMSTATUS_ID = value; }
        }

        public string ITEMSTATUS_UID
        {
            get { return _ITEMSTATUS_UID; }
            set { _ITEMSTATUS_UID = value; }
        }

        public string ITEMSTATUS_NAME
        {
            get { return _ITEMSTATUS_NAME; }
            set { _ITEMSTATUS_NAME = value; }
        }

        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }
    }
}
