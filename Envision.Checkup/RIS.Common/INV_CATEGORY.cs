using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_CATEGORY
    {
        private int _CATEGORY_ID;
        private string _CATEGORY_UID;
        private string _CATEGORY_NAME;
        private string _CATEGORY_DESC;
        private int _PARENT;
        private int _ORG_ID;

        public INV_CATEGORY()
        { 
        
        }

        public int CATEGORY_ID
        {
            get { return _CATEGORY_ID; }
            set { _CATEGORY_ID = value; }
        }

        public string CATEGORY_UID
        {
            get { return _CATEGORY_UID; }
            set { _CATEGORY_UID = value; }
        }

        public string CATEGORY_NAME
        {
            get { return _CATEGORY_NAME; }
            set { _CATEGORY_NAME = value; }
        }

        public string CATEGORY_DESC
        {
            get { return _CATEGORY_DESC; }
            set { _CATEGORY_DESC = value; }
        }

        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }

        public int PARENT
        {
            get { return _PARENT; }
            set { _PARENT = value; }
        }
    }
}
