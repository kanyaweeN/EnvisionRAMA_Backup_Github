using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_ITEMTYPE
    {
        private int _ITEMTYPE_ID;
        private string _ITEMTYPE_UID;
        private string _ITEMTYPE_NAME;
        private string _ITEMTYPE_DESC;
        private int _ORG_ID;

        public INV_ITEMTYPE()
        { 
        }

        public int ITEMTYPE_ID
        {
            get { return _ITEMTYPE_ID; }
            set { _ITEMTYPE_ID = value; }
        }

        public string ITEMTYPE_UID
        {
            get { return _ITEMTYPE_UID; }
            set { _ITEMTYPE_UID = value; }
        }

        public string ITEMTYPE_NAME
        {
            get { return _ITEMTYPE_NAME; }
            set { _ITEMTYPE_NAME = value; }
        }

        public string ITEMTYPE_DESC
        {
            get { return _ITEMTYPE_DESC; }
            set { _ITEMTYPE_DESC = value; }
        }

        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }
    }
}
